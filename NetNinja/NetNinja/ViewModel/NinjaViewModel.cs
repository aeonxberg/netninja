using GalaSoft.MvvmLight;
using NetNinjas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.ViewModel
{
    public class NinjaViewModel : ViewModelBase
    {
        //Fill WITH ANY COMMANDS
        private ObservableCollection<NetNinjas.Equipment> _equipmentSet;
        private NetNinjas.Ninja _selectedNinja;
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

        public NetNinjas.Ninja SelectedNinja
        {
            get { return _selectedNinja; }
            set { _selectedNinja = value; RaisePropertyChanged("SelectedNinja"); }
        }




        public string Name{
         get{ return _name; }
          }
         

        public NinjaViewModel(NetNinjas.Ninja ninja)
        {

            _equipmentSet = new ObservableCollection<NetNinjas.Equipment>();
            LoadEquipmentSet();

            _selectedNinja = ninja;
            _name = _selectedNinja.Name;

            // FILL WITH ANY RELAYCOMMANDS

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
