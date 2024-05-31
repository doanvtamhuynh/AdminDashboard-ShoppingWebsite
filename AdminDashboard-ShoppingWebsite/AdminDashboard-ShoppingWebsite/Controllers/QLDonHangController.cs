using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.Controllers
{
    public class QLDonHangController : Controller
    {
        ShoppingWebsiteEntities db = new ShoppingWebsiteEntities();
        // GET: QLDonHang
        public ActionResult Index()
        {
            var dsDonHang = db.DonHangs.OrderBy(m => m.tinhtrangID);
            return View(dsDonHang);
        }

        public ActionResult Details(int id)
        {
            var chitietDH = db.ChiTietDonHangs.Where(m => m.donhangID == id).ToList();
            return View(chitietDH);
        }

        public ActionResult XacNhan(int id)
        {
            var model = db.DonHangs.Find(id);
            model.tinhtrangID = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult HoanThanh(int id)
        {
            var model = db.DonHangs.Find(id);
            model.tinhtrangID = 3;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = db.DonHangs.Find(id);
            db.DonHangs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}