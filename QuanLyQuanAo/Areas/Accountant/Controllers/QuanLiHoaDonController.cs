using QuanLyQuanAo.Areas.Accountant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Accountant.Controllers
{
    public class QuanLiHoaDonController : Controller
    {
        // GET: Accountant/QuanLiHoaDon
        public ActionResult Index()
        {
            if (Session["username"] != null && (string)Session["quyen"] == "Accountant")
            {
                ViewBag.listInfoHoaDon = new AccountantQuanLiHoaDon().GetListHDon();
                return View();
                
            }

            return RedirectToAction("Index", "Login", new { @area = "" });
        }
    }
}