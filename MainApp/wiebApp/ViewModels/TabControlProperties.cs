namespace wiebApp.ViewModels
{
    public class TabControlProperties : NotifyPropertyChanged
    {
        private static int _tabControlIndex;

        public static int TabControlIndex
        {
            get { return _tabControlIndex; }
            set
            {
                _tabControlIndex = value;
                NotifyStaticPropertyChanged();
            }
        }
    }
}