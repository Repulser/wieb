using System;
using System.Windows.Input;
using Dictionary.Services;

namespace Dictionary.ViewModels
{
    public class VoiceRecognizeCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var recognizedText = new VoiceRecognizer().VoiceToString();
            DictionaryAppViewModel.SearchBoxText = recognizedText;
        }

        public event EventHandler CanExecuteChanged;
    }
}