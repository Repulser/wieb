namespace wiebApp.ViewModels
{
    public class TabControlProperties : NotifyPropertyChanged
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
    }
}