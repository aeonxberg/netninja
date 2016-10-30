﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using NetNinja.Windows;
using System.ComponentModel;
using NetNinjas;
using System.Windows;

namespace NetNinja.ViewModel
{
    public class StoreViewModel : ViewModelBase
    {
        private ObservableCollection<NetNinjas.Equipment> _equipmentCollection;
        private ObservableCollection<NetNinjas.Ninja> _ninjaCollection;

        public ICommand headBtnCommand { get; private set; }
        public ICommand shoulderBtnCommand { get; private set; }
        public ICommand chestBtnCommand { get; private set; }
        public ICommand pantsBtnCommand { get; private set; }
        public ICommand bootsBtnCommand { get; private set; }
        public ICommand newItemCommand { get; private set; }
        public ICommand showNinjaCommand { get; private set; }
        public ICommand newNinjaCommand { get; private set; }
        public ICommand refreshCommand { get; private set; }

        string displayCategory = null;
        NetNinjas.Equipment displayItem;
        NetNinjas.Ninja _selectedNinja;
        bool btnEnabled = false;

        public bool ButtonEnabled
        {
            get
            {
                return btnEnabled;
            }
            set
            {
                RaisePropertyChanged("btnEnabled");
            }
        }

        public ObservableCollection<NetNinjas.Equipment> EquipmentCollection
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

        public ObservableCollection<NetNinjas.Ninja> NinjaCollection
        {
            get
            {
                return _ninjaCollection;
            }
            set
            {
                RaisePropertyChanged("NinjaCollection");
            }
        }

        public StoreViewModel(/*NetNinjas.Ninja selectedNinja*/)
        {
          
            _equipmentCollection = new ObservableCollection<NetNinjas.Equipment>();
            _ninjaCollection = new ObservableCollection<NetNinjas.Ninja>();
            loadStoreItems();
            loadNinjas();

            headBtnCommand = new RelayCommand(HeadBtnMethod);
            shoulderBtnCommand = new RelayCommand(ShoulderBtnMethod);
            chestBtnCommand = new RelayCommand(ChestBtnMethod);
            pantsBtnCommand = new RelayCommand(PantsBtnMethod);
            bootsBtnCommand = new RelayCommand(BootsBtnMethod);
            newItemCommand = new RelayCommand(OpenItemCreator);
            showNinjaCommand = new RelayCommand(OpenNinjaDisplay);
            newNinjaCommand = new RelayCommand(OpenNewNinjaDisplay);
            refreshCommand = new RelayCommand(RefreshMethod);

        }

        private void RefreshMethod()
        {
            loadNinjas();
        }

        private void loadStoreItems()
        {
            using (var context = new NetNinjaDatabaseEntities())
                _equipmentCollection = new ObservableCollection<NetNinjas.Equipment>(context.Equipments);//ERROR
        }

        private void loadNinjas()
        {
           using (var context = new NetNinjaDatabaseEntities())
               _ninjaCollection = new ObservableCollection<NetNinjas.Ninja>(context.Ninjas);//ERROR
        }

        private void OpenNewNinjaDisplay()
        {
            NinjaCreateWindow ninjaCreateWindow = new NinjaCreateWindow();
            Application.Current.Windows[0].Close();
            ninjaCreateWindow.Show();
        }

        private void OpenNinjaDisplay()
        {
            NinjaWindow displayWindow = new NinjaWindow();
            Application.Current.Windows[0].Close();
            displayWindow.Show();
        }

        private void OpenItemCreator()
        {
            ItemCreateWindow createWindow = new ItemCreateWindow();
            Application.Current.Windows[0].Close();
            createWindow.Show();
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

        public NetNinjas.Equipment SelectedItem
        {
            get { return displayItem; }
            set { displayItem = value; RaisePropertyChanged("SelectedItem"); CanBuy = true; }
        }

        public NetNinjas.Ninja SelectedNinja
        {
            get { return _selectedNinja; }
            set { _selectedNinja = value; RaisePropertyChanged("SelectedNinja"); }
        }

        private void switchButtonState(Ninja _selectedNinja)
        {
            if (_selectedNinja != null)
            {
                btnEnabled = true;
            }
            else
            {
                btnEnabled = false;
            }
        }

        private void HeadBtnMethod()
        {
            displayCategory = "Head";
            testData();
            displayCorrectItems();
        }

        private void BootsBtnMethod()
        {
            displayCategory = "Boots";
            displayCorrectItems();
        }

        private void PantsBtnMethod()
        {
            displayCategory = "Pants";
            displayCorrectItems();
        }

        private void ChestBtnMethod()
        {
            displayCategory = "Chest";
            testData();
            displayCorrectItems();
        }

        private void ShoulderBtnMethod()
        {
            displayCategory = "Shoulders";
            displayCorrectItems();
        }

        private void displayCorrectItems()
        {
            //Filter collection to only show correct category
            ObservableCollection<NetNinjas.Equipment> categorizedCollection = new ObservableCollection<NetNinjas.Equipment>();
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

        private ObservableCollection<NetNinjas.Equipment> testData()
        {
            _equipmentCollection.Clear();
            if (displayCategory.Equals("Head"))
            {
                _equipmentCollection.Add(new NetNinjas.Equipment
                {
                    Name = "testHead",
                    Strength = 10,
                    Intelligence = 10,
                    Agility = 10,
                    Category = "Head",
                    ImageURL = null,
                    Price = 500
                });
            }
            else if (displayCategory.Equals("Chest"))
            {
                _equipmentCollection.Add(new NetNinjas.Equipment
                {
                    Name = "testChest",
                    Strength = 0,
                    Intelligence = 10,
                    Agility = -10,
                    Category = "Head",
                    ImageURL = null,
                    Price = 100
                });
                _equipmentCollection.Add(new NetNinjas.Equipment
                {
                    Name = "Weighted Chest",
                    Strength = 44,
                    Intelligence = -44,
                    Agility = -22,
                    Category = "Head",
                    ImageURL = null,
                    Price = 1000
                });
            }
            return _equipmentCollection;
        }

        public bool _canBuy { get; set; }

    }
}