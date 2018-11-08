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
        public string tenSanPham { get; set; }

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
        public List<CHITIETSANPHAM> getListSanPham()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<CHITIETSANPHAM> list = db.CHITIETSANPHAMs.ToList();
            return list;
        }
        public List<ModifierChiTietSanPham> getListFullSanPham()
        {
            return new QLQuanAoDBContent().CHITIETSANPHAMs.Select(x => new ModifierChiTietSanPham { maSanPham = x.maSanPham, tenSanPham = x.SANPHAM.tenSanPham, donGiaNhap = (double)x.donGiaNhap, donGiaXuat = (double)x.donGiaXuat }).ToList();
        }


    }

}




