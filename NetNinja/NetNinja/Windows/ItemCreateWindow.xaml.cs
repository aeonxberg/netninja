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
using System.Windows.Shapes;

namespace NetNinja.Windows
{
    /// <summary>
    /// Interaction logic for ItemCreateWindow.xaml
    /// </summary>
    public partial class ItemCreateWindow : Window
    {
        private System.Collections.ObjectModel.ObservableCollection<Domain.Equipment> _equipmentCollection;

        public ItemCreateWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
