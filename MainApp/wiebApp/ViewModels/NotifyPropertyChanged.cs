using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dictionary.Annotations;

namespace wiebApp.ViewModels
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected static void NotifyStaticPropertyChanged([CallerMemberName] string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}