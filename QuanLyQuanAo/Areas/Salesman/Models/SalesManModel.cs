using QuanLyQuanAo.Models;
using QuanLyQuanAo.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Areas.Salesman.Models
{
    public class SalesManModel
    {
        public DATHANG DatHang { get; set; }
        public DATHANGCHITIET DatHangChiTiet { get; set; }

        public void ThemPhieuMuaHang( string listProduct, string listQuantity, string listInfo)
        {
            string[] listProductSplit = listProduct.Split('-');
            string[] listQuantitySplit = listQuantity.Split('-');
            string[] listInfomation = listInfo.Split('-');

            new ModifierDatHang().ThemShoppingCheque(listInfomation[0], listInfomation[1], listInfomation[2], listInfomation[3]);
            new ModifierKhachHang().AddKhachHang(listInfomation[0], listInfomation[1], listInfomation[2]);
            string maDH = new ModifierDatHang().getNextMaDonHang() ;
            int madonhang = int.Parse(maDH) - 1;

            for (int i = 0; i < listProductSplit.Length; i++)
            {
                new ModifierDatHangChiTiet().AddDatHangChiTiet(madonhang.ToString(), listProductSplit[i], int.Parse(listQuantitySplit[i]));
            }
        }
    }






}