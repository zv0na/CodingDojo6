/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CodingDojo6"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;

namespace CodingDojo6.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<Messenger>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<OverviewVm>();
            SimpleIoc.Default.Register<MyToysVm>();
            SimpleIoc.Default.Register<MessageBarVm>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public OverviewVm Overview
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OverviewVm>();
            }
        }

        public MyToysVm MyToys
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyToysVm>();
            }
        }

        public MessageBarVm MessageBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessageBarVm>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}