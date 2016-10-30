using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetNinja.Windows;
using NetNinjas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetNinja.ViewModel
{
    public class ItemCreateViewModel : ViewModelBase
    {
        //GET COLLECTION FROM DATABASE
        public ICommand newItemCommand { get; private set; }
        public ICommand deleteItemCommand { get; private set; }
        public ICommand backCommand { get; private set; }

        public NetNinjas.Equipment _selectedItem;
        public ObservableCollection<NetNinjas.Equipment> _equipmentList;
        public ObservableCollection<string> _categoryList;


        public ObservableCollection<NetNinjas.Equipment> EquipmentList
        {
            get { return _equipmentList; }
            set { _equipmentList = value; RaisePropertyChanged("EquipmentList"); }
        }

        public ObservableCollection<string> CategoryList
        {
            get { return _categoryList; }
            set { _categoryList = value; RaisePropertyChanged("CategoryList"); }
        }

        public NetNinjas.Equipment SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; RaisePropertyChanged("SelectedItem"); }
        }

        // CONSTRUCTOR
        public ItemCreateViewModel()
        {
            _selectedItem = new Equipment
            {
                Name = "item name",
                Strength = 0,
                Agility = 0,
                Intelligence = 0,
                Price = 0,
                Category = "Head",
                ImageURL = "no image URL"
            };

            _categoryList = new ObservableCollection<string>();
            loadEquipment();
            loadCategories();

            newItemCommand = new RelayCommand(CreateItemMethod);
            deleteItemCommand = new RelayCommand(DeleteItemMethod);
            backCommand = new RelayCommand(BackMethod);
        }

        private void BackMethod()
        {
            StoreWindow storeWindow = new StoreWindow();
            Application.Current.Windows[0].Close();
            storeWindow.Show();
        }

        private void loadCategories()
        {
            /*FILL THE CATEGORY LIST*/
            _categoryList.Add("Head");
            _categoryList.Add("Shoulders");
            _categoryList.Add("Chest");
            _categoryList.Add("Pants");
            _categoryList.Add("Boots");
        }

        private void loadEquipment()
        {
            using (var context = new NetNinjaDatabaseEntities())
                _equipmentList = new ObservableCollection<NetNinjas.Equipment>(context.Equipments);
        }

        /* FIELDS ENABLED WHEN NO ITEM SELECTED
         * IF ITEM IS SELECTED FROM COMBOBOX 
         * FILL FIELDS WITH ITEM.<DATA>
         */

        private void DeleteItemMethod()
        {
            /* ONLY ENABLED WHEN ITEM SELECTED FROM COMBOBOX
             * REMOVE ITEM FROM DATABASE HERE
             */
            if (_selectedItem != null)
            {
                using (var context = new NetNinjas.NetNinjaDatabaseEntities())
                {
                    context.Equipments.Attach(_selectedItem);
                    context.Equipments.Remove(_selectedItem);
                    context.SaveChanges();
                }
                ItemCreateWindow itemCreateWindow = new ItemCreateWindow();
                Application.Current.Windows[0].Close();
                itemCreateWindow.Show();
            }
            else
            {
                MessageBox.Show("No item has been selected for deletion.");
            }

        }


        private void CreateItemMethod()
        {
            /* FIELDS ENABLED WHEN NO ITEM SELECTED
             * ADD ITEM TO DATABASE HERE
             */
            Regex rgx = new Regex("^[0 - 9] +$");

            if (createNewItem())
            {
                using (var context = new NetNinjas.NetNinjaDatabaseEntities())
                {
                    context.Equipments.Add(_selectedItem);
                    context.SaveChanges();
                }
                ItemCreateWindow itemCreateWindow = new ItemCreateWindow();
                Application.Current.Windows[0].Close();
                itemCreateWindow.Show();
            }
            else
            {
                MessageBox.Show("Something went wrong. 3 Or more characters for the name and whole integers for the stats and price.");

            }
        }
        private bool createNewItem()
        {
            Regex rgx = new Regex("^[0 - 9] +$");
            bool createItem = true;

            if (_selectedItem.Name.Length < 3)
                createItem = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(_selectedItem.Strength + "", "^[0 - 9] +$"))
                createItem = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(_selectedItem.Intelligence + "", "^[0 - 9] +$"))
                createItem = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(_selectedItem.Agility + "", "^[0 - 9] +$"))
                createItem = false;
            if (!System.Text.RegularExpressions.Regex.IsMatch(_selectedItem.Price + "", "^[0 - 9] +$"))
                createItem = false;
            if (_selectedItem.Category == null)
                createItem = false;
            return createItem;
        }
    }
}
