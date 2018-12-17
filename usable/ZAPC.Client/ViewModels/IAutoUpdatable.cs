namespace ZAPC.Client.ViewModels
{
    internal interface IAutoUpdatable
    {
        void StopAutoUpdate();

        void StartAutoUpdate();
    }
}