using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ItemVm : ViewModelBase
    {
        public string Bezeichnung { get; set; }
        public string Alter { get; set; }
        public BitmapImage Bild { get; set; }

        public ObservableCollection<ItemVm> Items { get; set; }

        public ItemVm(string bezeichnung, string alter, BitmapImage bild)
        {
            Bezeichnung = bezeichnung;
            Alter = alter;
            Bild = bild;
        }

        internal void AddItem(ItemVm itemVm)
        {
            if (Items == null)
                Items = new ObservableCollection<ItemVm>();

            Items.Add(itemVm);
        }
    }
}
