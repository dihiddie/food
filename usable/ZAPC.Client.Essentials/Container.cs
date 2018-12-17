namespace ZAPC.Client.Essentials
{
    using ZAPC.Client.Essentials.Interfaces;

    public static class Container
    {
        public static IServerObjectAsynchronous ServerObject { get; set; }

        public static IArchiveFileCache ArchiveFileCache { get; set; }
    }
}
