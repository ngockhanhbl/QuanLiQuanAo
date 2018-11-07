using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.WarehouseStaff.Models
{
    public class WarehouseNhapKho
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


        public string GetNextId()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<nhapKho> c = db.nhapKhoes.ToList();
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
                return (max+1).ToString();
            }


        }

        public void InsertNhapKho(WarehouseNhapKho model)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            nhapKho nhapKho = new nhapKho();
            nhapKho.id = GetNextId();
            nhapKho.ngayNhap = DateTime.Now;
            nhapKho.soLuong = model.soLuong;
            nhapKho.maSanPham = model.maHang;
            db.nhapKhoes.Add(nhapKho);
            db.SaveChanges();
            ModifierTonKho mtk = new ModifierTonKho();
            mtk.UpdateTonKho(model.maHang, model.soLuong);
        }
    }



}