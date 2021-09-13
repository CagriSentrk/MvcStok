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
        MvcDbstokEntities db = new MvcDbstokEntities();
        // GET: Musteri
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERI.ToList();
            return View(degerler);
            
        }


        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERI.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir", musteri);

        }
        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var musteri = db.TBLMUSTERI.Find( p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}