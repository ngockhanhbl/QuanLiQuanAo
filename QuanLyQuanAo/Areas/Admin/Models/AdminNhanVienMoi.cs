using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.Admin.Models
{
    public class AdminNhanVienMoi
    {
        public string InsertNV(ModifierNhanVien model)
        {
            account a = new account();
            a.username = model.TenDangNhap;
            a.password = model.MatKhau;
            a.position = model.ViTri;
            if( new ModifierAccount().CheckUsername(model.TenDangNhap))
            {
                new ModifierAccount().ThemAccount(a);
                new ModifierNhanVien().ThemNhanVien(model);
                return "Them nv thanh cong";
            }
            else
            {
                return "false";
            }
            
            
        }

        public List<NHANVIEN> GetListNhanVien()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<NHANVIEN> list = db.NHANVIENs.ToList();
            return list;
        }




    }
}