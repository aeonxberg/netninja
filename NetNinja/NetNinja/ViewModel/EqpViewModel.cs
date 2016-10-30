using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNinja.ViewModel
{
    public class EqpViewModel : ViewModelBase
    {
        private NetNinjas.Equipment _eqp;
        public string Naam
        {
            get { return _eqp.Name; }
            set { _eqp.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Strength
        {
            get { return  (int) _eqp.Strength; } //CAST MOETEN WE OPLOSSEN
            set { _eqp.Strength = value; RaisePropertyChanged("Strength"); }
        }


        public int Intelligence
        {
            get { return (int) _eqp.Intelligence; }
            set { _eqp.Intelligence = value; RaisePropertyChanged("Intelligence"); }
        }

        public int Agility
        {
            get { return (int) _eqp.Agility; }
            set { _eqp.Agility = value; RaisePropertyChanged("Agility"); }
        }

        public int Price
        {
            get { return (int) _eqp.Price; }
            set { _eqp.Price = value; RaisePropertyChanged("Price"); }
        }

        public string ImageURL
        {
            get { return _eqp.ImageURL; }
            set { _eqp.ImageURL = value; RaisePropertyChanged("ImageURL"); }
        }


        public string Category
        {
            get { return _eqp.Category; }
            set { _eqp.Category = value; RaisePropertyChanged("Category"); }
        }

        public EqpViewModel(NetNinjas.Equipment eqp)
        {
            this._eqp = eqp;
        }

        public EqpViewModel()
        {
            this._eqp = new NetNinjas.Equipment();
        }
    }
}
