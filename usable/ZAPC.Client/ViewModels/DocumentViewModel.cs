namespace ZAPC.Client.ViewModels
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Icl.Mvvm.Async;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents;

    public abstract class DocumentViewModel<T> : ViewModelBase
        where T : DocumentBase
    {
        private readonly DocumentMode documentMode;
        private bool isEnabled;

        protected DocumentViewModel([NotNull] T model, DocumentMode mode, [CanBeNull] string fileName)
        {
            documentMode = mode;
            Model = model ?? throw new ArgumentNullException(nameof(model));
            if (mode == DocumentMode.New)
            {
                if (string.IsNullOrEmpty(fileName))
                    throw new ArgumentNullException(nameof(fileName), @"For new document 'FileName should be provided'");

                Model.FileName = fileName;
            }

            IsEnabled = mode != DocumentMode.Readonly;
            SaveDocumentCommand = new CancellableAsyncCommand(SaveDocumentAsync);
            SendDocumentToServerCommandAsync = new CancellableAsyncCommand(SendDocumentToServerAsync);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            private set
            {
                if (isEnabled == value) return;
                isEnabled = value;
                OnPropertyChanged();
            }
        }

        public T Model { get; set; }

        public string FileName => Model.FileName;

        [NotNull]
        public string TextDescriptionOfMode
        {
            get
            {
                switch (documentMode)
                {
                    case DocumentMode.Check: return "Проверка";
                    case DocumentMode.Edit: return "Редактирование";
                    case DocumentMode.New: return "Создание";
                    case DocumentMode.Readonly: return "Просмотр";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public ICancellableAsyncCommand SaveDocumentCommand { get; set; }

        // TODO: Use instead SaveDocumentCommand for ED202-ED499
        public IAsyncCommand SendDocumentToServerCommandAsync { get; set; }

        // TODO: Make abstract and use instead SaveDocumentAsync for ED202-ED499
        protected virtual async Task SendDocumentToServerAsync(CancellationToken token)
            => await Task.CompletedTask.ConfigureAwait(false);

        private async Task SaveDocumentAsync(CancellationToken token)
        {
            if (!Model.IsValid()) return;

            await Container.ServerObject.SendDocumentFileAsync(Model.FileName, Model.Encoding.GetBytes(Model.XmlContent), token).ConfigureAwait(false);
        }
    }
}
