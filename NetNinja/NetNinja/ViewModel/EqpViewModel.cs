using GalaSoft.MvvmLight;
using NetNinja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.ViewModel
{
    class EqpViewModel : ViewModelBase
    {
        private Equipment _eqp;
        public string Naam
        {
            get { return _eqp.Name; }
            set { _eqp.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Strength
        {
            get { return _eqp.Strength; }
            set { _eqp.Strength = value; RaisePropertyChanged("Strength"); }
        }


        public int Intelligence
        {
            get { return _eqp.Intelligence; }
            set { _eqp.Intelligence = value; RaisePropertyChanged("Intelligence"); }
        }

        public int Agility
        {
            get { return _eqp.Agility; }
            set { _eqp.Agility = value; RaisePropertyChanged("Agility"); }
        }

        public int Price
        {
            get { return _eqp.Price; }
            set { _eqp.Price = value; RaisePropertyChanged("Price"); }
        }

        public string ImageURL
        {
            get { return _eqp.ImageURL; }
            set { _eqp.ImageURL = value; RaisePropertyChanged("ImageURL"); }
        }


        internal CategoryEnum Category
        {
            get { return _eqp.Category; }
            set { _eqp.Category = value; RaisePropertyChanged("Category"); }
        }

        public EqpViewModel(Equipment eqp)
        {
            this._eqp = eqp;
        }

        public EqpViewModel()
        {
            this._eqp = new Equipment();
        }
    }
}
