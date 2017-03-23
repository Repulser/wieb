using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using UrbanDictionnet;

namespace Dictionary.ViewModels
{
    public class SearchCommand : ICommand
    {
        public SearchCommand(DictionaryAppViewModel vm)
        {
            Vm = vm;
        }

        private DictionaryAppViewModel Vm { get; }
        private UrbanClient Client { get; } = new UrbanClient();

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(DictionaryAppViewModel.SearchBoxText))
            {
                Vm.SearchBoxBrush = new SolidColorBrush(Colors.Red);
                Vm.TextBoxThickness = new Thickness(1);
                return;
            }

            Vm.TextBoxThickness = new Thickness(0);
            Vm.Tags.Clear();
            Vm.Results.Clear();

            try
            {
                WordDefine definition = await Client.GetWordAsync(DictionaryAppViewModel.SearchBoxText);
                foreach (DefinitionData definitionData in definition.List)
                {
                    Vm.Results.Add(new UrbanItemViewModel(definitionData));
                }

                definition.Tags.ForEach(thing => Vm.Tags.Add(thing));
            }

            catch (WordNotFoundException)
            {
                Vm.Results.Add(new UrbanItemViewModel(new DefinitionData
                {
                    Author = "You",
                    Definition = "Word not found",
                    Example = "wut ?",
                    Word = "Oops"
                }));
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}