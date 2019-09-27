using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrandZoneProje.Models
{
    [Table("Urunler")]
    public class Urun
    {
        public int Id { get; set; }

        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        [Display(Name = "Ürün Adı")]
        [StringLength(50, ErrorMessage = "{0} 50 karakterden uzun olamaz")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public string UrunAd { get; set; }

        [Display(Name = "Birim Fiyat")]
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public decimal BirimFiyat { get; set; }

        [StringLength(200, ErrorMessage = "{0} 200 karakterden uzun olamaz")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        //Navigation Property
        public virtual Kategori Kategori { get; set; }
    }
}