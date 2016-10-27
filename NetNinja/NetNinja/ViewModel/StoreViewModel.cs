using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using NetNinja.Domain;
using NetNinja.Windows;
using System.ComponentModel;

namespace NetNinja.ViewModel
{
    public class StoreViewModel : ViewModelBase
    {
        private ObservableCollection<Equipment> _equipmentCollection;
        public ICommand headBtnCommand { get; private set; }

        public ObservableCollection<Equipment> EquipmentCollection
        {
            get
            {
                return _equipmentCollection;
            }
            set
            {
                _equipmentCollection = testData();
                RaisePropertyChanged("EquipmentCollection");
            }
        }

        public StoreViewModel()
        {
            headBtnCommand = new RelayCommand(HeadBtnMethod);
        }

/*        public void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(p)); }
        }*/

        private ObservableCollection<Equipment> testData()
        {
            throw new NotImplementedException();
        }

        private void HeadBtnMethod()
        {
            Console.Write("");
        }
    }
}