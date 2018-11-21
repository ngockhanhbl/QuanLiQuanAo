using QuanLyQuanAo.Areas.Salesman.Models;
using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Salesman.Controllers
{
    public class HomeController : Controller
    {
        // GET: Salesman/Home
        public ActionResult Index()
        {
            ViewBag.listSP = new SelectList(new ModifierSP().getListSanPham(), "maSanPham", "tenSanPham");
            return View();
        }

        public JsonResult JAddShoppingCheque(string listProduct, string listQuantity, string listInfo)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            new SalesManModel().ThemPhieuMuaHang(listProduct,listQuantity,listInfo);
            return Json("true", JsonRequestBehavior.AllowGet);
        }
    }
}