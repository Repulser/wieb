using System;
using wieb.ViewModels;

namespace wieb.SharedResources
{
    class AppSettings : NotifyPropertyChanged
    {
        //MainColor
        public static string _MainColor = "#f92a46";
        public string MainColor
        {
            get { return _MainColor; }
            set
            {
                value = _MainColor;
                OnPropertyChanged();
            }
        }

        public static string _DarkMainColor = "#961A2A";
        public string DarkMainColor
        {
            get { return _DarkMainColor; }
            set
            {
                value = _DarkMainColor;
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

        //WhiteColors.
        public static string _White = "#FFFFFF";
        public string White
        {
            get { return _White; }
            set
            {
                _White = value;
                OnPropertyChanged();
            }
        }

        public static string _DarkWhite;
        public string DarkWhite
        {
            get { return _DarkWhite; }
            set
            {
                _DarkWhite = value;
                OnPropertyChanged();
            }
        }
    }
}
