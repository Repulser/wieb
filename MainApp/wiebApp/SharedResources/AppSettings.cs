using System;
using wieb.ViewModels;

namespace wieb.SharedResources
{
    class AppSettings : NotifyPropertyChanged
    {
        // M A I N   C O L O R S
        public static string _MainColor = "#f92a46";
        public string MainColor
        {
            get { return _MainColor; }
            set
            {
                _MainColor = value;
                OnPropertyChanged();
            }
        }

        public static string _DarkMainColor = "#961A2A";
        public string DarkMainColor
        {
            get { return _DarkMainColor; }
            set
            {
                _DarkMainColor = value;
                OnPropertyChanged();
            }
        }

        //SecondaryColor (mainly dark or light)
        private string _SecondaryColor = "#fcfdff";
        public string SecondaryColor
        {
            get { return _SecondaryColor; }
            set
            {
                _SecondaryColor = value;
                OnPropertyChanged();
            }
        }
        // B A S I C   C O L O R S
        //White
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
        //Gray
        public static string _Gray = "#e8e8e8";
        public string Gray
        {
            get { return _Gray; }
            set
            {
                Gray = value;
                OnPropertyChanged();
            }
        }
        //Black
        public static string _Black = "#e8e8e8";
        public string Black
        {
            get { return _Black; }
            set
            {
                _Black = value;
                OnPropertyChanged();
            }
        }
        // C O L O R S   O F   D O O M
        //B L U E
        //blue
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
        //DarkBlue
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
        //R E D
        //Red
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
        //DarkRed
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
        //Y E L L O W  &  O R A N G E 
        //Yellow
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
        //Ornage
        private static string _Ornage = "#ff9d00";
        public string Ornage
        {
            get { return _Ornage; }
            set
            {
                _Ornage = value;
                OnPropertyChanged();
            }
        }
        //G R E E N
        //Green
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
        //DarkGreen
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
        //LightGreen
        private static string _LightGreen = "#1df441";
        public string LightGreen
        {
            get { return _LightGreen; }
            set
            {
                _Yellow = value;
                OnPropertyChanged();
            }
        }
    }
}
