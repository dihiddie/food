using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ZAPC.Client.ViewModels
{
    using JetBrains.Annotations;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CanBeNull] [CallerMemberName] string propertyName = null)
        {
            Volatile.Read(ref PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
