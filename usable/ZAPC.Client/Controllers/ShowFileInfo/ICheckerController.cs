namespace ZAPC.Client.Controllers.ShowFileInfo
{
    using ZAPC.Documents;

    internal interface ICheckerController<in T> where T : Document<T>
    {
        void Check(T document);
    }
}
