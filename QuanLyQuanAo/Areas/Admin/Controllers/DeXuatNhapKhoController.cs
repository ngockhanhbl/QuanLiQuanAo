
using QuanLyQuanAo.Areas.Admin.Models;
using QuanLyQuanAo.Areas.WarehouseStaff.Models;
using QuanLyQuanAo.Models;
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
            ViewBag.listNhapKho = new MDeXuatNhapKho().getListNhapKho();
            return View();
        }

        public JsonResult updateTonKho(string NKID, string maSP)
        {
            new ModifierNhapKho().updateTrangThai(NKID);
            new ModifierTonKho().UpdateTonKhoNhap(NKID, maSP);
            return Json("true", JsonRequestBehavior.AllowGet);
        }
       public JsonResult HuyDeXuatNhapKho(string NKID)
        {
            new ModifierNhapKho().deleteDeXuatNhapKho(NKID);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

    }
}