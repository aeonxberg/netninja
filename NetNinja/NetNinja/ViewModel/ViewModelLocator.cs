using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NetNinja.ViewModel;

namespace NetNinja.ViewModel
{
    /*
      In App.xaml:
      <Application.Resources>
          <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MusicCollectionMVVMLight.ViewModel"
                                       x:Key="Locator" />
      </Application.Resources>
  
      In the View:
      DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    */
        public class ViewModelLocator
        {
            static ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

                //Hier registreren we een SongListViewModel
                //Waarom doen we dit? Denk hier alvast over na.
                //Het antwoord op deze vraag komt over een tijdje.
                SimpleIoc.Default.Register<StoreViewModel>();

            }

          public StoreViewModel StoreViewModel
            {
                get
                {
                    //De service locator gebruikt een 'singleton' patroon. 
                    //Het maakt niet uit hoevaak je een SongList aanvraagt, je krijgt altijd het zelfde object terug. 
                    return ServiceLocator.Current.GetInstance<StoreViewModel>();
                }
            }
        public ItemCreateViewModel ItemCreateViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ItemCreateViewModel>();
            }
        }

        public EqpViewModel EqpViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EqpViewModel>();
            }
        }

        public NewNinjaViewModel NewNinjaViewModel
        {
            get
            {
                return new NewNinjaViewModel();
            }
        }

        public NinjaViewModel NinjaViewModel
        {
            get
            {
                return new NinjaViewModel(StoreViewModel.SelectedNinja);
            }
        }

        public static void Cleanup()
            {
            }
        }
    }
