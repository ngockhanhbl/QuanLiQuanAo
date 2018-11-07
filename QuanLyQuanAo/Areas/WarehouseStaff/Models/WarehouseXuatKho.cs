﻿using QuanLyQuanAo.Models;
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
            return (db.nhapKhoes.Count() + 1) + "";
        }

        public void RemoveXuatKho(WarehouseXuatKho model)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            XUATKHO xuat = new XUATKHO();

            xuat.ngayXuat = DateTime.Now;
            xuat.id = getNextId();
            xuat.soLuong = model.soLuong;
            xuat.maSanPham = model.maHang;
            db.XUATKHOes.Add(xuat);
            db.SaveChanges();
            ModifierTonKho mtk = new ModifierTonKho();
            mtk.UpdateTonKho(model.maHang, model.soLuong*-1);
        }


    }
}