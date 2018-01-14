using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;

namespace CodingDojo6.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        //public ObservableCollection<ItemVm> Items { get; set; }

        public RelayCommand OverviewBtn { get; set; }
        public RelayCommand MyToysBtn { get; set; }


        private ViewModelBase currentVm;

        public ViewModelBase CurrentVm
        {
            get { return currentVm; }
            set { currentVm = value; RaisePropertyChanged(); }
        }


        public MainViewModel()
        {
            //Items = new ObservableCollection<ItemVm>();

            CurrentVm = SimpleIoc.Default.GetInstance<OverviewVm>();

            OverviewBtn = new RelayCommand(GehZuOverview);
            MyToysBtn = new RelayCommand(GehZuToys);

            (App.Current.Resources["Locator"] as ViewModelLocator).MessageBar.RegisterOnMessenger(SimpleIoc.Default.GetInstance<Messenger>(), "@Message");


        }
                
        private void GehZuToys()
        {
            CurrentVm = SimpleIoc.Default.GetInstance<MyToysVm>();
        }

        private void GehZuOverview()
        {
            CurrentVm = SimpleIoc.Default.GetInstance<OverviewVm>();
        }
    }
}