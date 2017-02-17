using System;
using wieb.ViewModels;

namespace wieb.SharedResources
{
    class AppSettings : NotifyPropertyChanged
    {

        public AppSettings()
        {
            _MainColor = _Red;
            _DarkMainColor = _DarkRed;
            _SecondaryColor = _White;
        }

        // /// /// /// /// /// ///
        // M A I N   C O L O RS //
        // /// /// /// /// /// ///
        public static string _MainColor;
        public string MainColor
        {
            get { return _MainColor; }
            set
            {
                _MainColor = value;
                OnPropertyChanged();
            }
        }

        public static string _DarkMainColor;
        public string DarkMainColor
        {
            get { return _DarkMainColor; }
            set
            {
                _DarkMainColor = value;
                OnPropertyChanged();
            }
        }

        // /// /// /// /// /// ///
        // 2 N D     C O L O RS //
        // /// /// /// /// /// ///
        private string _SecondaryColor;
        public string SecondaryColor
        {
            get { return _SecondaryColor; }
            set
            {
                _SecondaryColor = value;
                OnPropertyChanged();
            }
        }

        // /// /// /// /// /// ///
        // W H I T E C O L O RS //
        // /// /// /// /// /// ///
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
        // /// /// /// /// /// ///
        // G R E Y   C O L O RS //
        // /// /// /// /// /// ///
        private static string _Gray = "#e8e8e8";
        public string Gray
        {
            get { return _Gray; }
            set
            {
                Gray = value;
                OnPropertyChanged();
            }
        }
        // /// /// /// /// /// ///
        // B L A C K C O L O RS //
        // /// /// /// /// /// ///
        private static string _Black = "#e8e8e8";
        public string Black
        {
            get { return _Black; }
            set
            {
                _Black = value;
                OnPropertyChanged();
            }
        }
        // /// /// /// /// /// ///
        // B L U E   C O L O RS //
        // /// /// /// /// /// ///
        private static string _Blue = "#2163ce";
        public string Blue
        {
            get { return _Blue; }
            set
            {
                _Blue = value;
                OnPropertyChanged();
            }
        }

        private static string _DarkBlue = "#060647";
        public string DarkBlue
        {
            get { return _DarkBlue; }
            set
            {
                _DarkBlue = value;
                OnPropertyChanged();
            }
        }
        // /// /// /// /// /// ///
        // R E D     C O L O RS //
        // /// /// /// /// /// ///
        private static string _Red = "#f93636";
        public string Red
        {
            get { return _Red; }
            set
            {
                _Red = value;
                OnPropertyChanged();
            }
        }
        
        private static string _DarkRed = "#890f0f";
        public string DarkRed
        {
            get { return _DarkRed; }
            set
            {
                _DarkRed = value;
                OnPropertyChanged();
            }
        }

        // /// /// /// /// /// /////
        // Y E L L O W C O L O RS //
        // /// /// /// /// /// /////
        private static string _Yellow = "#ffdd00";
        public string Yellow
        {
            get { return _Yellow; }
            set
            {
                _Yellow = value;
                OnPropertyChanged();
            }
        }

        private static string _Orange = "#ff9d00";
        public string Orange
        {
            get { return _Orange; }
            set
            {
                _Orange = value;
                OnPropertyChanged();
            }
        }

        // /// /// /// /// /// /////
        // G R E E N   C O L O RS //
        // /// /// /// /// /// /////
        private static string _Green = "#17c617";
        public string Green
        {
            get { return _Green; }
            set
            {
                _Green = value;
                OnPropertyChanged();
            }
        }
        
        private static string _DarkGreen = "#007713";
        public string DarkGreen
        {
            get { return _DarkGreen; }
            set
            {
                _DarkGreen = value;
                OnPropertyChanged();
            }
        }
        
        private static string _LightGreen = "#1df441";
        public string LightGreen
        {
            get { return _LightGreen; }
            set
            {
                _LightGreen = value;
                OnPropertyChanged();
            }
        }
    }
}
