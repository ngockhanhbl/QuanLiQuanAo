using QuanLyQuanAo.Areas.Accountant.Models;
using QuanLyQuanAo.Models.DAO;
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
               
                ViewBag.listFullSanPham = new SelectList(new AccountantInHoaDon().GetListSP());
                ViewBag.NextMaHoaDon = new ModifierHD().getNextMaHDon();
                ViewBag.listChiTietSanPham = new ModifierChiTietSanPham().getListFullSanPham();
                ViewBag.getListPhieuMuaHang = new ModifierDatHang().getListDatHang(); 
                return View();
            }
            return RedirectToAction("Index", "Login", new { @area = "" });
        }

        public JsonResult JGetGiaSP(AccountantInHoaDon model)
        {           
            double giaXuat = new ModifierChiTietSanPham().getGiaXuatByMaSp(model.Sanpham.maSanPham);     
            return Json(giaXuat+"", JsonRequestBehavior.AllowGet);
        }

        //public JsonResult DeTailPayment(string MaDHang)
        //{
        //    new ModifierDatHang().DonePayment(MaDHang);
        //    new ModifierHD().getListInfoHoaDon( MaDHang);
        //    return Json("true", JsonRequestBehavior.AllowGet);
        //}



        public JsonResult DonePayment(string MaDHang,string MaNV,string SDT)
        {
            new ModifierDatHang().DonePayment(MaDHang);
            new ModifierHD().ADDHoaDon(MaNV, MaDHang, SDT);
            return Json("true", JsonRequestBehavior.AllowGet);
        }




        //Đáng lẽ nên thêm 1 trường mã kế toán để biết kế toán nào hủy hoặc lập hóa đơn đó
        public JsonResult CancelPayment(string MaDHang)
        {
            new ModifierDatHang().CancelPayment(MaDHang);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

    }
}