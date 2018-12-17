namespace ZAPC.Client.ViewModels
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;

    using Core.Logging;

    using Essentials;

    using Icl.Mvvm.Async;

    using JetBrains.Annotations;

    using ZAPC.Documents.Interfaces;

    public abstract class ListOfFilesBaseViewModel<T> : ViewModelBase, IAutoUpdatable where T : IFileNameContainer
    {
        protected readonly List<Predicate<T>> Criteria = new List<Predicate<T>>();
        private readonly IFileLoaderAsynchronous<T> fileLoader;
        private readonly Dispatcher dispatcher;
        private readonly object displayCollectionUpldateLock = new object();
        private bool autoUpdate;
        private ObservableCollection<T> files;
        private DispatcherTimer updateTimer;
        private bool isFirstLoad;

        protected ListOfFilesBaseViewModel(IFileLoaderAsynchronous<T> fileLoader)
        {
            this.fileLoader = fileLoader;
            SourceCollection = new ConcurrentDictionary<string, T>();
            Files = new ObservableCollection<T>();
            IsFirstLoad = true;
            InitializeUpdateTimer();
            dispatcher = Application.Current.Dispatcher;
        }

        public bool IsFirstLoad
        {
            get => isFirstLoad;
            set
            {
                isFirstLoad = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<T> Files
        {
            get => files;
            set
            {
                files = value;
                OnPropertyChanged();
            }
        }

        public IAsyncCommand OpenFileByFileNameCommand { get; set; }

        public IAsyncCommand OpenFileByObjectCommand { get; set; }

        public bool AutoUpdate
        {
            get => autoUpdate;
            set
            {
                if (autoUpdate.Equals(value)) return;

                autoUpdate = value;
                if (value) StartAutoUpdate();
                else StopAutoUpdate();
                OnPropertyChanged();
            }
        }

        protected ConcurrentDictionary<string, T> SourceCollection { get; set; }

        public void StopAutoUpdate() => updateTimer.Stop();

        public void StartAutoUpdate() => UpdateTimerElapsedAsync(updateTimer, null);

        protected void RemoveFromFilesCollection(T val)
        {
            lock (displayCollectionUpldateLock)
            {
                if (Files.Contains(val)) Files.Remove(val);
            }
        }

        protected abstract void SetFilters();

        protected abstract Task AddOrUpdateSourceColletion(IDictionary<string, T> elementsToBeAddedOrUpdated, CancellationToken cancellationToken);

        protected abstract Task RemoveElementsFromSourceAndFile(IDictionary<string, T> dataFromServer, Dispatcher dispatcher, CancellationToken cancellationToken);

        protected abstract Task<Dictionary<string, T>> GetElementsToBeAddedOrUpdated(IDictionary<string, T> dataFromServer, CancellationToken cancellationToken);

        [NotNull]
        protected Task<IEnumerable<T>> FilterSource(IEnumerable<T> display, IEnumerable<T> source, CancellationToken cancellationToken)
        {
            return Task.Run(
                () =>
                    {
                        SetFilters();
                        if (Criteria.Count <= 0) return source;

                        var filtered = new List<T>();

                        foreach (var ed in source)
                        {
                            if (cancellationToken.IsCancellationRequested) return display;
                            if (IsFitForCriteria(ed)) filtered.Add(ed);
                        }

                        return filtered;
                    },
                cancellationToken);
        }

        [NotNull]
        protected Task SyncFilesCollection([NotNull] IEnumerable<T> filtered, CancellationToken cancellationToken)
            => Task.Run(
                () =>
                    {
                        lock (displayCollectionUpldateLock)
                        {
                            dispatcher.Invoke(
                                () =>
                                    {
                                        Files.Clear();
                                        foreach (var file in filtered)
                                            Files.Add(file);
                                    });
                        }
                    },
                cancellationToken);

        [NotNull]
        private static IDictionary<string, T> GetDataFromServer([CanBeNull] IEnumerable<T> dataFromServer)
        {
            var result = new Dictionary<string, T>();
            if (dataFromServer == null || dataFromServer.Any() == false) return result;

            foreach (var file in dataFromServer)
                if (!result.ContainsKey(file.FileName))
                    result.Add(file.FileName, file);
                else
                    Log.Warn($"Files with same name ({file.FileName}) retrieved from server");

            return result;
        }

        private bool IsFitForCriteria(object item) => Criteria.Count == 0 || Criteria.TrueForAll(x => x((T)item));

        // ToDo to Dictionaries
        // ToDo check concurency for collections
        private async Task LoadAllFilesAsync(CancellationToken cancellationToken)
        {
            var dataFromServer = GetDataFromServer(await fileLoader.GetFilesAsync(cancellationToken).ConfigureAwait(false));
            if (IsFirstLoad) IsFirstLoad = false;

            await RemoveElementsFromSourceAndFile(dataFromServer, dispatcher, cancellationToken).ConfigureAwait(false);
            var elementsToBeAddedOrUpdated = await GetElementsToBeAddedOrUpdated(dataFromServer, cancellationToken).ConfigureAwait(false);

            if (elementsToBeAddedOrUpdated.Count <= 0) return;

            await AddOrUpdateSourceColletion(elementsToBeAddedOrUpdated, cancellationToken).ConfigureAwait(true);

            var filtered = await FilterSource(Files, elementsToBeAddedOrUpdated.Values, cancellationToken).ConfigureAwait(true);

            await AddOrUpdateFilesCollection(filtered, cancellationToken).ConfigureAwait(true);
        }

        [NotNull]
        private Task AddOrUpdateFilesCollection(IEnumerable<T> filtered, CancellationToken cancellationToken)
           => Task.Run(() => dispatcher.Invoke(() => { foreach (var file in filtered) Files.Add(file); }), cancellationToken);

        private void InitializeUpdateTimer()
        {
            updateTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
            updateTimer.Tick += UpdateTimerElapsedAsync;
        }

        private async void UpdateTimerElapsedAsync(object sender, EventArgs e)
        {
            try
            {
                updateTimer.Stop();
                await LoadAllFilesAsync(CancellationToken.None).ConfigureAwait(true);
                updateTimer.Start();
            }
            catch (Exception ex)
            {
                DisableAutoUpdate(ex);
            }
        }

        private void DisableAutoUpdate(Exception ex)
        {
            AutoUpdate = false;
            Log.Warn("Автоматическое обновление списка файлов выключено из-за ошибки.");
            Log.Error(ex);
        }
    }
}
