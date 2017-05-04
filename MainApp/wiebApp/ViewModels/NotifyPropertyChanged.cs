using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dictionary.Properties;

namespace wiebApp.ViewModels
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected static void OnStaticPropertyChanged([CallerMemberName] string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}