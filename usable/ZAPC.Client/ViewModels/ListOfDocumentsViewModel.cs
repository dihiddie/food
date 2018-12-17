namespace ZAPC.Client.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Icl.Mvvm.Async;

    using JetBrains.Annotations;

    using ZAPC.Client.Controllers.ShowFileInfo;
    using ZAPC.Client.Essentials;
    using ZAPC.Core.Envelopes;
    using ZAPC.Core.Logging;
    using ZAPC.CustomControls.Core;
    using ZAPC.Documents;
    using ZAPC.Documents.Interfaces;
    using ZAPC.Documents.Serialization;
    using ZAPC.Documents.Statuses.DocumentActions.Interfaces;

    using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

    public abstract class ListOfDocumentsViewModel<T> : ListOfFilesBaseViewModel<T>,
                                                        ISaveAsDocAction,
                                                        IRemoveDocAction,
                                                        ISignDocAction
        where T : IFileNameContainer
    {
        private readonly IShowFileInfoController showFileInfoController;

        private string busyContent;

        protected ListOfDocumentsViewModel(IFileLoaderAsynchronous<T> fileLoader, IShowFileInfoController controller)
            : base(fileLoader)
        {
            showFileInfoController = controller;
            Init();
        }

        public ICancellableAsyncCommand SaveFilesAsyncCommand { get; set; }

        public ICancellableAsyncCommand SignFilesAsyncCommand { get; set; }

        public ICancellableAsyncCommand RemoveFilesAsyncCommand { get; set; }

        public string BusyContent
        {
            get => busyContent;
            set
            {
                busyContent = value;
                OnPropertyChanged();
            }
        }

        public async Task SaveAsAsync(object objectToSave, CancellationToken token)
        {
            try
            {
                if (!(objectToSave is IFileNameContainer docObject)) return;
                SaveFileDialog dialog = new SaveFileDialog
                                            {
                                                Filter = "XML documents (.xml)|*.xml",
                                                DefaultExt = "*.xml",
                                                FileName =
                                                    docObject.FileName.EndsWith(
                                                        ".xml",
                                                        StringComparison.Ordinal)
                                                        ? docObject.FileName
                                                        : docObject.FileName + ".xml"
                                            };

                if (dialog.ShowDialog() != true) return;

                BusyContent = "Получение содержимого";
                var(encoding, content) = await GetContentAsync(docObject, token).ConfigureAwait(false);

                BusyContent = "Сохранение";
                await WriteDataToFileAsync(dialog.FileName, content, encoding, token).ConfigureAwait(false);

                Log.Info($"Файл '{docObject.FileName}' успешно сохранён.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public async Task SignAsync(object edObject, CancellationToken token)
        {
            if (!(edObject is IFileNameContainer edObj)) return;

            try
            {
                BusyContent = "Получение содержимого";
                var(encoding, content) = await GetContentAsync(edObj, token).ConfigureAwait(false);

                BusyContent = "Отправка на сервер";
                await SendSignAsync(
                    edObj.FileName,
                    (await CreateSignAsync(encoding, content, token).ConfigureAwait(false)).SignData,
                    token).ConfigureAwait(false);

                Log.Info($"Документ '{edObj.FileName}' успешно подписан.");

                StartAutoUpdate();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public abstract Task RemoveAsync(string fileName, CancellationToken token);

        // ReSharper disable once StyleCop.SA1009
        protected abstract Task<(Encoding, string)> GetContentAsync(IFileNameContainer obj, CancellationToken token);

        protected abstract Task SendSignAsync(string fileName, byte[] signData, CancellationToken token);

        protected async Task SaveFilesFuncAsync(object objects, CancellationToken token)
        {
            StopAutoUpdate();

            if (TryGetPathToSaveFiles(out var path))
            {
                await SaveFilesSafe(CastToIEnumerableIFileNameContainer(objects), path, token).ConfigureAwait(false);
                Process.Start(path);
            }

            StartAutoUpdate();
        }

        [NotNull]
        protected Task OpenFileByFileNameAsync(object fileName, CancellationToken cancellationToken)
        {
            StopAutoUpdate();
            BusyContent = "Получаем содержимое";
            showFileInfoController.ShowFileInfo((string)fileName);
            StartAutoUpdate();
            return Task.CompletedTask;
        }

        protected async Task OpenFileByObjectAsync(object obj, CancellationToken cancellationToken)
        {
            if (obj is ILocked row)
                if (row.IsLocked) return;

            StopAutoUpdate();
            BusyContent = "Получаем содержимое";
            var(encoding, content) = await GetContentAsync((IFileNameContainer)obj, cancellationToken).ConfigureAwait(true);

            var objectWithData = typeof(Xml).GetMethod("Deserialize")?.MakeGenericMethod(obj.GetType())
                .Invoke(null, new object[] { content });

            // ReSharper disable once PossibleNullReferenceException
            ((DocumentBase)objectWithData).Encoding = encoding;
            // ReSharper disable once PossibleNullReferenceException
            ((DocumentBase)objectWithData).FileName = ((IFileNameContainer)obj).FileName;
            showFileInfoController.ShowFileInfo(objectWithData);
            StartAutoUpdate();
        }

        private static bool TryGetPathToSaveFiles(out string path)
        {
            var dialog = new FolderBrowserDialog { RootFolder = Environment.SpecialFolder.UserProfile };
            var result = dialog.ShowDialog();

            path = dialog.SelectedPath;
            return result == DialogResult.OK;
        }

        private static async Task WriteDataToFileAsync(
            [NotNull] string fileName,
            [NotNull] string fileContent,
            [NotNull] Encoding encoding,
            CancellationToken cancellationToken)
        {
            byte[] dataToSave = encoding.GetBytes(fileContent);

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
        }

        [NotNull]
        private static IEnumerable<IFileNameContainer> CastToIEnumerableIFileNameContainer(
            [NotNull] object objectsToCast) =>
            ((IList)objectsToCast).Cast<IFileNameContainer>();

        [NotNull]
        private static Task<IEnvelope> CreateSignAsync(Encoding encoding, string content, CancellationToken token) =>
            Task.Run(() => CryptoPro.Signer.Sign(new SimpleEnvelope { Data = encoding.GetBytes(content) }), token);

        private async Task SignFilesFuncAsync([NotNull] object objectsToSign, CancellationToken token)
        {
            StopAutoUpdate();

            var errors = new List<Exception>();
            try
            {
                foreach (var selectedItem in CastToIEnumerableIFileNameContainer(objectsToSign))
                    await SignFileAsync(selectedItem, token).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }

            if (errors.Count > 0)
                Log.Error($"Во время подписи произошло ошибок: {errors.Count}");

            StartAutoUpdate();
        }

        private async Task RemoveFilesFuncAsync([NotNull] object grid, CancellationToken token)
        {
            if (!(grid is ISelectable selectable)) return;
            var objectsToRemove = selectable.SelectedItems;

            StopAutoUpdate();

            var errors = new List<Exception>();
            try
            {
                foreach (var selectedItem in CastToIEnumerableIFileNameContainer(objectsToRemove))
                {
                    ((ILocked)selectedItem).IsLocked = true;
                    await RemoveAsync(selectedItem.FileName, token).ConfigureAwait(false);
                }

                selectable.ProcessLocked(objectsToRemove);
            }
            catch (Exception ex)
            {
                errors.Add(ex);
            }

            if (errors.Count > 0)
                Log.Error($"Во время удаления произошло ошибок: {errors.Count}");

            StartAutoUpdate();
        }

        private async Task SaveFilesSafe(
            IEnumerable<IFileNameContainer> filesToSave,
            string path,
            CancellationToken token)
        {
            var errors = new List<Exception>();
            try
            {
                foreach (var selectedItem in filesToSave)
                    await SaveFileAsync(selectedItem, path, token).ConfigureAwait(true);
            }
            catch (Exception e)
            {
                errors.Add(e);
            }

            if (errors.Count > 0)
                Log.Error($"Во время сохранения произошло ошибок: {errors.Count}");
        }

        private void Init()
        {
            SaveFilesAsyncCommand = new CancellableAsyncCommand(SaveFilesFuncAsync);
            SignFilesAsyncCommand = new CancellableAsyncCommand(SignFilesFuncAsync);
            RemoveFilesAsyncCommand = new CancellableAsyncCommand(RemoveFilesFuncAsync);
            OpenFileByFileNameCommand = new CancellableAsyncCommand(OpenFileByFileNameAsync);
            OpenFileByObjectCommand = new CancellableAsyncCommand(OpenFileByObjectAsync);
        }

        private async Task SaveFileAsync(
            [NotNull] IFileNameContainer fileNameContainer,
            [NotNull] string pathToSave,
            CancellationToken token)
        {
            var fileName = fileNameContainer.FileName;

            BusyContent = $"Файл {fileName} загружается";
            var(encoding, content) = await GetContentAsync(fileNameContainer, token).ConfigureAwait(false);

            BusyContent = $"Файл {fileName} сохраняется";
            await WriteDataToFileAsync(Path.Combine(pathToSave, fileName), content, encoding, token)
                .ConfigureAwait(false);
        }

        private async Task SignFileAsync([NotNull] IFileNameContainer fileNameContainer, CancellationToken token)
        {
            var fileName = fileNameContainer.FileName;

            BusyContent = $"Файл {fileName} загружается";
            (Encoding encoding, string content) = await GetContentAsync(fileNameContainer, token).ConfigureAwait(false);

            BusyContent = $"Файл {fileName} подписывается";
            await SendSignAsync(
                fileName,
                (await CreateSignAsync(encoding, content, token).ConfigureAwait(false)).SignData,
                token).ConfigureAwait(false);
        }
    }
}