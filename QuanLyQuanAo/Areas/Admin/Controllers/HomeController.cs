using QuanLyQuanAo.Areas.Admin.Models;
using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["username"] != null && (string)Session["quyen"] == "Admin")
            {
                return View();
            }

            return RedirectToAction("Index", "Login", new { @area = "" });
        }
        public JsonResult JThemSPMoi(AdminSanPhamMoi model)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            ModifierSP modifySP = new ModifierSP();
            ModifierChiTietSanPham modifierCTSP = new ModifierChiTietSanPham();

            string masp = modifySP.getNextMaSP();
            modifySP.ThemSPMoi(model.SanPham);
            modifierCTSP.ThemChiTietSanPhamMoi(model.ChiTietSanPham, masp);
            new ModifierTonKho().InsertTonKho(masp);
            return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}