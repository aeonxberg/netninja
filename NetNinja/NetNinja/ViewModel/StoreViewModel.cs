using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using NetNinja.Domain;
using NetNinja.Windows;

namespace NetNinja.ViewModel
{
    public class StoreViewModel : ViewModelBase
    {
        private StoreWindow _storeWindow;
        IEqpRepository eqpRepository;
        public ObservableCollection<EqpViewModel> Eqps { get; set; }
        //The data that gets converted from the model to be used in the view

        private EqpViewModel _selectedItem; //Category or piece of Equipment?

        public EqpViewModel SelectedItem //Category or piece of Equipment?
        {
            get { return _selectedItem; }
            set { _selectedItem = value; base.RaisePropertyChanged(); }
        }

        //Commands?
        public ICommand SwitchCategoryCommand { get; set; }

        public StoreViewModel()
        {
            eqpRepository = new DummyEquipmentRepository();
            var eqpList = eqpRepository.getEqp().Select(eq => new EqpViewModel(eq));
            Eqps = new ObservableCollection<EqpViewModel>(eqpList);

            SwitchCategoryCommand = new RelayCommand(changeCategory);
        }

        private void changeCategory()
        {
            _storeWindow.getDisplaySelection();
            //Change data in listbox?
            
        }

    }
}