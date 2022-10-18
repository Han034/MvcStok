using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Tbl_Musteriler select d;
            if (!string.IsNullOrEmpty(p))//Aranan ifadeyi bulma fonk.
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
            var deger = db.Tbl_Musteriler.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Tbl_Musteriler p2)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            db.Tbl_Musteriler.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);
            db.Tbl_Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Tbl_Musteriler.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(Tbl_Musteriler p1)
        {
            var musteri = db.Tbl_Musteriler.Find(p1.Musteriid);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}