namespace ZAPC.Client.Controllers.EDAuthor
{
    using System;

    public interface ISelectEdAuthorController
    {
        void EdAuthorSelected();

        void EdAuthorsLoadTimeout(double timeoutSeconds);

        void NoAvailibleEdAuthors();

        void GetLastError(Exception ex);
    }
}
