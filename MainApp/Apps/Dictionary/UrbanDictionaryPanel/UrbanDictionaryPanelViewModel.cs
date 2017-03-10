using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Dictionary.Annotations;
using Dictionary.UrbanItem;
using UrbanDictionnet;

namespace Dictionary.UrbanDictionaryPanel
{
    class UrbanDictionaryPanelViewModel
    {
        public UrbanDictionaryPanelViewModel()
        {
            BeginSearching = new SearchCommand(this);
        }

        public ObservableCollection<string> Tags { get; private set; } = new ObservableCollection<string>();

        public ObservableCollection<UrbanItem.UrbanItem> Results { get; set; } =
            new ObservableCollection<UrbanItem.UrbanItem>();

        public string SearchBoxText { get; set; }

        public Brush SearchBoxBrush { get; set; }

        public Thickness HowThiccIsTheTextBox { get; set; }

        public SearchCommand BeginSearching { get; }

        private async void OnSearch()
        {
            
        }
        public class SearchCommand : ICommand
        {
            public bool CanExecute(object parameter) => true;
            private UrbanDictionaryPanelViewModel Vm { get; set; }
            private UrbanClient Client { get; set; } = new UrbanClient();
            public SearchCommand(UrbanDictionaryPanelViewModel vm)
            {
                Vm = vm;
            }
            public async void Execute(object parameter)
            {
                if (string.IsNullOrWhiteSpace(Vm.SearchBoxText))
                {
                    Vm.SearchBoxBrush = new SolidColorBrush(Colors.Red);
                    Vm.HowThiccIsTheTextBox = new Thickness(1);
                    return;
                }
                else
                {
                    Vm.HowThiccIsTheTextBox = new Thickness(0);
                }
                Vm.Tags.Clear();
                Vm.Results.Clear();
                try
                {
                    var definition = await Client.GetWordAsync(Vm.SearchBoxText);
                    foreach (var definitionData in definition.List)
                    {
                        Vm.Results.Add(new UrbanItem.UrbanItem(definitionData));
                    }
                    definition.Tags.ForEach(thing => Vm.Tags.Add(thing));
                }
                catch (WordNotFoundException)
                {
                    Vm.Results.Add(new UrbanItem.UrbanItem(new DefinitionData
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
}
