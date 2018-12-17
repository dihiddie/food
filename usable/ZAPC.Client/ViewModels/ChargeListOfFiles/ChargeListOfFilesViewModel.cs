namespace ZAPC.Client.ViewModels.ChargeListOfFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Threading;

    using AdvancedDataGridControl.ColumnHeaderData;
    using Controllers.ShowFileInfo;
    using Core.Logging;

    using Documents.Ed101;
    using Essentials;
    using Icl.Mvvm.Async;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials.Commands;
    using ZAPC.Core;
    using ZAPC.CustomControls.Core;
    using ZAPC.Documents.Interfaces;
    using ZAPC.Documents.Statuses;
    using ZAPC.Documents.Statuses.DocumentActions.Interfaces;

    using Container = Essentials.Container;

    public class ChargeListOfFilesViewModel : ListOfDocumentsViewModel<Ed101>, ICheckDocAction, IEditDocAction, IOpenDocAction
    {
        private readonly ChargeFileController chargeController;
        private Task filterTask;
        private bool isChecked;

        public ChargeListOfFilesViewModel(IFileLoaderAsynchronous<Ed101> fileLoader, ChargeFileController controller)
            : base(fileLoader, controller)
        {
            chargeController = controller;
            InitializeCommands();
            SetHeaderTemplates();
            Initialize();
        }

        public ICancellableAsyncCommand CreateChargeCommandAsync { get; set; }

        public ICancellableAsyncCommand FilterAsyncCommand { get; set; }

        public ICommand CancelFilteringCommand { get; set; }

        public ICommand SelectedItemsChangedCommand { get; set; }

        public ICommand SetDefaultPrefilterCommand { get; set; }

        public CalendarHeaderData CalendarHeaderData { get; set; }

        public LiveSearchHeaderData PayerAccountNumberHeaderData { get; set; }

        public LiveSearchHeaderData PayeeBicHeaderData { get; set; }

        public LiveSearchHeaderData PayeeAccountNumberHeaderData { get; set; }

        public LiveSearchHeaderData CreatorFullNameHeaderData { get; set; }

        public Task FilterTask
        {
            get => filterTask;
            set
            {
                filterTask = value;
                OnPropertyChanged();
            }
        }

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                if (isChecked == value) return;
                isChecked = value;
                OnPropertyChanged();
            }
        }

        private List<Status> SelectedStatuses { get; set; }

        public override async Task RemoveAsync(string fileName, CancellationToken token)
        {
            BusyContent = "Удаляется";
            await Container.ServerObject.RemoveChargeFileAsync(fileName, token).ConfigureAwait(true);
            BusyContent = string.Empty;
        }

        public async Task CheckAsync(object edObject, CancellationToken token)
        {
            try
            {
                if (!(edObject is Ed101 ed101))
                {
                    Log.Error("Выбранный файл не является ED101");
                    return;
                }

                chargeController.Check(await GetChargeDataAsync(ed101, token).ConfigureAwait(true));
                await Task.CompletedTask.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public async Task EditAsync(object edObject, CancellationToken cancellationToken)
        {
            try
            {
                if (!(edObject is Ed101 ed101))
                {
                    Log.Error("Выбранный файл не является ED101");
                    return;
                }

                chargeController.Edit(await GetChargeDataAsync(ed101, cancellationToken).ConfigureAwait(true));

                await Task.CompletedTask.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        [NotNull]
        public Task OpenAsync(object edObject, CancellationToken cancellationToken) =>
            OpenFileByObjectAsync(edObject, cancellationToken);

        [CanBeNull]
        // ReSharper disable once StyleCop.SA1009
        protected override async Task<(Encoding, string)> GetContentAsync(
            [NotNull] IFileNameContainer obj,
            CancellationToken token)
        {
            var res = await Container.ServerObject.GetChargeFileContentAsync(obj.FileName, token).ConfigureAwait(false);
            Task unused = Container.ServerObject.UnlockChargeFileAsync(obj.FileName);
            return res;
        }

        protected override Task SendSignAsync(string fileName, byte[] signData, CancellationToken token) =>
            Container.ServerObject.SendChargeSignAsync(fileName, signData, token);

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
            if (!string.IsNullOrEmpty(PayerAccountNumberHeaderData?.FilterText))
                Criteria.Add(x => x.Payer.AccountNumber.ToString().Contains(PayerAccountNumberHeaderData.FilterText));
            if (!string.IsNullOrEmpty(PayeeBicHeaderData?.FilterText))
                Criteria.Add(x => x.Payee.Bank.Bic.Contains(PayeeBicHeaderData.FilterText));
            if (!string.IsNullOrEmpty(PayeeAccountNumberHeaderData?.FilterText))
                Criteria.Add(x => x.Payee?.AccountNumber.ToString().Contains(PayeeAccountNumberHeaderData.FilterText) == true);
            if (!string.IsNullOrEmpty(CreatorFullNameHeaderData?.FilterText))
                Criteria.Add(x => x.CreatorFullName?.Contains(CreatorFullNameHeaderData.FilterText) == true);
        }

        [NotNull]
        protected override Task AddOrUpdateSourceColletion(IDictionary<string, Ed101> elementsToBeAddedOrUpdated, CancellationToken cancellationToken)
            => Task.Run(() => { foreach (var elem in elementsToBeAddedOrUpdated) SourceCollection.TryAdd(elem.Key, elem.Value); }, cancellationToken);

        [NotNull]
        protected override Task RemoveElementsFromSourceAndFile(IDictionary<string, Ed101> dataFromServer, Dispatcher dispatcher, CancellationToken cancellationToken)
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
        protected override Task<Dictionary<string, Ed101>> GetElementsToBeAddedOrUpdated(IDictionary<string, Ed101> dataFromServer, CancellationToken cancellationToken)
            => Task.Run(() => dataFromServer.Where(x => !SourceCollection.Keys.Contains(x.Key)).ToDictionary(x => x.Key, pair => pair.Value), cancellationToken);

        [ItemNotNull]
        private async Task<Ed101> GetChargeDataAsync([NotNull] Ed101 ed101, CancellationToken cancellationToken)
        {
            BusyContent = "Получение содержимого";
            // ReSharper disable once PossibleNullReferenceException
            var(encoding, content) = await GetContentAsync(ed101, cancellationToken).ConfigureAwait(true);

            var ed101WithData = Ed101.Parse(content);
            ed101WithData.FileName = ed101.FileName;
            ed101WithData.Encoding = encoding;

            return ed101WithData;
        }

        private void InitializeCommands()
        {
            CreateChargeCommandAsync = new CancellableAsyncCommand(CreateChargeAsync);
            FilterAsyncCommand = new CancellableAsyncCommand(Filter);
            CancelFilteringCommand = new RelayCommand(CancelFiltering);
            SelectedItemsChangedCommand = new CancellableAsyncCommand(HandleSelectedStatuses);
            SetDefaultPrefilterCommand = new RelayCommand<object>(SetDefaultPrefilter);
        }

        private void SetHeaderTemplates()
        {
            CalendarHeaderData = new CalendarHeaderData { ColumnName = "Операционный день" };
            PayerAccountNumberHeaderData = new LiveSearchHeaderData { ColumnName = "Счет плательщика", HintText = "Введите счет плательщика" };
            PayeeBicHeaderData = new LiveSearchHeaderData { ColumnName = "БИК получателя", HintText = "Введите БИК получателя" };
            PayeeAccountNumberHeaderData = new LiveSearchHeaderData { ColumnName = "Счет получателя", HintText = "Введите счет получателя" };
            CreatorFullNameHeaderData = new LiveSearchHeaderData { ColumnName = "ФИО созд.", HintText = "Введите ФИО создателя" };
        }

        private void Initialize()
        {
            SelectedStatuses = new List<Status>();
            FilterTask = Task.CompletedTask;
        }

        private async Task CreateChargeAsync(CancellationToken token)
        {
            var ed101 = chargeController.Create(
                await Container.ServerObject.GetDocumentNameAsync(Ed101.TypeCode, token).ConfigureAwait(false));

            if (ed101 == null) return;

            if (ed101.DepartmentalInfo != null && !ed101.SaveDepartmentalInfo) ed101.DepartmentalInfo = null;

            await Container.ServerObject
                .SendChargeFileAsync(ed101.FileName, ed101.Encoding.GetBytes(ed101.XmlContent), token)
                .ConfigureAwait(false);

            Log.Info(
                "Платежка успешно создана и отправлена на сервер. Пожалуйста, обновите список платежек, чтобы увидеть её в списке.");
        }

        private async Task Filter(CancellationToken token)
        {
            var filtered = await FilterSource(Files, SourceCollection.Values, token);
            await SyncFilesCollection(filtered, token);
        }

        private void CancelFiltering()
        {
        }

        private void SetDefaultPrefilter(object obj)
        {
            if (obj is IPrefiltrableDataGrid dataGrid)
                dataGrid.SetCalendarPrefilter("OperDay", Global.OperationDay, Global.OperationDay);
        }

        private async Task HandleSelectedStatuses(object selectedStatuses, CancellationToken token)
        {
            SelectedStatuses.Clear();
            if (!(selectedStatuses is IEnumerable<object> listOfStatuses)) return;
            SelectedStatuses = new List<Status>(listOfStatuses.Cast<Status>());

            await Filter(token).ConfigureAwait(false);
        }
    }
}
