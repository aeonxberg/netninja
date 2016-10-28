using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetNinja.Domain;
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

        public ItemCreateViewModel()
        {
            /*
             * this._selectedNinja = SELECTEDNINJA;
             * 
             */
            newItemCommand = new RelayCommand(CreateItemMethod);
            deleteItemCommand = new RelayCommand(DeleteItemMethod);
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
