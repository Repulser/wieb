using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using Dictionary.Services;
using Dictionary.ViewModels;

namespace Dictionary.Views
{
    /// <summary>
    ///     Interaction logic for UrbanItem.xaml
    /// </summary>
    public partial class UrbanItem : UserControl
    {
        private int _counter;

        public UrbanItem()
        {
            InitializeComponent();
        }

        private void Listen_OnClick(object sender, RoutedEventArgs e)
        {
            var synthesizer = new SpeechSynthesizer();

            if (_counter % 2 == 0)
            {
                new TextToSpeech(UrbanItemViewModel.Instance.Definition,
                    out synthesizer);
            }
            else
            {
                synthesizer.SpeakAsyncCancelAll();
            }

            _counter ++;
        }
    }
}