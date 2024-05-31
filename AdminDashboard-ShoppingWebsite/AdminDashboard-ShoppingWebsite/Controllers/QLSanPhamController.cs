using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.Controllers
{
    [App_Start.Logged]
    [App_Start.AdminAuthorize]
    public class QLSanPhamController : Controller
    {
        ShoppingWebsiteEntities db = new ShoppingWebsiteEntities();
        // GET: QLSanPham
        public ActionResult Index()
        {
            var dsSanPhan = db.SanPhams.ToList();
            return View(dsSanPhan);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Create(SanPham model, HttpPostedFileBase hinhanh)
        {
            if(hinhanh != null && hinhanh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("~/Content/img/");
                string imgPath = rootFolder + hinhanh.FileName;
                hinhanh.SaveAs(imgPath);
                model.urlhinharnh = hinhanh.FileName;
            }
            else
            {
                model.urlhinharnh = "sanpham.jpg";
            }
            db.SanPhams.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = db.SanPhams.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SanPham model, HttpPostedFileBase hinhanh)
        {
            var updateModel = db.SanPhams.Find(model.sanphamID);
            updateModel.tensanpham = model.tensanpham;
            updateModel.giasanpham = model.giasanpham;
            updateModel.tonkho = model.tonkho;
            if(hinhanh != null && hinhanh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("~/Content/img/");
                string imgPath = rootFolder + hinhanh.FileName;
                hinhanh.SaveAs(imgPath);
                model.urlhinharnh = hinhanh.FileName;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = db.SanPhams.Find(id);
            db.SanPhams.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}