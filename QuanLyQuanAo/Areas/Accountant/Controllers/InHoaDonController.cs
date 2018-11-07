using QuanLyQuanAo.Areas.Accountant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Accountant.Controllers
{
    public class InHoaDonController : Controller
    {
        // GET: Accountant/InHoaDon
        public ActionResult Index()
        {
            if (Session["username"] != null && (string)Session["quyen"] == "Accountant")
            {
                ViewBag.listSanPham = new SelectList(new AccountantInHoaDon().GetListSP(), "maSanPham", "tenSanPham");
                return View();
            }
            return RedirectToAction("Index", "Login", new { @area = "" });
        }

        //public JsonResult JThemHDon()
        //{
        //    return;
        //}
    }
}