using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UrbanDictionnet;

namespace Dictionary.UrbanDictionaryPanel
{
    /// <summary>
    ///     Interaction logic for UrbanDicionaryPanel.xaml
    /// </summary>
    public partial class UrbanDictionaryPanel : UserControl
    {
        public UrbanDictionaryPanel()
        {
            this.InitializeComponent();
        }

        /*private UrbanClient Client { get; } = new UrbanClient();
        
        protected async void OnSearch(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                TextBox.BorderThickness = new Thickness(1);
                return;
            }
            else
            {
                TextBox.BorderThickness = new Thickness(0);
            }
            Tags.Items.Clear();
            ResultsBlock.Items.Clear();
            try
            {
                var definition = await Client.GetWordAsync(TextBox.Text);
                foreach (var definitionData in definition.List)
                {
                    ResultsBlock.Items.Add(new UrbanItem.UrbanItem(definitionData));
                }
                definition.Tags.ForEach(thing => Tags.Items.Add(thing));
            }
            catch (WordNotFoundException)
            {
                ResultsBlock.Items.Add(new UrbanItem.UrbanItem(new DefinitionData
                                                               {
                                                                   Author = "You",
                                                                   Definition = "Word not found",
                                                                   Example = "wut ?",
                                                                   Word = "Oops"
                                                               }));
            }
        }*/
    }
}