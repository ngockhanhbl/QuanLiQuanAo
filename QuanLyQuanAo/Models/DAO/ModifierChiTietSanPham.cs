using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierChiTietSanPham
    {
        [Required]
        public string maSanPham { get; set; }
        [Required]
        public double donGiaNhap { get; set; }
        [Required]
        public double donGiaXuat { get; set; }

        public void ThemChiTietSanPhamMoi(CHITIETSANPHAM modifier, string maSanPham)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            CHITIETSANPHAM sp = new CHITIETSANPHAM();
            sp.maSanPham = maSanPham;
            sp.donGiaNhap = modifier.donGiaNhap;
            sp.donGiaXuat = modifier.donGiaXuat;
            db.CHITIETSANPHAMs.Add(sp);
            db.SaveChanges();

        }

    }

}




