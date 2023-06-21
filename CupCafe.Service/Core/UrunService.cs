using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupCafe.Service.Core
{
    public class UrunService
    {

        CafeDbContext _db=new CafeDbContext();


        public void Save(string adi, string fiyati, string foto)
        {
           
                  var yeniUrun = new Urun
                    {
                        Adi = adi,
                        Fiyati = fiyati,
                        Foto = foto
                    };

                    _db.Urunler.Add(yeniUrun);
                

            _db.SaveChanges();
        }

        public void Update(int id, string adi, string fiyati, string foto)
        {
            var Urun = _db.Urunler.Find(id);
            Urun.Adi = adi;
            Urun.Fiyati = fiyati;
            Urun.Foto = foto;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _db.Urunler.Find(id);
            _db.Urunler.Remove(model);
            _db.SaveChanges();

        }

        public List<Urun> GetAll()
        {
            var models = _db.Urunler.ToList();
            return models;
        }

        public Urun GetById(int id) {
            return _db.Urunler.First(p=>p.Id==id);
        }


    }

}