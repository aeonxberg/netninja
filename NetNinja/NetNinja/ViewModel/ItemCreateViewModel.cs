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
    class ItemCreateViewModel
    {

        //GET COLLECTION FROM DATABASE
        public ICommand newItemCommand { get; private set; }
        public ItemCreateViewModel()
        {
            /*this._selectedNinja = SELECTEDNINJA;
             * 
             * 
             */
            newItemCommand = new RelayCommand(CreateItemMethod);
        }

        private void CreateItemMethod()
        {
            //ADD ITEM TO DATABASE HERE
            throw new NotImplementedException();
        }
    }
}
