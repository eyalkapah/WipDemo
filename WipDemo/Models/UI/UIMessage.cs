using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WipDemo.Enums;

namespace WipDemo.Models.UI
{
    public class UIMessage
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }

        public UIMessage(string message, MessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }
}