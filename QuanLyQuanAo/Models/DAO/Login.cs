using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyQuanAo.Models.DAO
{
    public class Login
    {
        [Required(ErrorMessage = "Chưa Nhập Username")]
        public string username { get; set; }
        [Required (ErrorMessage ="Chưa Nhập PassWord")]
        public string password { get; set; }

        public string KTuserpass(string username , string password)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            account a = db.accounts.SingleOrDefault(x => x.username == username);
            if (a == null)
            {
                return "Username Không Tồn Tại";
            }
            else
            {
                if(a.password == password)
                {
                    return a.position;
                }
                else
                {
                    return "Sai PassWord";
                }
            }
        }

    }
}