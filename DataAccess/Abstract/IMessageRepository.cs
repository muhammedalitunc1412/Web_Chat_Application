using Simple_Webchat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMessageRepository
    {
        Task GetById(Message Id);
        void AddMessage(Message message);
        List<Message> GetMessages();
        void DeleteMessage(Message message);
        void Update(Message message,int messageId);

        Message Detail(int Id);
    }
}
