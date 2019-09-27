using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrandZoneProje.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public Kategori()
        {
            Urunler = new HashSet<Urun>();
        }
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        [StringLength(50, ErrorMessage = "Kategori Adı 50 karakterden uzun olamaz")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string KategoriAd { get; set; }

        //Navigation Property
        public virtual ICollection<Urun> Urunler { get; set; }
    }
}