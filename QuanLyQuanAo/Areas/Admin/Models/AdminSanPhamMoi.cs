using QuanLyQuanAo.Models.DAO;
using QuanLyQuanAo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Admin.Models
{
    public class AdminSanPhamMoi
    {
        public SANPHAM SanPham { get; set; }
        public CHITIETSANPHAM ChiTietSanPham { get; set; }

    }
}