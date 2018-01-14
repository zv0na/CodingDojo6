using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo6.ViewModel
{
    public class MyToysVm : ViewModelBase
    {
        public ObservableCollection<ItemVm> Einkaufswagen { get; set; }

        private Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();


        public MyToysVm()
        {
            Einkaufswagen = new ObservableCollection<ItemVm>();

            messenger.Register<PropertyChangedMessage<ItemVm>>(this, "Write", Update);
        }

        private void Update(PropertyChangedMessage<ItemVm> obj)
        {
            Einkaufswagen.Add(obj.NewValue);
        }
    }
}
