using System;

namespace wiebApp.SharedResources
{
    class AppSettings : NotifyPropertyChanged
    {
        //MainColor
        private string _MainColor = "#FA0953";
        public string MainColor
        {
            get { return _MainColor; }
            set
            {
                value = _MainColor;
                OnPropertyChanged();
            }
        }

        //SecondaryColor (mainly dark or light)
        private string _SecondaryColor = "#fcfdff";
        public string SecondaryColor
        {
            get
            {
                return _SecondaryColor;
            }
            set
            {
                value = _SecondaryColor;
                OnPropertyChanged();
            }
        }
    }
}
