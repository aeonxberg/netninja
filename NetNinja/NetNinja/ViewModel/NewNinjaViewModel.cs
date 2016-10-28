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
    public class NewNinjaViewModel
    {
        //GET NINJA COLLECTION FROM DATABASE

        public ICommand saveNinjaCommand { get; private set; }
        public ICommand deleteNinjaCommand { get; private set; }

        public NewNinjaViewModel()
        {
            saveNinjaCommand = new RelayCommand(SaveNinjaMethod);
            deleteNinjaCommand = new RelayCommand(DeleteNinjaMethod);
        }

        /* FIELDS ENABLED WHEN NO NINJA SELECTED
         * IF ITEM IS SELECTED FROM COMBOBOX 
         * FILL FIELDS WITH NINJA.<DATA>
         */

        private void SaveNinjaMethod()
        {
            /* IF NINJA SELECTED
             *   UPDATE SELECTEDNINJA
             * ELSE
             *   CREATE NEW NINJA
             */
            throw new NotImplementedException();
        }

        private void DeleteNinjaMethod()
        {
            /* ONLY ENABLED WHEN NINJA IS SELECTED FROM COMBOBOX
             * DELETE SELECTED NINJA
             */
            throw new NotImplementedException();

        }
    }
}
