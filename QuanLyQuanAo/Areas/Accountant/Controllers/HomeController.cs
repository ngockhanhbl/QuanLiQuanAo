using QuanLyQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Accountant.Controllers
{
    public class HomeController : Controller
    {
        // GET: Accountant/Home
        public ActionResult Index()
        {
            if (Session["username"] != null && (string)Session["quyen"] == "Accountant")
            {
                return View();
            }

            return RedirectToAction("Index", "Login", new { @area = "" });
        }

        public ActionResult GetSearchRecord(string SearchText)
        {
      //      DateTime time = DateTime.Parse(SearchText);
      //      int Nam = time.Year;
      //      int Thang = time.Month;
      //      int Ngay = time.Day;
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            //List<HOADON> list = db.HOADONs.Where(x => x.ngayLapHoaDon.Year == Nam  &&  x.ngayLapHoaDon.Month == Thang && x.ngayLapHoaDon.Day == Ngay).Select(x => new HOADON { maHoaDon = x.maHoaDon, ngayLapHoaDon = x.ngayLapHoaDon, thanhTien = x.thanhTien }).ToList();
            List <HOADON> list = db.HOADONs.Where(x=>x.maHoaDon == SearchText).ToList();
            return PartialView("SearchPartial", list);

        }


    }
}