using QuanLyQuanAo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.Accountant.Models
{
    public class AccountantQuanLiHoaDon
    {
        [Required] 
        public string MaHoaDon { get; set; }
        [Required]
        public DateTime NgayLapHoaDon { get; set; }
        [Required]
        public float ThanhTien { get; set; }
        [Required]
        public string MaNVienLapHDon { get; set; }
        public List<AccountantQuanLiHoaDon> GetListHDon()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<AccountantQuanLiHoaDon> list = db.HOADONs.Select(x => new AccountantQuanLiHoaDon { MaHoaDon = x.maHoaDon, NgayLapHoaDon = x.ngayLapHoaDon, ThanhTien = (float)x.thanhTien, MaNVienLapHDon = x.maNhanVien }).ToList();
            return list;
        }
    }
}