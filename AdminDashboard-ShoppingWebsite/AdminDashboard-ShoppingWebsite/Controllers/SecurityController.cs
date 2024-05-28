using AdminDashboard_ShoppingWebsite.Helpers;
using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.Controllers
{
    public class SecurityController : Controller
    {
        ShoppingWebsiteEntities db = new ShoppingWebsiteEntities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(m => m.username == username && m.password == password);
            if (user != null && user.roleID == 1)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Home");
            }
            TempData["error_login"] = true;
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword() {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username, string email) {
            var user = db.Users.FirstOrDefault(m => m.username == username && m.email == email);
            if(user != null)
            {
                Helpers.EmailService email_service = new Helpers.EmailService();
                email_service.SendEmail(user.email, "GỬI LẠI MẬT KHẨU", "Mật khẩu của bạn là: " + user.password);
                return RedirectToAction("Login");
            }

            TempData["error_forgotpassword"] = true;
            return RedirectToAction("ForgotPassword");
        }
    }
}