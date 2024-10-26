using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneYonetimSistemi.Models.Entity;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİ.Where(X => X.DURUM == true).ToList(); // veri tabanındaki kategori tablosunda durumu true olanları listele
            return View(degerler);
        }
        [HttpGet] // sayfa yüklendiğinde herhangi bir işlem yapılmazsa bu metodu kullan
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost] // sayfa yüklendiğinde butona tıklanırsa post işlemi yapılırsa bu metodu kullan
        public ActionResult KategoriEkle(TBLKATEGORİ p)
        {
            db.TBLKATEGORİ.Add(p); // yeni kategori ekle
            db.SaveChanges(); // DEĞİŞİKLERİ KAYDET
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id); // veri tabanındaki kategori tablosundakileri id değerlerine göre bulur
            //db.TBLKATEGORİ.Remove(kategori); // Veri tabanındaki kategori tablosundan id deki değeri sil
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORİ p)
        {
            var ktg = db.TBLKATEGORİ.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}