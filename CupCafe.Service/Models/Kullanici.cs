using System.ComponentModel.DataAnnotations;

namespace Cupcafe.Service.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sifre { get; set; }

        public ICollection<KullaniciUrun> KullaniciUruns { get; set; }
    }
}
