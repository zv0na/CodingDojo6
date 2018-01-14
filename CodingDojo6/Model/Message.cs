using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingDojo6.Interface;
using System.Windows.Media.Imaging;

namespace CodingDojo6.Model
{
    public class Message
    {
        public string Text { get; set; }
        public MessageState State { get; set; }

        public Message(string text, MessageState state)
        {
            Text = text;
            State = state;
        }
    }
}