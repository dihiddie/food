namespace ZAPC.Client.Controllers.ShowFileInfo
{
    using ZAPC.Documents;

    internal interface ICreatorController<out T> where T : Document<T>
    {
        T Create(string fileName);
    }
}
