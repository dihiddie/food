namespace ZAPC.Client.ViewModels.OtherDocsListOfFile
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Threading;

    using AdvancedDataGridControl.ColumnHeaderData;

    using Icl.Mvvm.Async;

    using JetBrains.Annotations;

    using ZAPC.Client.Controllers.ShowFileInfo;
    using ZAPC.Client.Essentials;
    using ZAPC.Client.Essentials.Commands;
    using ZAPC.Core;
    using ZAPC.CustomControls.Core;
    using ZAPC.Documents;
    using ZAPC.Documents.Interfaces;
    using ZAPC.Documents.Statuses;
    using ZAPC.Documents.Statuses.DocumentActions.Interfaces;

    public class OtherDocsListOfFilesViewModel : ListOfDocumentsViewModel<IDocumentWithCreationDateTime>, IOpenDocAction
    {
        private Task filterTask;

        public OtherDocsListOfFilesViewModel(
            IFileLoaderAsynchronous<IDocumentWithCreationDateTime> fileLoader,
            IShowFileInfoController controller)
            : base(fileLoader, controller)
        {
            Initialize();
            CreateEdDoc.BusyContentChanged += (sender, args) => BusyContent = args;
            SetHeaderTemplates();
            InitializeCommands();
        }

        public ICancellableAsyncCommand FilterAsyncCommand { get; set; }

        public ICommand CancelFilteringCommand { get; set; }

        public ICommand SelectedItemsChangedCommand { get; set; }

        public ICommand SetDefaultPrefilterCommand { get; set; }

        public LiveSearchHeaderData FileNameHeaderData { get; set; }

        public LiveSearchHeaderData CreatorFullNameHeaderData { get; set; }

        public CalendarHeaderData CalendarHeaderData { get; set; }

        public LiveSearchHeaderData DocTypeHeaderData { get; set; }

        public CreateEdDocViewModel CreateEdDoc { get; set; }

        public Task FilterTask
        {
            get => filterTask;
            set
            {
                filterTask = value;
                OnPropertyChanged();
            }
        }

        private List<Status> SelectedStatuses { get; set; }

        public override Task RemoveAsync(string fileName, CancellationToken token) => Container.ServerObject.RemoveChargeFileAsync(fileName, token);

        [NotNull]
        public Task OpenAsync(object edObject, CancellationToken cancellationToken) =>
            OpenFileByObjectAsync(edObject, cancellationToken);

        [CanBeNull]
        // ReSharper disable once StyleCop.SA1009
        protected override async Task<(Encoding, string)> GetContentAsync(
            [CanBeNull] IFileNameContainer obj,
            CancellationToken token)
        {
            var(encoding, content) = await Container.ServerObject.GetOtherDocsContentAsync(obj?.FileName, token)
                                         .ConfigureAwait(false);
            Task unused = Container.ServerObject.UnlockUfebsFileAsync(obj?.FileName);
            return (encoding, content);
        }

        protected override Task SendSignAsync(string fileName, byte[] signData, CancellationToken token)
            => Container.ServerObject.SendOtherDocumentSignAsync(fileName, signData, token);

        protected override void SetFilters()
        {
            Criteria.Clear();

            if (CalendarHeaderData?.DateRange != null)
            {
                var sort = CalendarHeaderData.DateRange.OrderBy(x => x).ToList();

                // Last day till 23:59:59.999
                if (sort.Count != 0) Criteria.Add(x => x.EdDate >= sort.FirstOrDefault() && x.EdDate <= sort.LastOrDefault().AddDays(1).AddMilliseconds(-1));
            }

            if (SelectedStatuses.Count != 0) Criteria.Add(x => SelectedStatuses.Contains(x.Status));
            if (!string.IsNullOrEmpty(FileNameHeaderData?.FilterText))
                Criteria.Add(x => x.FileName.ToString().Contains(FileNameHeaderData.FilterText));
            if (!string.IsNullOrEmpty(CreatorFullNameHeaderData?.FilterText))
                Criteria.Add(x => x.CreatorFullName.Contains(CreatorFullNameHeaderData.FilterText));
            if (!string.IsNullOrEmpty(CreatorFullNameHeaderData?.FilterText))
                Criteria.Add(x => x.CreatorFullName?.Contains(CreatorFullNameHeaderData.FilterText) == true);
            if (!string.IsNullOrEmpty(DocTypeHeaderData?.FilterText))
                Criteria.Add(x => x.GetTypeCode().Contains(DocTypeHeaderData.FilterText));
        }

        [NotNull]
        protected override Task AddOrUpdateSourceColletion(IDictionary<string, IDocumentWithCreationDateTime> elementsToBeAddedOrUpdated, CancellationToken cancellationToken)
            => Task.Run(() => { foreach (var elem in elementsToBeAddedOrUpdated) SourceCollection.TryAdd(elem.Key, elem.Value); }, cancellationToken);

        [NotNull]
        protected override Task RemoveElementsFromSourceAndFile(IDictionary<string, IDocumentWithCreationDateTime> dataFromServer, Dispatcher dispatcher, CancellationToken cancellationToken)
            => Task.Run(
                () =>
                    {
                        var dataToRemove = SourceCollection.Keys.Where(x => !dataFromServer.Keys.Contains(x)).ToList();
                        foreach (var row in dataToRemove)
                        {
                            SourceCollection.TryRemove(row, out var val);
                            dispatcher.Invoke(() => RemoveFromFilesCollection(val));
                        }
                    },
                cancellationToken);

        [NotNull]
        protected override Task<Dictionary<string, IDocumentWithCreationDateTime>> GetElementsToBeAddedOrUpdated(IDictionary<string, IDocumentWithCreationDateTime> dataFromServer, CancellationToken cancellationToken)
            => Task.Run(() => dataFromServer.Where(x => !SourceCollection.Keys.Contains(x.Key)).ToDictionary(x => x.Key, pair => pair.Value), cancellationToken);

        private async Task Filter(CancellationToken token)
        {
            var filtered = await FilterSource(Files, SourceCollection.Values, token);
            await SyncFilesCollection(filtered, token);
        }

        private void CancelFiltering()
        {
        }

        private async Task HandleSelectedStatuses(object selectedStatuses, CancellationToken token)
        {
            SelectedStatuses.Clear();
            if (!(selectedStatuses is IEnumerable<object> listOfStatuses)) return;
            SelectedStatuses = new List<Status>(listOfStatuses.Cast<Status>());

            await Filter(token).ConfigureAwait(false);
        }

        private void SetHeaderTemplates()
        {
            FileNameHeaderData = new LiveSearchHeaderData { ColumnName = "Имя файла", HintText = "Введите имя файла" };
            CreatorFullNameHeaderData = new LiveSearchHeaderData { ColumnName = "ФИО создателя", HintText = "Введите фио создателя" };
            CalendarHeaderData = new CalendarHeaderData { ColumnName = "Операционный день" };
            DocTypeHeaderData = new LiveSearchHeaderData { ColumnName = "Тип", HintText = "Введите тип" };
        }

        private void InitializeCommands()
        {
            FilterAsyncCommand = new CancellableAsyncCommand(Filter);
            CancelFilteringCommand = new RelayCommand(CancelFiltering);
            SelectedItemsChangedCommand = new CancellableAsyncCommand(HandleSelectedStatuses);
            SetDefaultPrefilterCommand = new RelayCommand<object>(SetDefaultPrefilter);
        }

        private void SetDefaultPrefilter(object obj)
        {
            if (obj is IPrefiltrableDataGrid dataGrid)
                dataGrid.SetCalendarPrefilter("OperDay", Global.OperationDay, Global.OperationDay);
        }

        private void Initialize()
        {
            CreateEdDoc = new CreateEdDocViewModel();
            SelectedStatuses = new List<Status>();
            FilterTask = Task.CompletedTask;
        }
    }
}
