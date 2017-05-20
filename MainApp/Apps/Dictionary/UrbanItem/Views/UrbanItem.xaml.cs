using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using Dictionary.Services;
using Dictionary.ViewModels;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using UrbanDictionnet;

namespace Dictionary.Views
{
    /// <summary>
    ///     Interaction logic for UrbanItem.xaml
    /// </summary>
    public partial class UrbanItem : UserControl
    {
        private readonly UrbanItemViewModel _vm;

        private SpeechSynthesizer _synthesizer
            = new SpeechSynthesizer();

        public UrbanItem()
        {
            InitializeComponent();
            _vm = UrbanItemViewModel.Instance;
        }

        private void Listen_OnClick(object sender, RoutedEventArgs e)
        {
            var tts = new TextToSpeech(_vm.Definition,
                out _synthesizer);
            _vm.SelectedTabIndex = 1;
        }

        private void PausePlay_OnClick(object sender, RoutedEventArgs e)
        {
            switch (_synthesizer.State)
            {
                case SynthesizerState.Ready:
                    new TextToSpeech(_vm.Definition,
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
                    _vm.PausePlayText = "\xE768";
                    break;

                case "Pause":
                    _vm.PausePlayText = "\xE769";
                    break;
            }
        }

        private void Stop_OnClick(object sender, RoutedEventArgs e)
        {
            _synthesizer.Dispose();
        }

        private void ThumbsUp_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.Like();
        }

        private void ThumbsDown_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.Dislike();
        }

        private void Translate_OnClick(object sender, RoutedEventArgs e)
        {
            PhantomJSDriver driver = null;
            driver = (PhantomJSDriver) SeleniumTranslate.Factory(driver);

            var seleniumTranslate = InitializeLanguages(driver);

            var definitionData = CreateDefinitionData(seleniumTranslate,
                (SeleniumTranslate.Languages) _vm.Languages.CurrentItem, driver);

            DictionaryAppViewModel.Instance.Results.Add(new UrbanItemViewModel(definitionData));
        }

        private SeleniumTranslate InitializeLanguages(RemoteWebDriver driver)
        {
            var def = _vm.Definition;
            var seleniumTranslate = new SeleniumTranslate();
            var lang = seleniumTranslate.Detect(def.ToString(), driver);
            _vm.Languages.Remove(lang);
            return seleniumTranslate;
        }

        private DefinitionData CreateDefinitionData(
            SeleniumTranslate seleniumTranslate, SeleniumTranslate.Languages language, PhantomJSDriver driver)
        {
            var translatedDef = seleniumTranslate.Translate(_vm.DefinitionString, language, driver);
            var translatedWord = seleniumTranslate.Translate(_vm.Title, language, driver);
            var translatedExample = seleniumTranslate.Translate(_vm.Example, language, driver);
            var translatedAuthor = seleniumTranslate.Translate(_vm.Author, language, driver);

            var translatedDefData = new DefinitionData
            {
                Definition = translatedDef,
                Word = translatedWord,
                Example = translatedExample,
                Author = translatedAuthor,
                ThumbsUp = _vm.Upvotes,
                ThumbsDown = _vm.Downvotes
            };

            return translatedDefData;
        }
    }
}