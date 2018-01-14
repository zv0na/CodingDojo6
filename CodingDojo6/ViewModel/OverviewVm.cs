using CodingDojo6.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class OverviewVm : ViewModelBase
    {
        private Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        public ObservableCollection<ItemVm> Items { get; set; }
        //public ObservableCollection<ItemVm> Einkaufswagen { get; set; }
        private RelayCommand<ItemVm> buyBtn;
        private ItemVm auswahl;


        public ItemVm Auswahl
        {
            get { return auswahl; }
            set { auswahl = value; RaisePropertyChanged(); }
        }

        public RelayCommand<ItemVm> BuyBtn
        {
            get
            {
                return buyBtn;
            }
            set
            {
                buyBtn = value; RaisePropertyChanged();
            }
        }


        public OverviewVm()
        {
            //Einkaufswagen = new ObservableCollection<ItemVm>();
            Items = new ObservableCollection<ItemVm>();

            BuyBtn = new RelayCommand<ItemVm>(TuaDesEinaInsEinkaufsWagal);

            GenerateData();
        }


        private void TuaDesEinaInsEinkaufsWagal(ItemVm obj)
        {
            messenger.Send<PropertyChangedMessage<ItemVm>>(new PropertyChangedMessage<ItemVm>(null, obj, "AddNew"), "Write");

            messenger.Send<PropertyChangedMessage<Message>>(new PropertyChangedMessage<Message>(null, new Message("New Entry Added", MessageState.Info), ""), "@Message");

            //Einkaufswagen.Add(obj);
        }

        private void GenerateData()
        {
            Items.Add(new ItemVm("MY Lego", "", new BitmapImage(new Uri("/Images/lego1.jpg", UriKind.Relative))));
            Items.Add(new ItemVm("MY Playmobil", "", new BitmapImage(new Uri("/Images/playmobil1.jpg", UriKind.Relative))));
                        
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", "5+", new BitmapImage(new Uri("/Images/playmobil2.jpg", UriKind.Relative))));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", "10+", new BitmapImage(new Uri("/Images/playmobil3.jpg", UriKind.Relative))));
            Items[Items.Count - 2].AddItem(
               new ItemVm("Lego 2", "5+", new BitmapImage(new Uri("/Images/lego2.jpg", UriKind.Relative))));
            Items[Items.Count - 2].AddItem(
                new ItemVm("Lego 3", "10+", new BitmapImage(new Uri("/Images/lego3.jpg", UriKind.Relative))));
            Items[Items.Count - 2].AddItem(
               new ItemVm("Lego 4", "15+", new BitmapImage(new Uri("/Images/lego4.jpg", UriKind.Relative))));
        }
    }
}
