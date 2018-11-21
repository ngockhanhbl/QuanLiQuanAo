using QuanLyQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.WarehouseStaff.Models
{
    public class XuatKhoDHvaCTDT
    {
        public string MaDH;
        public string tenKH;
        public string SDT;
        public string TenHangHoa;
        public string DiaChi;
        public int Sluong;

        public List<XuatKhoDHvaCTDT> getListDatHangVaCTDH()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            DATHANG dh = new DATHANG();
            DATHANGCHITIET dhct = new DATHANGCHITIET();
            List<XuatKhoDHvaCTDT> list = new List<XuatKhoDHvaCTDT>();
            List<DATHANG> listDH = db.DATHANGs.Where(x => x.statusID == 2).ToList();
            List<DATHANGCHITIET> listDHCT = db.DATHANGCHITIETs.ToList();

            return db.DATHANGCHITIETs.Where(x => x.DATHANG.statusID == 2).Select(x => new XuatKhoDHvaCTDT {MaDH =x.DATHANG.MaDonHang, TenHangHoa = x.SANPHAM.tenSanPham,
                tenKH = x.DATHANG.TenKhachHang, SDT = x.DATHANG.SoDienThoai, DiaChi = x.DATHANG.DiaChi, Sluong = (int)x.SoLuong }).ToList();
        }
    }
}