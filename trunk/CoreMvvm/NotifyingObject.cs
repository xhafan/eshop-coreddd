using System.ComponentModel;

namespace CoreMvvm
{
    // http://stackoverflow.com/a/4717466/379279
    public abstract class NotifyingObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}