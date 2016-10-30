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
        private string _name;

        //DATA BINDING FOR EQUIPMENTSET LABELS AND STUFF

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




        public string Name
        {
            get { return _name; }
        }
         

        public NinjaViewModel(Ninja ninja)
        {
            MessageBox.Show("NinjaViewModel: " + ninja.Name);
            _equipmentSet = new ObservableCollection<NetNinjas.Equipment>();
            LoadEquipmentSet();

            SelectedNinja = ninja;
            _name = _selectedNinja.Name;

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
                _equipmentSet = new ObservableCollection<NetNinjas.Equipment>(context.Equipments);
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
