using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KutuphaneYonetimSistemi.Models.Entity;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        [Authorize] // Authorize sayesinde kullanıcı adı ve şifresini girip, giriş yapmadan panelim sayfasına yönlendirilmez.
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAİL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAİL == kullanici);
            uye.SİFRE = p.SİFRE;
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return View(db);
        }
        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAİL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList(); 
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        
    }
}