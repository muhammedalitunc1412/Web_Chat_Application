using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Simple_Webchat.DataAccess.Concrete.EntityFramework.Contexts;
using Simple_Webchat.Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfMessageRepository : IMessageRepository
    {
        public readonly ApplicationDbContext _context;
        public EfMessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMessage(Message message)
        {            
                var addedMessage = _context.Entry(message);
                addedMessage.State = EntityState.Added;
                _context.SaveChanges();             
        }

        public void DeleteMessage(Message message)
        {
            var entity = _context.Entry(message);
            entity.State = EntityState.Deleted;
            _context.SaveChanges();
          
        }

        public Message Detail(int ID)
        {
            return _context.Messages.Where(m => m.Id == ID).FirstOrDefault();
        }

        public async Task GetById(Message Id)
        {
             _context.Set<Message>().Find(Id);
            _context.SaveChanges();
        }

        public List<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }       

        public void Update(Message message, int messageId)
        {
            var product = _context.Messages.Where(m => m.Id == messageId).FirstOrDefault();
            if (product != null)
            {
                product.UserName = message.UserName;
                product.Text = message.Text;
                product.Sender = message.Sender;
            }
            _context.SaveChanges();
        }
    }
}
