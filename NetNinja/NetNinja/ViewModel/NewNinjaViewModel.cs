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
    public class NewNinjaViewModel :ViewModelBase
    {
        private ObservableCollection<NetNinjas.Ninja> _ninjaList;
        private NetNinjas.Ninja c;
        private string _name;

        public ICommand saveNinjaCommand { get; private set; }
        public ICommand deleteNinjaCommand { get; private set; }
       
        public ObservableCollection<NetNinjas.Ninja> NinjaList
        {
            get { return _ninjaList; }
            set { _ninjaList = value; RaisePropertyChanged("NinjaList"); }
        }
        
        public string NinjaName
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("NinjaName"); }
        }
        

        public NewNinjaViewModel()
        {
            loadNinjas();
            saveNinjaCommand = new RelayCommand(SaveNinjaMethod);
            deleteNinjaCommand = new RelayCommand(DeleteNinjaMethod);
        }

        public NewNinjaViewModel(NetNinjas.Ninja c)
        {
            this.c = c;
        }

        private void loadNinjas()
        {
            using (var context = new NetNinjas.NetNinjaDatabaseEntities())
            {
                var compList = context.Ninjas.ToList();
                var compVmList = compList.Select(c => new NewNinjaViewModel(c));
                NinjaList = new ObservableCollection<NetNinjas.Ninja>();
            }
            
        }

        /* FIELDS ENABLED WHEN NO NINJA SELECTED
         * IF ITEM IS SELECTED FROM COMBOBOX 
         * FILL FIELDS WITH NINJA.<DATA>
         */

        private void SaveNinjaMethod()
        {
            Ninja n = new Ninja();
            n.Name = _name;
            n.Agility = Math.Abs(new Random().Next(0, 30));
            n.Intelligence = Math.Abs(new Random().Next(0, 30));
            n.Strength = Math.Abs(new Random().Next(0, 30));
            n.Gold = Math.Abs(new Random().Next(100, 1000));
            Console.WriteLine("Ninja Name: " + n.Name);
            
            using (var context = new NetNinjas.NetNinjaDatabaseEntities())
            {
                context.Ninjas.Add(n);
                context.SaveChanges();
            }
            StoreWindow storeWindow = new StoreWindow();   
            Application.Current.Windows[0].Close();         
            storeWindow.Show();
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
