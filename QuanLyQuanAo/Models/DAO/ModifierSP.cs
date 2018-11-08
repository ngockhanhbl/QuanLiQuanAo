using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierSP
    {
        [Required]
        public string maSanPham { get; set; }
        [Required]
        public string tenSanPham { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public string xuatXu { get; set; }

        public string getNextMaSP()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<SANPHAM> c = db.SANPHAMs.ToList();
            int max = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (int.Parse(c[i].maSanPham) > max)
                {
                    max = int.Parse(c[i].maSanPham);
                }
            }

            if (c.Count() == 0)
                return "1";
            else
            {
                return (max + 1).ToString();
            }
        }

        public void ThemSPMoi(SANPHAM modifier)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            SANPHAM sp = new SANPHAM();
            sp.tenSanPham = modifier.tenSanPham;
            sp.maSanPham = getNextMaSP();
            sp.xuatXu = modifier.xuatXu;
            sp.size = modifier.size;
            db.SANPHAMs.Add(sp);
            db.SaveChanges();

        }

        public List<SANPHAM> getListSanPham()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<SANPHAM> list = db.SANPHAMs.ToList();
            return list;
        }
    }


}
