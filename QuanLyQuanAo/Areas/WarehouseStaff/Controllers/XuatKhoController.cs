using QuanLyQuanAo.Areas.WarehouseStaff.Models;
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.WarehouseStaff.Controllers
{
    public class XuatKhoController : Controller
    {
        // GET: WarehouseStaff/XuatKho
        public ActionResult Index()
        {
            if (Session["username"] != null && (string)Session["quyen"] == "Warehouse")
            {
                ViewBag.listSanPham = new SelectList(new WarehouseNhapKho().GetListSP(), "maSanPham", "tenSanPham");
                ViewBag.getListXuatKho = new XuatKhoDHvaCTDT().getListDatHangVaCTDH();
                return View();
            }
            return RedirectToAction("Index", "Login", new { @area = "" });
        }

        public JsonResult DonePayment(string MaDHang)
        {
            new ModifierDatHang().DonePaymentByWarehouse(MaDHang);
            return Json("true", JsonRequestBehavior.AllowGet);
        }


    }
}