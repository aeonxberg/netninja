using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetNinja.ViewModel
{
    public class ItemCreateViewModel
    {

        //GET COLLECTION FROM DATABASE
        public ICommand newItemCommand { get; private set; }
        public ICommand deleteItemCommand { get; private set; }
        
        //public Ninja.Domain.Equipment _selectedItem;
        //public ObservableCollection<Ninja.Domain.Equipment> _equipmentList;
        //COLLECTION FOR CATEGORIES? _categoryList;

       
        /*public ObservabeCollection<Ninja.Domain.Equipment> EquipmentList
        {
            get{ return _equipmentList;}
            set{ _equipmentList = value; RaisePropertyChanged("EquipmentList");}
        }
         */

        public ItemCreateViewModel()
        {
            /*
             * this._selectedNinja = SELECTEDNINJA;
             * 
             */
            loadEquipment();
            loadCategories();

            newItemCommand = new RelayCommand(CreateItemMethod);
            deleteItemCommand = new RelayCommand(DeleteItemMethod);
        }

        private void loadCategories()
        {
            //USE DB QUERY TO GET ALL CATEGORIES?
            //Insert each category in _categoryList
            throw new NotImplementedException();
        }

        private void loadEquipment()
        {
            //USE A LOOP TO
            //  Add all equipment from DB to _equipmentList;
            throw new NotImplementedException();
        }

        /* FIELDS ENABLED WHEN NO ITEM SELECTED
         * IF ITEM IS SELECTED FROM COMBOBOX 
         * FILL FIELDS WITH ITEM.<DATA>
         */

        private void DeleteItemMethod()
        {
            /* ONLY ENABLED WHEN ITEM SELECTED FROM COMBOBOX
             * REMOVE ITEM FROM DATABASE HERE
             */ throw new NotImplementedException();
        }

        private void CreateItemMethod()
        {
            /* FIELDS ENABLED WHEN NO ITEM SELECTED
             * ADD ITEM TO DATABASE HERE
             */ throw new NotImplementedException();
        }
    }
}
