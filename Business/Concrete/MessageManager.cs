using Business.Abstract;
using DataAccess.Abstract;
using Simple_Webchat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageRepository _messageRepository;
        public MessageManager(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public void AddMessage(Message message)
        {
            _messageRepository.AddMessage(message);
        }

        public void DeleteMessage(Message message)
        {
            _messageRepository.DeleteMessage(message);
        }

        public Message Detail(int Id)
        {
            return _messageRepository.Detail(Id);
        }

        public async Task GetById(Message Id)
        {
             _messageRepository.GetById(Id);
        }

        public List<Message> GetMessages()
        {
            return _messageRepository.GetMessages();
        }

        public void Update(Message message, int messageId)
        {
            _messageRepository.Update(message,messageId);
        }
    }
}
