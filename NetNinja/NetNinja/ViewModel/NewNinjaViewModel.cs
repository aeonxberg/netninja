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
        private string _imageURL;
        private Ninja _selectedNinja;

        public ICommand saveNinjaCommand { get; private set; }
        public ICommand deleteNinjaCommand { get; private set; }
        public ICommand backCommand { get; private set; }
       
        public ObservableCollection<NetNinjas.Ninja> NinjaList
        {
            get { return _ninjaList; }
            set { _ninjaList = value; RaisePropertyChanged("NinjaList"); }
        }
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; RaisePropertyChanged("ImageURL"); }
        }
        public string NinjaName
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("NinjaName"); }
        }
        public Ninja SelectedNinja
        {
            get { return _selectedNinja; }
            set { _selectedNinja = value; RaisePropertyChanged("SelectedNinja"); }
        }
        

        public NewNinjaViewModel()
        {
            loadNinjas();
            saveNinjaCommand = new RelayCommand(SaveNinjaMethod);
            deleteNinjaCommand = new RelayCommand(DeleteNinjaMethod);
            backCommand = new RelayCommand(BackMethod);
        }

        public NewNinjaViewModel(NetNinjas.Ninja c)
        {
            this.c = c;
        }

        private void loadNinjas()
        {
            using (var context = new NetNinjaDatabaseEntities())
                _ninjaList = new ObservableCollection<NetNinjas.Ninja>(context.Ninjas);
        }

        private void BackMethod()
        {
            StoreWindow storeWindow = new StoreWindow();
            Application.Current.Windows[0].Close();
            storeWindow.Show();
        }
        /* FIELDS ENABLED WHEN NO NINJA SELECTED
         * IF ITEM IS SELECTED FROM COMBOBOX 
         * FILL FIELDS WITH NINJA.<DATA>
         */

        private void SaveNinjaMethod()
        {
            bool succeded = true;
            if (_name != null && _imageURL != null)
            {
                
                Ninja n = new Ninja();
                n.Name = _name;
                n.ImageURL = _imageURL;
                n.Agility = 0;
                n.Intelligence = 0;
                n.Strength = 0;
                n.Gold = Math.Abs(new Random().Next(100, 10000));

                foreach(Ninja compareNinja in NinjaList)
                {
                    if(compareNinja.Name == n.Name)
                    {
                        succeded = false;
                        MessageBox.Show("This name already exists, choose a different one.");
                    }
                }
                if (succeded == true)
                {
                    using (var context = new NetNinjas.NetNinjaDatabaseEntities())
                    {
                        context.Ninjas.Add(n);
                        context.SaveChanges();
                    }
                    NinjaCreateWindow ninjaCreateWindow = new NinjaCreateWindow();
                    Application.Current.Windows[0].Close();
                    ninjaCreateWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong. Make sure both values are filled in.");
            }
        }

        private void DeleteNinjaMethod()
        {
            /* ONLY ENABLED WHEN NINJA IS SELECTED FROM COMBOBOX
             * DELETE SELECTED NINJA
             */
            if (_selectedNinja != null)
            {
                using (var context = new NetNinjas.NetNinjaDatabaseEntities())
                {
                    context.Ninjas.Attach(_selectedNinja);
                    context.Ninjas.Remove(_selectedNinja);
                    context.SaveChanges();
                }
                NinjaCreateWindow ninjaCreateWindow = new NinjaCreateWindow();
                Application.Current.Windows[0].Close();
                ninjaCreateWindow.Show();
            }
            else
            {
                MessageBox.Show("Something went wrong. Make sure you select a Ninja to Delete.");
            }
        }
    }
}
