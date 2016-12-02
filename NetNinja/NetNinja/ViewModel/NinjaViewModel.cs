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
    public class NinjaViewModel : ViewModelBase
    {
        //Fill WITH ANY COMMANDS
        public ICommand backCommand { get; private set; }
        private ObservableCollection<NetNinjas.Equipment> _equipmentSet;
        private Ninja _selectedNinja;
        private Equipment _ninjaHead;
        private Equipment _ninjaShoulders;
        private Equipment _ninjaChest;
        private Equipment _ninjaPants;
        private Equipment _ninjaBoots;

        //DATA BINDING FOR EQUIPMENTSET LABELS AND STUFF
        private string _name;
        private int _totStr;
        private int _totInt;
        private int _totAgl;
        private int _totGold;

        public ObservableCollection<NetNinjas.Equipment> EquipmentSet
        {
            get { return _equipmentSet; }
            set
            {
                _equipmentSet = value;
                RaisePropertyChanged("EquipmentSet");
            }
        }

        public Ninja SelectedNinja
        {
            get { return _selectedNinja; }
            set { _selectedNinja = value; RaisePropertyChanged("SelectedNinja"); }
        }

        public Equipment NinjaHead
        {
            get { return _ninjaHead; }
            set { _ninjaHead = value; RaisePropertyChanged("NinjaHead"); }
        }
        public Equipment NinjaShoulders
        {
            get { return _ninjaShoulders; }
            set { _ninjaShoulders = value; RaisePropertyChanged("NinjaShoulders"); }
        }
        public Equipment NinjaChest
        {
            get { return _ninjaChest; }
            set { _ninjaChest = value; RaisePropertyChanged("NinjaChest"); }
        }
        public Equipment NinjaPants
        {
            get { return _ninjaPants; }
            set { _ninjaPants = value; RaisePropertyChanged("NinjaPants"); }
        }
        public Equipment NinjaBoots
        {
            get { return _ninjaBoots; }
            set { _ninjaBoots = value; RaisePropertyChanged("NinjaBoots"); }
        }

        public string Name
        {
            get { return _name; }
        }

        public int TotalStr
        {
            get { return _totStr; }
        }
        public int TotalInt
        {
            get { return _totInt; }
        }
        public int TotalAgl
        {
            get { return _totAgl; }
        }
        public int TotalGold
        {
            get { return _totGold; }
        }


        public NinjaViewModel(Ninja ninja)
        {
            _equipmentSet = new ObservableCollection<Equipment>();
            LoadEquipmentSet();

            SelectedNinja = ninja;
            _name = SelectedNinja.Name;

            // FILL WITH ANY RELAYCOMMANDS
            backCommand = new RelayCommand(BackMethod);

        }

        private void BackMethod()
        {
            StoreWindow storeWindow = new StoreWindow();
            Application.Current.Windows[0].Close();
            storeWindow.Show();
        }

        private void LoadEquipmentSet()
        {
            using (var context = new NetNinjaDatabaseEntities())
            {
                _equipmentSet = new ObservableCollection<NetNinjas.Equipment>(context.Equipments);

            }

            foreach(Equipment eqpItem in _equipmentSet)
            {
                switch (eqpItem.Category.ToLower())
                {
                    case "head":
                        NinjaHead = eqpItem;
                        break;
                    case "shoulders":
                        NinjaShoulders = eqpItem;
                        break;
                    case "chest":
                        NinjaChest = eqpItem;
                        break;
                    case "pants":
                        NinjaPants = eqpItem;
                        break;
                    case "boots":
                        NinjaBoots = eqpItem;
                        break;
                }
            }
        }

        /* private void LoadEquipmentSet(){
         * USE A LOOP TO FILL _equipmentSet WITH Equipment FROM selected ninja
         * _equipmentSet = new ObservableCollection<Ninja.Domain.Equipment>();
         */

        /*       public NetNinjas.Ninja SelectedNinja
               {
                   get { return _selectedNinja; }
                   set { _selectedNinja = value; }
               }
         * 
         */


        /* CREATE ANY BUTTON-METHODS
         *
         */
    }
}
