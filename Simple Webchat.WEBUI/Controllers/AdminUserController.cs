using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Simple_Webchat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Webchat.WEBUI.Controllers
{
    [Authorize]
    public class AdminUserController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AdminUserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users);
        }
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }
        [HttpGet]
        public async Task<IActionResult> RoleEdit(IdentityRole ıdentity)
        {
            var roleName = _roleManager.Roles.Where(r => r.Id == ıdentity.Id).FirstOrDefault();

            return View(roleName);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(IdentityRole ıdentity, string Id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(Id);
            role.Name = ıdentity.Name;
            role.Id = ıdentity.Id;
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("RoleList");

        }
        public async Task<IActionResult> RoleDelete(IdentityRole role)
        {
            var role2 = _roleManager.Roles.Where(r => r.Id == role.Id).FirstOrDefault();
            await _roleManager.DeleteAsync(role2);
            return RedirectToAction("RoleList");
        }

        public async Task<IActionResult> UserDelete(AppUser UserId)
        {
            var user = _userManager.Users.Where(u => u.Id == UserId.Id).FirstOrDefault();
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UserDetail(AppUser UserId)
        {
            var user = _userManager.Users.Where(u => u.Id == UserId.Id).FirstOrDefault();
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(AppUser UserId)
        {
            var user = _userManager.Users.Where(u => u.Id == UserId.Id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(AppUser ıdentity, string Id)
        {
            AppUser user = await _userManager.FindByIdAsync(Id);
            user.UserName = ıdentity.UserName;
            user.Email = ıdentity.Email;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");

        }

    }
}
