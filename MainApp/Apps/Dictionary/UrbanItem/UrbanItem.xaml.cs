using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UrbanDictionnet;

namespace Dictionary.UrbanItem
{
    /// <summary>
    /// Logique d'interaction pour UrbanItem.xaml
    /// </summary>
    public partial class UrbanItem : UserControl
    {
        public UrbanItem(DefinitionData data)
        {
            InitializeComponent();
            DataContext = new UrbanItemViewModel(data);
        }
    }
}
