using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetNinja.Domain;
//using NetNinjas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetNinja.ViewModel
{
    public class NewNinjaViewModel :ViewModelBase
    {
        private ObservableCollection<Ninja> _ninjaList;

        public ICommand saveNinjaCommand { get; private set; }
        public ICommand deleteNinjaCommand { get; private set; }
       
        public ObservableCollection<Ninja> NinjaList
        {
            get { return _ninjaList; }
            set { _ninjaList = value; RaisePropertyChanged("NinjaList"); }
        }
        

        public NewNinjaViewModel()
        {
            loadNinjas();
            saveNinjaCommand = new RelayCommand(SaveNinjaMethod);
            deleteNinjaCommand = new RelayCommand(DeleteNinjaMethod);
        }

        private void loadNinjas()
        {
            
            // Als die using Netninja.Domain nou eens werkt, kunnen we dit verder uitwerken
            
            //using (var context = new DatabaseContext())
            //{
               
            //    var compList = context.Competitions
            //       .Include("Teams")
            //       .OrderByDescending(c => c.Date)
            //       .ToList();
            //    var compVmList = compList.Select(c => new CompetitionViewModel(c));
            //    Competitions = new ObservableCollection<CompetitionViewModel>(compVmList);
                
            //}
            

            // Nee geen loop, zie hier boven
            //USE A LOOP TO
            // Get all Ninjas FROM DB and insert them in _ninjaList;
            throw new NotImplementedException();
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
