using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierNhapKho
    {
        public int trangthai { get; set; }
        public List<nhapKho> getListNhapKho()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<nhapKho> list = db.nhapKhoes.ToList();
            return list;
        }

        public void updateTrangThai(string id)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            nhapKho nhapKho = db.nhapKhoes.SingleOrDefault(x => x.id == id);
            nhapKho.TrangThai = 1;
            db.SaveChanges();
        }

        public void deleteDeXuatNhapKho(string id)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            nhapKho nk = db.nhapKhoes.SingleOrDefault(x => x.id == id);
            db.nhapKhoes.Remove(nk);
            db.SaveChanges();
        }



        public int GetSoLuongByID(string id)
        {
            nhapKho nk = new QLQuanAoDBContent().nhapKhoes.SingleOrDefault(x => x.id == id);
            return (int)nk.soLuong;
        }





    }
}