using System;

namespace Food.Client.Interfaces
{
    public delegate void TabClosed(ITabbed sender, EventArgs e);

    public interface ITabbed
    {
        event TabClosed CloseInitiated;

        string UniqueTabName { get; }

        string Title { get; }
    }
}
