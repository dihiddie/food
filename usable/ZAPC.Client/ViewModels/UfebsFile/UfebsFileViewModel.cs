using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Icl.Mvvm.Async;

using Microsoft.Win32;

using ZAPC.Client.Essentials;
using ZAPC.Core;
using ZAPC.Core.Envelopes;
using ZAPC.Core.Logging;

namespace ZAPC.Client.ViewModels.UfebsFile
{
    using JetBrains.Annotations;

    public sealed class UfebsFileViewModel : ViewModelBase
    {
        private Encoding fileContentEncoding;
        private string fileContent;
        private string currentOperationText;
        private bool notSigned = true;

        public UfebsFileViewModel(string fileName)
        {
            FileName = fileName;
            InitializeCommands();
            GetFileContentCommandAsync.Execute(fileName);
        }

        public ICancellableAsyncCommand GetFileContentCommandAsync { get; private set; }

        public ICancellableAsyncCommand SaveFileCommandAsync { get; private set; }

        public ICancellableAsyncCommand SignCommandAsync { get; private set; }

        public string FileName { get; }

        public bool NotSigned
        {
            get => notSigned;
            private set
            {
                notSigned = value;
                OnPropertyChanged();
            }
        }

        public string FileContent
        {
            get => fileContent;
            set
            {
                fileContent = value;
                OnPropertyChanged();
            }
        }

        public Encoding FileContentEncoding
        {
            get => fileContentEncoding;
            set
            {
                fileContentEncoding = value;
                OnPropertyChanged();
            }
        }

        public string CurrentOperationText
        {
            get => currentOperationText;
            set
            {
                currentOperationText = value;
                OnPropertyChanged();
            }
        }

        private void InitializeCommands()
        {
            GetFileContentCommandAsync = new CancellableAsyncCommand(GetFileContentAsync);
            SaveFileCommandAsync = new CancellableAsyncCommand(SaveFileAsync);
            SignCommandAsync = new CancellableAsyncCommand(SignAsync);
        }

        private async Task GetFileContentAsync(CancellationToken cancellationToken)
        {
            CurrentOperationText = "Получение содержимого файла...";
            var(encoding, content) = await TaskExt
                                         .SafeCallAsync(Container.ServerObject.GetFileContentAsync, FileName, cancellationToken)
                                         .ConfigureAwait(false);
            FileContent = content;
            FileContentEncoding = encoding;
            CurrentOperationText = "Содержимое файла получено.";
        }

        private async Task SignAsync(CancellationToken cancellationToken)
        {
            try
            {
                var sign = await Task.Run(
                                   () => CryptoPro.Signer.Sign(
                                       new SimpleEnvelope { Data = FileContentEncoding.GetBytes(FileContent) }),
                                   cancellationToken)
                               .ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested();

                await Container.ServerObject.SendSignAsync(FileName, sign.SignData, cancellationToken)
                    .ConfigureAwait(false);
                NotSigned = false;
                Log.Info("Файл успешно подписан.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private async Task SaveFileAsync(CancellationToken cancellationToken)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                                            {
                                                Filter = "XML documents (.xml)|*.xml",
                                                DefaultExt = "*.xml",
                                                FileName = FileName.EndsWith(
                                                               ".xml",
                                                               StringComparison.Ordinal)
                                                               ? FileName
                                                               : FileName + ".xml"
                                            };

                if (dialog.ShowDialog() != true) return;

                await WriteDataToFileAsync(dialog.FileName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private async Task WriteDataToFileAsync([NotNull] string fileName, CancellationToken cancellationToken)
        {
            CurrentOperationText = "Сохранение данных в файл...";

            byte[] dataToSave = FileContentEncoding.GetBytes(FileContent);

            using (var fileStream = new FileStream(
                fileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                useAsync: true,
                bufferSize: 4096))
            {
                await fileStream.WriteAsync(dataToSave, 0, dataToSave.Length, cancellationToken).ConfigureAwait(false);
            }

            CurrentOperationText = "Файл успешно сохранён.";
        }
    }
}
