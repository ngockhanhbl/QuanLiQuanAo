using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierChiTietHD
    {
        public string getNextID()
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            List<CHITIETHOADON> c = db.CHITIETHOADONs.ToList();
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


        public void AddChiTietHD(string billID,string ProDuctID,int Quantity, float Price)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            CHITIETHOADON cthd = new CHITIETHOADON();
            cthd.ID = getNextID();
            cthd.BillID = billID;
            cthd.ProductID = ProDuctID;
            cthd.Quantity = Quantity;
            cthd.Price = Price;
            db.CHITIETHOADONs.Add(cthd);
            db.SaveChanges();

        }
    }
}