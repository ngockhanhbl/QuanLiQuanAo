using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierHD
    {
        public void UpdateHDForDeleteNV(string maNV)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<HOADON> list = db.HOADONs.Where(x => x.maNhanVien == maNV).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].maNhanVien = "0";
                db.SaveChanges();
            }

        }
        public string getNextMaHDon()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<HOADON> c = db.HOADONs.ToList();
            int max = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (int.Parse(c[i].maHoaDon) > max)
                {
                    max = int.Parse(c[i].maHoaDon);
                }
            }

            if (c.Count() == 0)
                return "1";
            else
            {
                return (max + 1).ToString();
            }
        }

        public void ADDHoaDon(string maNhanVien, string MaDatHang,string SDT)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            HOADON hd = new HOADON();
            string mahd = getNextMaHDon();
            hd.maHoaDon = mahd;          
            hd.ngayLapHoaDon = DateTime.Now;
            hd.maNhanVien = maNhanVien;
            hd.DatHangID = MaDatHang;
            hd.SDTKhachHang = SDT;
            db.HOADONs.Add(hd);

            db.SaveChanges();
            DATHANGCHITIET dhct = new DATHANGCHITIET();
            List<DATHANGCHITIET> listDatHangChiTiet = db.DATHANGCHITIETs.Where(x => x.DatHangID == MaDatHang).ToList();

            double Tong = 0;
            foreach (var item in listDatHangChiTiet)
            {
                
                List<CHITIETSANPHAM> ctsp = db.CHITIETSANPHAMs.Where(x => x.maSanPham == item.MaHangHoa).ToList();
                Tong += (double)ctsp[0].donGiaXuat;
                new ModifierChiTietHD().AddChiTietHD(mahd, item.MaHangHoa, (int)item.SoLuong, (float)ctsp[0].donGiaXuat);
            }
            List<HOADON> hoadon = db.HOADONs.Where(x => x.maHoaDon == mahd).ToList();
            hoadon[0].TongTien = Tong;
          
            db.SaveChanges();
           
        }


        //public string getListInfoHoaDon(string MaDatHang)
        //{
        //    QLQuanAoDBContent db = new QLQuanAoDBContent();
        //    string mahd = getNextMaHDon();
        //    string ngaylapHD = DateTime.Now.ToString();


        //    DATHANGCHITIET dhct = new DATHANGCHITIET();
        //    List<DATHANGCHITIET> listDatHangChiTiet = db.DATHANGCHITIETs.Where(x => x.DatHangID == MaDatHang).ToList();

        //    double Tong = 0;
        //    string listMaSP ="";
        //    string listSL ="";
        //    foreach (var item in listDatHangChiTiet)
        //    {

        //        List<CHITIETSANPHAM> ctsp = db.CHITIETSANPHAMs.Where(x => x.maSanPham == item.MaHangHoa).ToList();
        //        Tong += (double)ctsp[0].donGiaXuat;

        //        listMaSP += item.MaHangHoa; listMaSP += "-";
        //        listSL += item.SoLuong;listSL += "-";
        //    }
        //    int idx = listMaSP.LastIndexOf('-');
        //    string ListMaSP = listMaSP.Substring(0, idx);

        //    int idx1 = listMaSP.LastIndexOf('-');
        //    string ListSL = listSL.Substring(0, idx1);

        //    string retun = mahd+"-"+ngaylapHD+"/"+ ListMaSP+"-"+ ListSL+"/"+Tong.ToString();
        //    return retun;
        //}



    }
}