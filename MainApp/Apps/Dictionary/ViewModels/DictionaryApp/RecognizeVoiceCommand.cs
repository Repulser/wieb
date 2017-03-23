using System;
using System.Windows.Input;
using Dictionary.Services;

namespace Dictionary.ViewModels
{
    public class RecognizeVoiceCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var recognizedText = new VoiceWritter().VoiceToString();
            DictionaryAppViewModel.SearchBoxText = recognizedText;
        }

        public event EventHandler CanExecuteChanged;
    }
}