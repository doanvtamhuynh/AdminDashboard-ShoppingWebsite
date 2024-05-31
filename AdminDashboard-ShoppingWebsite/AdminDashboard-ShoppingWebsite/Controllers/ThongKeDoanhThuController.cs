using AdminDashboard_ShoppingWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard_ShoppingWebsite.Controllers
{
    public class ThongKeDoanhThuController : Controller
    {
        ShoppingWebsiteEntities db = new ShoppingWebsiteEntities();
        // GET: ThongKeDoanhThu
        public ActionResult Index()
        {
                var dateTime = DateTime.Now;
                var dsDonHang = db.DonHangs.Where(m => m.ngaygiaohang.Value.Day == dateTime.Day
                                              && m.ngaygiaohang.Value.Month == dateTime.Month
                                              && m.ngaygiaohang.Value.Year == dateTime.Year
                                              && m.tinhtrangID == 3).ToList();
                return View(dsDonHang);
        }

        public ActionResult TimKiem(DateTime datetime)
        {
                var dsDonHang = db.DonHangs.Where(m => m.ngaygiaohang.Value.Day == datetime.Day
                                              && m.ngaygiaohang.Value.Month == datetime.Month
                                              && m.ngaygiaohang.Value.Year == datetime.Year
                                              && m.tinhtrangID == 3).ToList();
                return View(dsDonHang);
        }
        
        
        public ActionResult TimKiemTheoThang(DateTime month)
        {
                var dsDonHang = db.DonHangs.Where(m =>  m.ngaygiaohang.Value.Month == month.Month
                                              && m.ngaygiaohang.Value.Year == month.Year
                                              && m.tinhtrangID == 3).ToList();
                return View(dsDonHang);
        }
    }
}