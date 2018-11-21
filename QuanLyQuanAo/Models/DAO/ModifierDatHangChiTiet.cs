using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierDatHangChiTiet
    {
        public string getNextIdOrDerDetail()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<DATHANGCHITIET> c = db.DATHANGCHITIETs.ToList();
            int max = 0;
            for (int i = 0; i < c.Count; i++)
            {
                if (int.Parse(c[i].ID) > max)
                {
                    max = int.Parse(c[i].ID);
                }
            }

            if (c.Count() == 0)
                return "1";
            else
            {
                return (max + 1).ToString();
            }
        }

        public void AddDatHangChiTiet(string idDatHang, string listProduct, int listQuantity)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            DATHANGCHITIET dhct = new DATHANGCHITIET();
            dhct.ID = getNextIdOrDerDetail();
            dhct.DatHangID = idDatHang;
            dhct.MaHangHoa = listProduct;
            dhct.SoLuong = listQuantity;

            db.DATHANGCHITIETs.Add(dhct);
            db.SaveChanges();
        }


    }
}