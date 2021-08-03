using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simple_Webchat.DataAccess.Concrete.EntityFramework.Contexts;
using Simple_Webchat.Entities.Concrete;
using Simple_Webchat.WEBUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Webchat.WEBUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminMessageController : Controller
    {
        private IMessageService _messageService;
        public readonly ApplicationDbContext _context;

        public AdminMessageController(IMessageService messageService, ApplicationDbContext context)
        {
            this._messageService = messageService;
            _context = context;

        }
        public IActionResult Index()
        {
            if (User.IsInRole("admin"))
            {

            }
            return View(
               _messageService.GetMessages()
            );
        }
        public IActionResult Delete(Message message)
        {
            _messageService.DeleteMessage(message);
                return RedirectToAction("Index");
          
        }
        public IActionResult Details(int Id)
        {
            return View(
               _messageService.Detail(Id)
            );
        }
    }
}
