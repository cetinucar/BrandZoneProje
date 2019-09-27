namespace BrandZoneProje.Migrations
{
    using BrandZoneProje.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrandZoneProje.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrandZoneProje.Models.ApplicationDbContext context)
        {
            var kategori1 = new Kategori
            {
                KategoriAd = "Otomobil"
            };
            var kategori2 = new Kategori
            {
                KategoriAd = "Beyaz Eþya"
            };
            var kategori3 = new Kategori
            {
                KategoriAd = "SuperMarket"
            };
            kategori1.Urunler.Add(new Urun
            {
                UrunAd = "Golf",
                BirimFiyat = 85000m,
                Aciklama = "Volkswagen"
            });
            kategori1.Urunler.Add(new Urun
            {
                UrunAd = "Civic",
                BirimFiyat = 85000m,
                Aciklama = "Honda"
            });
            kategori2.Urunler.Add(new Urun
            {
                UrunAd = "Bosch Bulaþýk Makinesi",
                BirimFiyat = 85000m,
                Aciklama = "A+ Enerji Sýnýfý"
            });
            kategori2.Urunler.Add(new Urun
            {
                UrunAd = "Samsung Buzdolabý",
                BirimFiyat = 85000m,
                Aciklama = "A++ Enerji Sýnýfý"
            });
            kategori3.Urunler.Add(new Urun
            {
                UrunAd = "Pringles",
                BirimFiyat = 85000m,
                Aciklama = "250 kcal"
            });
            kategori3.Urunler.Add(new Urun
            {
                UrunAd = "Kola",
                BirimFiyat = 85000m,
                Aciklama = "Pepsi 2.5 lt"
            });
            context.Kategoriler.Add(kategori1);
            context.Kategoriler.Add(kategori2);
            context.Kategoriler.Add(kategori3);
        }
    }
}
