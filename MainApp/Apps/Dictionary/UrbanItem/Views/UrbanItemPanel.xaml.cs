using System.Windows;
using System.Windows.Controls;
using Dictionary.UrbanItem.ViewModels;
using Dictionary.ViewModels;
using Dictionary.Services;
using MahApps.Metro.Controls;
using UrbanDictionnet;

namespace Dictionary.UrbanItem.Views
{
    /// <summary>
    /// Logique d'interaction pour UrbanItem.xaml
    /// </summary>
    public partial class UrbanItemPanel : UserControl
    {
        private UrbanItemViewModel _urbanItemViewModel;
        private bool IsChecked;

        public string Title { get; set; }
        public string Definition { get; set; }
        
        public UrbanItemPanel()
        {
            InitializeComponent();
            DataContextChanged += UrbanItemPanel_DataContextChanged;
        }

        public UrbanItemPanel(DefinitionData data)
        {
            //DataContext = new UrbanItemViewModel(data);
        }

        private void UrbanItemPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _urbanItemViewModel = e.NewValue as UrbanItemViewModel;
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            DictionaryAppViewModel.Instance.ResultsView.MoveCurrentToNext();
        }

        private void VoiceButton_Checked(object sender, RoutedEventArgs e)
        {
            IsChecked = true;

            new TextPronouncer().Speak(Title, Definition, IsChecked, 750);
        }

        private void VoiceButton_UnChecked(object sender, RoutedEventArgs e)
        {
            IsChecked = false;
        }
    }
}
