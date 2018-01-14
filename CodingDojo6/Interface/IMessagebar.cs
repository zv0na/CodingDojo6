using CodingDojo6.Model;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo6.Interface
{
    public interface IMessagebar
    {
        void RegisterOnMessenger(Messenger messanger, string token);
        void SetDisplayTime(int time);
        void ShowInfo(Message msg);
    }


}
