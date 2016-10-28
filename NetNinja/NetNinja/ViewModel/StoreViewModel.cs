using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using NetNinja.Domain;
using NetNinja.Windows;
using System.ComponentModel;

namespace NetNinja.ViewModel
{
    public class StoreViewModel : ViewModelBase
    {
        private ObservableCollection<Equipment> _equipmentCollection;
        public ICommand headBtnCommand { get; private set; }
        public ICommand shoulderBtnCommand { get; private set; }
        public ICommand chestBtnCommand { get; private set; }
        public ICommand pantsBtnCommand { get; private set; }
        public ICommand bootsBtnCommand { get; private set; }
        public ICommand newItemCommand { get; private set; }
        public ICommand showNinjaCommand { get; private set; }
        public ICommand newNinjaCommand { get; private set; }

        CategoryEnum displayCategory = CategoryEnum.Head;
        Equipment displayItem;

        public ObservableCollection<Equipment> EquipmentCollection
        {
            get
            {
                return _equipmentCollection;
            }
            set
            {
                RaisePropertyChanged("EquipmentCollection");
            }
        }

        public StoreViewModel(/*<DOMAIN> SELECTEDNINJA*/)
        {
            /*
             * this._selectedNinja = SELECTEDNINJA;
             */

            _equipmentCollection = new ObservableCollection<Equipment/*FROM DOMAIN*/>();
            loadStoreItems();

            headBtnCommand = new RelayCommand(HeadBtnMethod);
            shoulderBtnCommand = new RelayCommand(ShoulderBtnMethod);
            chestBtnCommand = new RelayCommand(ChestBtnMethod);
            pantsBtnCommand = new RelayCommand(PantsBtnMethod);
            bootsBtnCommand = new RelayCommand(BootsBtnMethod);
            newItemCommand = new RelayCommand(OpenItemCreator);
            showNinjaCommand = new RelayCommand(OpenNinjaDisplay);
            newNinjaCommand = new RelayCommand(OpenNewNinjaDisplay);
        }

        private void OpenNewNinjaDisplay()
        {
            NinjaCreateWindow ninjaCreateWindow = new NinjaCreateWindow();
            ninjaCreateWindow.Show();
        }

        private void OpenNinjaDisplay()
        {
            NinjaWindow displayWindow = new NinjaWindow();
            displayWindow.Show();
        }

        private void OpenItemCreator()
        {
            ItemCreateWindow createWindow = new ItemCreateWindow();
            createWindow.Show();
        }

        private void loadStoreItems()
        {
            /*
              using (var context = new NinjaDBContainer())
              {
                  _equipmentCollection = new ObservableCollection<DOMAIN EQUIPMENT>(context. EQUIPMENT SET);
              }
            */
        }

        public Boolean CanBuy
        {
            get { return _canBuy; }
            set
            {
                if (value)
                {
                    if (CheckCanBuy())
                    {
                        _canBuy = value;
                        RaisePropertyChanged("CanBuy");
                    }

                }
                else if (!value)
                {
                    _canBuy = value;
                    RaisePropertyChanged("CanBuy");
                }
            }
        }

        private bool CheckCanBuy()
        {
            /*           if (SelectedItem.Price <= 500)
                       {
                           return true;
                       }
                       return false; */
            return true;
        }

        public Equipment SelectedItem
        {
            get { return displayItem; }
            set { displayItem = value; RaisePropertyChanged("SelectedItem"); CanBuy = true; }
        }

        private void HeadBtnMethod()
        {
            displayCategory = CategoryEnum.Head;
            testData();
            displayCorrectItems();
        }

        private void BootsBtnMethod()
        {
            displayCategory = CategoryEnum.Boots;
            displayCorrectItems();
        }

        private void PantsBtnMethod()
        {
            displayCategory = CategoryEnum.Pants;
            displayCorrectItems();
        }

        private void ChestBtnMethod()
        {
            displayCategory = CategoryEnum.Chest;
            testData();
            displayCorrectItems();
        }

        private void ShoulderBtnMethod()
        {
            displayCategory = CategoryEnum.Shoulders;
            displayCorrectItems();
        }

        private void displayCorrectItems()
        {
            //Filter collection to only show correct category
            ObservableCollection<Equipment> categorizedCollection = new ObservableCollection<Equipment>();
            loadStoreItems();


            /*Use a loop to add the items with 
             *  category is displayCategory(might have to change from enum to string, or use switch to get string)
             */
            EquipmentCollection = categorizedCollection;



            /*       USE THE FOLLOWING TO MAKE displayCorrectItems();
             private void SelectCorrectCategory()
             {
                 ObservableCollection<Ninja.Domain.Gear> _newList = new ObservableCollection<Ninja.Domain.Gear>();

                 //Get the list from the Database
                 LoadShopItems();

                 foreach (var item in _gearList)
                 {
                     if (item.Category.Equals(_selectedGearCategory))
                     {
                         _newList.Add(item);
                     }
                 }
                GearList = _newList;
             }
                  */
        }

        private ObservableCollection<Equipment> testData()
        {
            _equipmentCollection.Clear();
            if (displayCategory == CategoryEnum.Head)
            {
                _equipmentCollection.Add(new Equipment
                {
                    Name = "testHead",
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 10,
                    Category = CategoryEnum.Head,
                    ImageURL = null,
                    Price = 500
                });
            }
            else if (displayCategory == CategoryEnum.Chest)
            {
                _equipmentCollection.Add(new Equipment
                {
                    Name = "testChest",
                    Strength = 0,
                    Intelligence = 10,
                    Agility = -10,
                    Category = CategoryEnum.Head,
                    ImageURL = null,
                    Price = 100
                });
                _equipmentCollection.Add(new Equipment
                {
                    Name = "Weighted Chest",
                    Strength = 44,
                    Intelligence = -44,
                    Agility = -22,
                    Category = CategoryEnum.Head,
                    ImageURL = null,
                    Price = 1000
                });
            }
            return _equipmentCollection;
        }

        public bool _canBuy { get; set; }

    }
}