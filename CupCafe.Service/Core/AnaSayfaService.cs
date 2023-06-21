using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupCafe.Service.Core
{
    public class AnaSayfaService
    {

        CafeDbContext _db=new CafeDbContext();


        public void Save(string email, string sifre)
        {
            var yeniKullanici = new Kullanici
            {
                Email = email,
                Sifre = sifre
            };

            _db.Kullanicilar.Add(yeniKullanici);
            _db.SaveChanges();
        }
      

    }

}