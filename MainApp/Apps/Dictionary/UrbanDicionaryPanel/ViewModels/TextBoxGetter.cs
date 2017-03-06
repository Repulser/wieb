using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.UrbanDicionaryPanel.ViewModels
{
    class TextBoxGetter : NotifyPropertyChanged
    {
        private string _textBoxText;

        public string TextBoxText
        {
            get { return _textBoxText; }
            set { _textBoxText = value; }
        }
    }
}
