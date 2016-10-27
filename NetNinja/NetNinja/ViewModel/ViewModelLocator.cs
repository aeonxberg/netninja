using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NetNinja.ViewModel;

namespace NetNinja.Views
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

          public StoreViewModel EquipmentList
            {
                get
                {
                    //De service locator gebruikt een 'singleton' patroon. 
                    //Het maakt niet uit hoevaak je een SongList aanvraagt, je krijgt altijd het zelfde object terug. 
                    return ServiceLocator.Current.GetInstance<StoreViewModel>();
                }
            }

 /*           public AddSongViewModel AddSong
            {
                get
                {
                    //De service locator gebruikt een 'singleton' patroon. 
                    //Het maakt niet uit hoevaak je een SongList aanvraagt, je krijgt altijd het zelfde object terug. 
                    return new AddSongViewModel(this.SongList);
                }
            }

            public UpdateSongViewModel UpdateSong
            {
                get
                {
                    //Hmmm... Wat moeten we hier nu returnen? Denk er maar eens goed over na!
                    return null;
                }
            }
  */
            public static void Cleanup()
            {
            }
        }
    }
