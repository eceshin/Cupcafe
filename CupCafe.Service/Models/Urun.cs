using System.ComponentModel.DataAnnotations;

namespace Cupcafe.Service.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Adi { get; set; }

        [Required]
        public string Fiyati { get; set; }

        public string Foto { get; set; }

        public ICollection<KullaniciUrun> KullaniciUruns { get; set; }

    }
}
