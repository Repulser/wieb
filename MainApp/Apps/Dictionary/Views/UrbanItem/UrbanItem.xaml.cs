using System;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
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

        private void Thumbs_OnClick(object sender, RoutedEventArgs e)
        {
            //add rectangle forreach togglebutton and bind fill to the property in vm
            var s = sender as ToggleButton;
            UrbanItemViewModel vm = UrbanItemViewModel.Instance;
            if (s?.Name == "ThumbsUp")
            {
                if (vm != null)
                {
                    var isDisabled = vm.ThumbsUpIsChecked == false;
                    var color = isDisabled ? Colors.DarkGray
                        : Colors.Transparent;
                    vm.ThumbsUpFill.Color = color;
                }
            }
            else
            {
                if (vm != null)
                {
                        vm.ThumbsUpFill.Color
                                        = vm.ThumbsUpIsChecked == false
                                            ? Colors.DarkGray
                                            : Colors.Transparent;
                }
            }
        }
    }
}