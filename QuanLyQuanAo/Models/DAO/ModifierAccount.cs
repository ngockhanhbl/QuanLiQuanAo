using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyQuanAo.Models;

namespace QuanLyQuanAo.Models.DAO
{
    public class ModifierAccount
    {
        public account Select(string username) {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            account account = db.accounts.SingleOrDefault(x => x.username == username);
            return account;
        }
        public void ThemAccount(account acc)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            account acc1 = new account();            
            acc1.username = acc.username;
            acc1.password = acc.password;
            acc1.position = acc.position;
            db.accounts.Add(acc1);
            db.SaveChanges();
        }
        public bool CheckUsername(string username)
        {
            if (new QLQuanAoDBContent().accounts.SingleOrDefault(x => x.username == username) == null)
            {
                return true;
            }
            else
                return false;
        }
        public void DeleteAccount(string username)
        {
            QLQuanAoDBContent db = new QLQuanAoDBContent();
            account a = db.accounts.SingleOrDefault(x => x.username == username);
            db.accounts.Remove(a);
            db.SaveChanges();

        }
    }
}