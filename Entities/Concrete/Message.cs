using Simple_Webchat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Webchat.Entities.Concrete
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime When { get; set; }
        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }
    }
}
