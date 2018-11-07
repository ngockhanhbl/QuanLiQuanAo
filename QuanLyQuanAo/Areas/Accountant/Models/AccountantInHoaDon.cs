using QuanLyQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.Accountant.Models
{
    public class AccountantInHoaDon
    {
        public SANPHAM Sanpham { get; set; }
        public KHACHHANG KhachHang { get; set; }
        public NHANVIEN NhanVien { get; set; }
        public CHITIETSANPHAM ChiTietSanPham { get; set; }
        public HOADON HoaDon { get; set; }

        public List<SANPHAM> GetListSP()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<SANPHAM> list = db.SANPHAMs.ToList();
            return list;
        }

    }
}