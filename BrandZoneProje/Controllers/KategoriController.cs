using BrandZoneProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandZoneProje.Controllers
{
    public class KategoriController : BaseController
    {
        // GET: Admin/Kategori
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }
   
        public ActionResult KategoriEkle()
        {
            return View();
        }
    
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    islem = "eklendi",
                    mesaj = kategori.KategoriAd + " kategorisi eklendi"
                });
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KategoriSil(int id)
        {
            Kategori silinecek = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index", new
            {
                islem = "silindi",
                mesaj = silinecek.KategoriAd + " kategorisi silindi"
            });
        }

        public ActionResult KategoriDuzenle(int id)
        {
            ViewBag.Action = "Duzenle";
            Kategori duzenlenecek = db.Kategoriler.Find(id);
            return View("KategoriEkle", duzenlenecek);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KategoriDuzenle(Kategori kategori)
        {
            ViewBag.Action = "Duzenle";
            if (ModelState.IsValid)
            {
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    islem = "guncellendi",
                    mesaj = kategori.KategoriAd + " kategorisi güncellendi"
                });
            }
            return View("KategoriEkle");
        }
    }
}