using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.WarehouseStaff.Models
{
    public class WarehouseXuatKho
    {

        [Required]
        public string maHang { get; set; }
        [Required]
        public int soLuong { get; set; }
        public List<SANPHAM> GetListSP()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<SANPHAM> list = db.SANPHAMs.ToList();
            return list;
        }


        public string getNextId()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<XUATKHO> c = db.XUATKHOes.ToList();
            int max = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (int.Parse(c[i].id) > max)
                {
                    max = int.Parse(c[i].id);
                }
            }
            if (c.Count() == 0)
                return "1";
            else
            {
                return (max + 1).ToString();
            }


        }


        public string RemoveXuatKho(WarehouseXuatKho model)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            XUATKHO xuat = new XUATKHO();
            xuat.ngayXuat = DateTime.Now;
            xuat.id = getNextId();
            xuat.soLuong = model.soLuong;
            xuat.maSanPham = model.maHang;
            db.XUATKHOes.Add(xuat);
            
            ModifierTonKho mtk = new ModifierTonKho();
            if (mtk.UpdateXuatTonKho(model.maHang, model.soLuong) == "false") {
                return "false";
            };
            db.SaveChanges();
            return "true";
            
        }


    }
}