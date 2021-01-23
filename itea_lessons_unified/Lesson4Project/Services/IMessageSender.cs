using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public interface IMessageSender
    {
        void SendMessage(string addressTo, string messageText);
    }
}
