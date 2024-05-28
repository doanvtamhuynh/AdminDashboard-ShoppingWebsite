using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        ShoppingWebsiteEntities db = new ShoppingWebsiteEntities();
        // GET: QLTaiKhoan
        public ActionResult Index()
        {
            var dsTaiKhoan = db.Users.ToList();
            return View(dsTaiKhoan);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model, int role)
        {
            model.roleID = role;
            if(model.username != null && model.username.Length > 0)
            {
                var user = db.Users.FirstOrDefault(m => m.username == model.username);
                if (user == null)
                {
                    if (model.hoten != null && model.hoten.Length > 0
                        && model.email != null && model.email.Length > 0
                        && model.sdt != null && model.sdt.Length > 0
                        && model.password != null && model.password.Length > 0)
                    {
                        db.Users.Add(model);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    TempData["error_create"] = true;
                    return RedirectToAction("Create");
                }
            }
            TempData["error_create"] = true;
            return RedirectToAction("Create");
        }

        public ActionResult Delete(int id)
        {
            var model = db.Users.Find(id);
            db.Users.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}