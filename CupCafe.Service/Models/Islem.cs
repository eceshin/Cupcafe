using Cupcafe.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupCafe.Service.Models
{
    public class Islem
    {
        public int Id { get; set; }

        public string IslemAdi { get; set; }


        public ICollection<KullaniciUrun> KullaniciUruns { get; set; }
    }
}
