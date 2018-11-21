using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierDatHang
    {
        public string DatHangID { get; set; }

        public string TenKhachHang { get; set; }

        public string SoDienThoai { get; set; }

        public string MaDonHang { get; set; }

        public string DiaChi { get; set; }

        public string MaNhanVien { get; set; }

        public int statusID { get; set; }
        public void ThemShoppingCheque(string ten, string diachi, string sdt,string manv)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            DATHANG order = new DATHANG();
            order.DatHangID = getNextIdOrDer();
            order.DiaChi = diachi;
            order.MaDonHang = getNextMaDonHang();
            order.MaNhanVien = manv;
            order.SoDienThoai = sdt;
            order.TenKhachHang = ten;
            order.statusID = 1;

            db.DATHANGs.Add(order);
            db.SaveChanges();
        }


        public string getNextIdOrDer()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<DATHANG> c = db.DATHANGs.ToList();
            int max = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (int.Parse(c[i].DatHangID) > max)
                {
                    max = int.Parse(c[i].DatHangID);
                }
            }

            if (c.Count() == 0)
                return "1";
            else
            {
                return (max + 1).ToString();
            }
        }

        public string getNextMaDonHang()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<DATHANG> c = db.DATHANGs.ToList();
            int max = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (int.Parse(c[i].MaDonHang) > max)
                {
                    max = int.Parse(c[i].MaDonHang);
                }
            }

            if (c.Count() == 0)
                return "1";
            else
            {
                return (max + 1).ToString();
            }
        }


        public List<ModifierDatHang> getListDatHang()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<ModifierDatHang> list = db.DATHANGs.Select(x => new ModifierDatHang
            {
                DatHangID = x.DatHangID,
                TenKhachHang = x.TenKhachHang,
                SoDienThoai = x.SoDienThoai,
                MaDonHang = x.MaDonHang,
                DiaChi = x.DiaChi,
                MaNhanVien = x.MaNhanVien,
                statusID = (int)x.statusID
            }).ToList();
            return list;
        }
        public void CancelPayment(string madonhang)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            DATHANG dathang = db.DATHANGs.SingleOrDefault(x => x.MaDonHang == madonhang);
            dathang.statusID = 0;
            db.SaveChanges();
        }

        public void DonePayment(string madonhang)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            DATHANG dathang = db.DATHANGs.SingleOrDefault(x => x.MaDonHang == madonhang);
            dathang.statusID = 2;
            db.SaveChanges();
        }

        public void DonePaymentByWarehouse(string madonhang)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            DATHANG dathang = db.DATHANGs.SingleOrDefault(x => x.MaDonHang == madonhang);
            dathang.statusID = 3;
            db.SaveChanges();
        }

    }

   


}