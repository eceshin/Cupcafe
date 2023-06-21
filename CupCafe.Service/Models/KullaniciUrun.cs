using CupCafe.Service.Models;
using System.ComponentModel.DataAnnotations;

namespace Cupcafe.Service.Models
{
    public class KullaniciUrun
    {
        [Key]
        public int Id { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int IslemId { get; set; }

       public Islem Islem { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }


    }
}
