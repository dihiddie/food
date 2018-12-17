namespace ZAPC.Client.ViewModels.SelectEDAuthor
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Threading;

    using Icl.Mvvm.Async;

    using JetBrains.Annotations;

    using ZAPC.Client.Controllers.EDAuthor;
    using ZAPC.Client.Essentials;
    using ZAPC.Client.Essentials.Commands;
    using ZAPC.Client.Essentials.Models;
    using ZAPC.Core;

    public sealed class SelectEdAuthorViewModel : ViewModelBase
    {
        private readonly ISelectEdAuthorController selectEdAuthorController;

        private ObservableCollection<EdAuthorModel> eDAuthors = new ObservableCollection<EdAuthorModel>();

        private string currentOperationText;

        private int retryCount;

        private Exception lastError;

        private DispatcherTimer dataLoadTimer;

        public SelectEdAuthorViewModel(ISelectEdAuthorController controller)
        {
            selectEdAuthorController = controller;
            InitializeCommands();
            InitTimer();
            LoadEdAuthorsAsyncCommand.ExecuteAsync(null);
        }

        public ICommand SelectEdAuthorCommand { get; set; }

        public ICancellableAsyncCommand LoadEdAuthorsAsyncCommand { get; set; }

        public ICommand GetErrorInfoCommand { get; set; }

        public string CurrentOperationText
        {
            get => currentOperationText;
            private set
            {
                currentOperationText = value;
                OnPropertyChanged();
            }
        }

        public Exception LastError
        {
            get => lastError;
            set
            {
                lastError = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EdAuthorModel> EdAuthors
        {
            get => eDAuthors;
            private set
            {
                eDAuthors = value;
                OnPropertyChanged();
            }
        }

        public bool HasEdAuthors => EdAuthors.Any();

        private void CheckAnyAuthorExists()
        {
            if (HasEdAuthors) return;

            selectEdAuthorController.NoAvailibleEdAuthors();
        }

        private async Task LoadEdAuthorsSafeAsync(CancellationToken token)
        {
            StartLoading();
            await LoadingAsync(token).ConfigureAwait(false);
            FinishLoading();
        }

        private async Task LoadingAsync(CancellationToken token)
        {
            while (!await TryLoadEdAuthorsAsync(token).ConfigureAwait(false)) { }
        }

        private void StartLoading()
        {
            dataLoadTimer.Start();
            retryCount = 0;
            CurrentOperationText = "Загрузка данных...";
        }

        private void FinishLoading()
        {
            CurrentOperationText = string.Empty;
            dataLoadTimer.Stop();
        }

        private async Task<bool> TryLoadEdAuthorsAsync(CancellationToken token)
        {
            try
            {
                await LoadEdAuthorsAsync(token).ConfigureAwait(false);
                return true;
            }
            catch (Exception e)
            {
                LastError = e;
                retryCount++;
                CurrentOperationText = $"Загрузка списка уникальных идентификаторов составителей ЭС. Попытка №{retryCount + 1}";
                return false;
            }
        }

        private async Task LoadEdAuthorsAsync(CancellationToken token)
        {
            var data = await Container.ServerObject.GetEdAuthorsAsync(token).ConfigureAwait(false);
            EdAuthors = new ObservableCollection<EdAuthorModel>(data);
            CheckAnyAuthorExists();
        }

        private void InitializeCommands()
        {
            SelectEdAuthorCommand = new RelayCommand<EdAuthorModel>(SelectEdAuthor);
            GetErrorInfoCommand = new RelayCommand(GetErrorInfo);
            LoadEdAuthorsAsyncCommand = new CancellableAsyncCommand(LoadEdAuthorsSafeAsync);
        }

        private void SelectEdAuthor([NotNull] EdAuthorModel model)
        {
            Global.EdAuthor = model.Id;

            selectEdAuthorController.EdAuthorSelected();
        }

        private void GetErrorInfo() => selectEdAuthorController.GetLastError(LastError);

        private void InitTimer()
        {
            dataLoadTimer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(1) };
            dataLoadTimer.Tick += CheckIsDataLoaded;
        }

        private void CheckIsDataLoaded(object sender, EventArgs e)
        {
            if (HasEdAuthors) return;

            LoadEdAuthorsAsyncCommand.Cancel();
            selectEdAuthorController.EdAuthorsLoadTimeout(dataLoadTimer.Interval.TotalSeconds);
        }
    }
}
