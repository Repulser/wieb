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

        private readonly UrbanClient client = new UrbanClient();

        private UrbanClient GetClient()
        {
            return client;
        }

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
            try
            {
                var definition = await GetClient().GetWordAsync(TextBox.Text);
                var sr = new StringBuilder();
                foreach (var thing in definition)
                {
                    sr.AppendLine(thing + "\n -");
                }
                ResultsBlock.Text = sr.ToString();
                definition.Tags.ForEach(thing => Tags.Items.Add(thing));
            }
            catch (WordNotFoundException)
            {
                ResultsBlock.Text = "Word not found";
            }
        }
    }
}