﻿using NetNinja.ViewModel;
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
        string displaySelection;
        public StoreWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void shoulderBtn_Click(object sender, RoutedEventArgs e)
        {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void headBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void showNinjaBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ninjaSelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
