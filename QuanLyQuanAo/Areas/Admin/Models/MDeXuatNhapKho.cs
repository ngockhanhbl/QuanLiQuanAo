using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.Admin.Models
{
    public class MDeXuatNhapKho
    {
        public string id { get; set; }

        public string maSanPham { get; set; }

        public int soLuong { get; set; }

        public DateTime ngayNhap { get; set; }

        public int TrangThai { get; set; }

        public string tenSanPham { get; set; }

        public string size { get; set; }
        public string xuatXu { get; set; }
        public List<MDeXuatNhapKho> getListNhapKho()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<MDeXuatNhapKho> list = db.nhapKhoes.Select(x => new MDeXuatNhapKho { TrangThai = (int)x.TrangThai, id = x.id, soLuong = (int)x.soLuong, ngayNhap = (DateTime)x.ngayNhap, tenSanPham = x.SANPHAM.tenSanPham, size = x.SANPHAM.size, xuatXu = x.SANPHAM.xuatXu, maSanPham = x.maSanPham }).Where(x => x.TrangThai == 0).ToList();
            return list;
        }

    }
}