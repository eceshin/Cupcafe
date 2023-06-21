using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupCafe.Service.Core
{
    public class KullaniciUrunService
    {

        CafeDbContext db=new CafeDbContext();


      
      



        public void Save(KullaniciUrun kullaniciUrun)
        {
            var kullanici = db.Kullanicilar.Where(i => i.Id == kullaniciUrun.Kullanici.Id).First();

            kullaniciUrun.Kullanici = kullanici;

            var urun = db.Urunler.Where(i => i.Id == kullaniciUrun.Urun.Id).First();
            kullaniciUrun.Urun = urun;

            var ıslem = db.Islemler.Where(i => i.Id == kullaniciUrun.Islem.Id).First();
            kullaniciUrun.Islem = ıslem;

            db.KullaniciUrunler.Add(kullaniciUrun);
            db.SaveChanges();
        }

    }

}