using Cupcafe.Service.Models;
using CupCafe.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Cupcafe.Service.Data
{
    public class CafeDbContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<KullaniciUrun> KullaniciUrunler { get; set; }

        public DbSet<Islem> Islemler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KullaniciUrun>()
                .HasOne(ku => ku.Kullanici)
                .WithMany(k => k.KullaniciUruns)
                .HasForeignKey(ku => ku.KullaniciId);

            modelBuilder.Entity<KullaniciUrun>()
                .HasOne(ku => ku.Urun)
                .WithMany(u => u.KullaniciUruns)
                .HasForeignKey(ku => ku.UrunId);

            modelBuilder.Entity<KullaniciUrun>()
                .HasOne(ku => ku.Islem)
                .WithMany(u => u.KullaniciUruns)
                .HasForeignKey(ku => ku.IslemId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-KC9U4NN\\SQLEXPRESS;Database=CupCafeDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

    }
}
