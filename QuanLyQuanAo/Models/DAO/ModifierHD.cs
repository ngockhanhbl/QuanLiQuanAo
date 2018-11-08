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


    }
}