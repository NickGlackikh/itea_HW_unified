using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Services.Repositories
{
    public interface IMessageSender
    {
        void SendMessage(string addressTo);
    }
}
