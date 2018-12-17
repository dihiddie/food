using ZAPC.Client.Controllers.EDAuthor;

namespace ZAPC.Client.Views.SelectEDAuthor
{
    using System;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Client.Views.PacketEpdListOfFiles;

    public sealed partial class SelectEdAuthorView : ISelectEdAuthorController
    {
        public void EdAuthorSelected()
        {
            PacketEpdListOfFilesView packetEpdFiles = new PacketEpdListOfFilesView();
            packetEpdFiles.Show();

            Close();
        }

        public void EdAuthorsLoadTimeout(double timeoutSeconds)
        {
            MessageBoxLogger.ShowFatalMessage(
                $@"Загрузка данных заняла более {
                        Convert.ToInt32(timeoutSeconds)
                    } секунд. Дальнейшая работа невозможна. Обратитесь к системному администратору.");
            Close();
        }

        public void GetLastError([NotNull] Exception ex) => MessageBoxLogger.ShowErrorMessage(ex.ToString());

        public void NoAvailibleEdAuthors()
        {
            MessageBoxLogger.ShowFatalMessage(
                "Сервер не вернул ни одного уникального идентификатора составителя ЭС. Дальнейшая работа невозможна. Обратитесь к системному администратору.");
            Close();
        }
    }
}
