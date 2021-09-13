using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class URUNController : Controller
    {
        MvcDbstokEntities db = new MvcDbstokEntities();
        // GET: URUN
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIADI,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORI.Where(m => m.KATEGORIID == p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORI = ktg;

            db.TBLURUNLER.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIADI,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            var urun = db.TBLURUNLER.Find(id);
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            var ktg = db.TBLKATEGORI.Where(m => m.KATEGORIID == p.TBLKATEGORI.KATEGORIID).FirstOrDefault();
           urun.URUNKATEGORI = ktg.KATEGORIID;
            urun.FIYAT = p.FIYAT;
            urun.STOK = p.STOK;
            urun.MARKA = p.MARKA;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}