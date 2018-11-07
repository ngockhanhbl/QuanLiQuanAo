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
    }
}