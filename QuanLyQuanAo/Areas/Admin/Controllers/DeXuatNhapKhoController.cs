
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Admin.Controllers
{
    public class DeXuatNhapKhoController : Controller
    {
        // GET: Admin/DeXuatNhapKho
        public ActionResult Index()
        {
            ViewBag.listSanPham = new ModifierSP().getListSanPham();
            return View();
        }
    }
}