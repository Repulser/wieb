using System.Windows.Controls;
using Dictionary.UrbanItem.ViewModels;
using UrbanDictionnet;

namespace Dictionary.UrbanItem.Views
{
    /// <summary>
    /// Logique d'interaction pour UrbanItem.xaml
    /// </summary>
    public partial class UrbanItemPanel : UserControl
    {
        public UrbanItemPanel()
        {
            InitializeComponent();
        }

        public UrbanItemPanel(DefinitionData data)
        {
            DataContext = new UrbanItemViewModel(data);
        }
    }
}
