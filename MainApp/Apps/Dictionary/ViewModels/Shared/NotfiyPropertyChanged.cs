using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dictionary.Annotations;

namespace Dictionary.ViewModels
{
    public class NotfiyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}