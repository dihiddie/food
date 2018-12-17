namespace ZAPC.Client.Essentials.Models
{
    using System.Collections.Generic;

    public sealed class ArchiveFilesNamesList
    {
        public IEnumerable<string> IncomingArchiveFilesNames { get; set; }

        public IEnumerable<string> OutgoingArchiveFilesNames { get; set; }
    }
}