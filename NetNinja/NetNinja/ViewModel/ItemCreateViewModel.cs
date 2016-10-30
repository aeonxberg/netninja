using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetNinja.Windows;
using NetNinjas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetNinja.ViewModel
{
    public class ItemCreateViewModel : ViewModelBase
    {
        // FIELDS
        private string _name;
        private string _strength;
        private string _intelligence;
        private string _agility;
        private string _price;
        private string _selectedCategory;
        private string _imageURL;

        // PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }
        public string Strength
        {
            get { return _strength; }
            set { _strength = value; RaisePropertyChanged("Strength"); }
        }
        public string Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; RaisePropertyChanged("Intelligence"); }
        }
        public string Agility
        {
            get { return _agility; }
            set { _agility = value; RaisePropertyChanged("Agility"); }
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged("Price"); }
        }
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; RaisePropertyChanged("SelectedCategory"); }
        }
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; RaisePropertyChanged("ImageURL"); }
        }




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


        private void CreateItemMethod()
        {
            /* FIELDS ENABLED WHEN NO ITEM SELECTED
             * ADD ITEM TO DATABASE HERE
             */

            Equipment e = new Equipment();
            e.Name = _name;
            e.Strength = Convert.ToInt32(_strength);
            e.Intelligence = Convert.ToInt32(_intelligence);
            e.Agility = Convert.ToInt32(_agility);
            e.Price = Convert.ToInt32(_price);
            e.Category = _selectedCategory;
            e.ImageURL = _imageURL;

            using (var context = new NetNinjas.NetNinjaDatabaseEntities())
            {
                context.Equipments.Add(e);
                context.SaveChanges();
            }
            ItemCreateWindow itemCreateWindow = new ItemCreateWindow();
            Application.Current.Windows[0].Close();
            itemCreateWindow.Show();

        }
    }
}
