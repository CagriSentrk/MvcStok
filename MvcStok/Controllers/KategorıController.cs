using MvcStok.Models.Entity;
using System.Linq;
using System.Web.Mvc;
namespace MvcStok.Controllers

{
    using PagedList;
    using PagedList.Mvc;
    public class KategorıController : Controller
    {
        // GET: Kategorı
        MvcDbstokEntities db = new MvcDbstokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORI.ToList();
            var degerler = db.TBLKATEGORI.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORI.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORI p1)
        {
            var ktg = db.TBLKATEGORI.Find(p1.KATEGORIID);
            ktg.KATEGORIADI = p1.KATEGORIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}