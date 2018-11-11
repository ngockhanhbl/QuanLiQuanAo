using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierTonKho
    {
        public string UpdateTonKho(string ma, int sl)
        {
            string temp;
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            TONKHO tk = db.TONKHOes.SingleOrDefault(x => x.maSanPham == ma);
            
            tk.soLuong = tk.soLuong + sl;
            
            db.SaveChanges();
            temp = "true";

            return temp;
        }

        public string UpdateXuatTonKho(string ma, int sl)
        {
            string temp;
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            TONKHO tk = db.TONKHOes.SingleOrDefault(x => x.maSanPham == ma);

            if (tk.soLuong >= sl)
            {
                tk.soLuong = tk.soLuong - sl;

                db.SaveChanges();
                temp = "true";

                return temp;
            }
            else
            {
                return "false";
            }

        }



        public void UpdateTonKhoNhap(string id, string maSP)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            int soluong = new ModifierNhapKho().GetSoLuongByID(id);
            TONKHO tk = db.TONKHOes.SingleOrDefault(x => x.maSanPham == maSP);
            tk.soLuong += soluong;
            db.SaveChanges();
        }
        public void InsertTonKho(string maSP)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            TONKHO tk = new TONKHO();
            tk.maSanPham = maSP;
            tk.soLuong = 0;
            db.TONKHOes.Add(tk);
            db.SaveChanges();
        }


    }
}