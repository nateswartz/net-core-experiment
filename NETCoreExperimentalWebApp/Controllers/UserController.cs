using System.Linq;
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
        public ActionResult Users()
        {
            return View(_userManager.Users.ToList());
        }

        public ActionResult ResetPassword(string id)
        {
            var user = _userManager.Users
                            .Where(u => u.Id == id)
                            .FirstOrDefault();
            return View(user);
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
                return RedirectToAction(nameof(Users));
            }
            AddErrors(result);
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
                var result = _userManager.DeleteAsync(_userManager.Users
                                            .Where(u => u.Id == id)
                                            .FirstOrDefault()).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                return View(id);
            }
            catch
            {
                return View(id);
            }
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}