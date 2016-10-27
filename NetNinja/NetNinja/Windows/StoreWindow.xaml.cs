using NetNinja.Domain;
using NetNinja.Views;
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
    /// Interaction logic for ManageEquipmentWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        CategoryEnum displaySelection;
        public StoreWindow()
        {
            InitializeComponent();
            displaySelection = CategoryEnum.Head;
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void headBtn_Click(object sender, RoutedEventArgs e)
        {
            displaySelection = CategoryEnum.Head;
        }

        private void shoulderBtn_Click(object sender, RoutedEventArgs e)
        {
            displaySelection = CategoryEnum.Shoulders;
        }

        private void chestBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pantsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bootsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> itemNameList = new List<string>();

            foreach (var item in getCollection())
            {
                oldItemNames.Add(item.ToString());
            }

        }

        public CategoryEnum getDisplaySelection()
        {
            return displaySelection;
        }


    }
}
