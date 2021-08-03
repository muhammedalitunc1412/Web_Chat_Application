using Simple_Webchat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IMessageService
    {
        Message Detail(int Id);
        Task GetById(Message Id);

        void AddMessage(Message message);
        List<Message> GetMessages();
        // List<Message> GetMessagesByUserId(int userId);
        void DeleteMessage(Message message);
        void Update(Message message, int messageId);
    }
}
