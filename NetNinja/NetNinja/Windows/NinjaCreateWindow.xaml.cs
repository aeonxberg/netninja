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
    /// Interaction logic for NinjaCreateWindow.xaml
    /// </summary>
    public partial class NinjaCreateWindow : Window
    {
        string n;
        public NinjaCreateWindow()
        {
            InitializeComponent();
        }

        private void createNinjaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ninjaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        

        private void ninjaNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            n = ninjaNameBox.Text;            
        }
    }
}
