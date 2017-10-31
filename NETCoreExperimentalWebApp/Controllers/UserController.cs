using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NETCoreExperimentalWebApp.Models;

namespace NETCoreExperimentalWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        public ActionResult ResetPassword(string id)
        {
            return View(_userManager.Users
                            .Where(u => u.Id == id)
                            .FirstOrDefault());
        }

        [HttpPost]
        public ActionResult ResetPassword(string id, string newPassword)
        {
            var user = _userManager.Users
                            .Where(u => u.Id == id)
                            .FirstOrDefault();
            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = _userManager.ResetPasswordAsync(user, token, newPassword).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            // TODO: include error message
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            return View(_userManager.Users
                            .Where(u => u.Id == id)
                            .FirstOrDefault());
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                _userManager.DeleteAsync(_userManager.Users
                                            .Where(u => u.Id == id)
                                            .FirstOrDefault());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}