using System;
using System.Threading.Tasks;
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (SearchPreparations())
            {
                return;
            }

            try
            {
                await Search();
            }

            catch (WordNotFoundException)
            {
                FailSearch();
            }
        }

        private void FailSearch()
        {
            Vm.Results.Add(new UrbanItemViewModel(new DefinitionData
            {
                Author = "You",
                Definition = "Word not found",
                Example = "wut ?",
                Word = "Oops"
            }));
        }

        private async Task Search()
        {
            WordDefine definition = await new UrbanClient().GetWordAsync(DictionaryAppViewModel.SearchBoxText);
            foreach (DefinitionData definitionData in definition.List)
            {
                Vm.Results.Add(new UrbanItemViewModel(definitionData));
            }

            definition.Tags.ForEach(thing => Vm.Tags.Add(thing));
        }

        private bool SearchPreparations()
        {
            if (string.IsNullOrWhiteSpace(DictionaryAppViewModel.SearchBoxText))
            {
                Vm.SearchBoxBrush = new SolidColorBrush(Colors.Red);
                Vm.TextBoxThickness = new Thickness(1);
                return true;
            }

            Vm.TextBoxThickness = new Thickness(0);
            Vm.Tags.Clear();
            Vm.Results.Clear();
            return false;
        }

        public event EventHandler CanExecuteChanged;
    }
}