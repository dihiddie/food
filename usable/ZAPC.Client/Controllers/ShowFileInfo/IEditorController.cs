namespace ZAPC.Client.Controllers.ShowFileInfo
{
    using ZAPC.Documents;

    internal interface IEditorController<in T> where T : Document<T>
    {
        void Edit(T document);
    }
}
