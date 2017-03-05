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

        private UrbanClient Client { get; } = new UrbanClient();

        protected async void OnSearch(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                TextBox.BorderThickness = new Thickness(1);
            }
            else
            {
                TextBox.BorderThickness = new Thickness(0);
            }
            try
            {
                var definition = await Client.GetWordAsync(TextBox.Text);
                var sr = new StringBuilder();
                foreach (var thing in definition)
                {
                    sr.AppendLine(thing + "\n -");
                }
                ResultsBlock.Text = sr.ToString();
            }
            catch (WordNotFoundException)
            {
                ResultsBlock.Text = "Word not found";
            }
        }
    }
}