using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierKhachHang
    {
        public void AddKhachHang(string ten,string diachi, string sodienthoai)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            KHACHHANG kh = new KHACHHANG();
            List<KHACHHANG> list = db.KHACHHANGs.ToList();
            foreach(var item in list)
            {
                string[] sdt = item.SDT.Split(' ');
                if(sodienthoai == sdt[0])
                {
                    return;
                }
            }
            kh.tenKhachHang = ten;
            kh.SDT = sodienthoai;
            kh.diaChi = diachi;
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
        }
    }
}