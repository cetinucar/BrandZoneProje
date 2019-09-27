using BrandZoneProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandZoneProje.Controllers
{
    public class UrunController : BaseController
    {
        // GET: Urun
        public ActionResult Index()
        {
            return View(db.Urunler.ToList());
        }


        [HttpPost]
        public ActionResult UrunSil(int id)
        {
            var silinecek = db.Urunler.Find(id);
            db.Urunler.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index", new
            {
                islem = "silindi",
                mesaj = silinecek.UrunAd + " adlı ürün silindi"

            });
        }

        public ActionResult UrunEkle()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urunler.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index", new { islem = "eklendi", mesaj = urun.UrunAd + " adlı ürün başarıyla eklendi" });
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            return View();
        }


        public ActionResult UrunDuzenle(int id)
        {

            ViewBag.Action = "Duzenle";
            Urun duzenlenecek = db.Urunler.Find(id);
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");

            return View("UrunEkle", duzenlenecek);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrunDuzenle(Urun urun)
        {
            ViewBag.Action = "Duzenle";
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");

            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { islem = "guncellendi", mesaj = urun.UrunAd + " adlı ürün başarıyla guncellendi" });

            }
            return View("UrunEkle", urun);
        }

    }
}