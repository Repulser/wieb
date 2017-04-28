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
        private SpeechSynthesizer _synthesizer
            = new SpeechSynthesizer();

        public UrbanItem()
        {
            InitializeComponent();
        }

        private void Listen_OnClick(object sender, RoutedEventArgs e)
        {
            new TextToSpeech(UrbanItemViewModel.Instance.Definition,
                out _synthesizer);
            UrbanItemViewModel.Instance.SelectedTabIndex = 1;
        }

        private void PausePlay_OnClick(object sender, RoutedEventArgs e)
        {
            switch (_synthesizer.State)
            {
                case SynthesizerState.Ready:
                    new TextToSpeech(UrbanItemViewModel.Instance.Definition,
                        out _synthesizer);
                    SetPausePlayIcon("Play");
                    break;

                case SynthesizerState.Speaking:
                    _synthesizer.Pause();
                    SetPausePlayIcon("Pause");
                    break;

                case SynthesizerState.Paused:
                    _synthesizer.Resume();
                    SetPausePlayIcon("Play");
                    break;
            }
        }

        private void SetPausePlayIcon(string icon)
        {
            switch (icon)
            {
                case "Play":
                    UrbanItemViewModel.Instance.PausePlayText = "\xE768";
                    break;

                case "Pause":
                    UrbanItemViewModel.Instance.PausePlayText = "\xE769";
                    break;
            }
        }

        private void Stop_OnClick(object sender, RoutedEventArgs e)
        {
            _synthesizer.Dispose();
        }

        private void ThumbsUp_OnClick(object sender, RoutedEventArgs e)
        {
            UrbanItemViewModel.Instance.Upvotes
        }
    }
}