using System.Windows;

namespace wiebApp.ViewModels
{
    public class TabProperties : NotifyPropertyChanged
    {
        private int _tabControlIndex;

        public int TabControlIndex
        {
            get { return _tabControlIndex; }
            set
            {
                _tabControlIndex = value;
                OnPropertyChanged();
            }
        }

        private Visibility _backButtonVisibility = Visibility.Collapsed;

        public Visibility BackButtonVisibility
        {
            get { return _backButtonVisibility; }
            set
            {
                _backButtonVisibility = value;
                OnPropertyChanged();
            }
        }
    }
}