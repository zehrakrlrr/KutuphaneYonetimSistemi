using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneYonetimSistemi.Models.Entity;
using System.Web.Security;
namespace KutuphaneYonetimSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAİL == p.MAİL && x.SİFRE == p.SİFRE); // veri tabanındaki TBLUYELER tablosundaki mail adresi ve şifre, giriş yapta kullanıcının girdiği mail adresi ve şifreye eşit olmalıdır.
            if(bilgiler != null) // dışardan girilen parametrelerle veri tabanındaki değerler eşleşiyorsa bu fonksiyonu çalıştır
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAİL, false);
                Session["Mail"] = bilgiler.MAİL.ToString();
                //TempData["id"] = bilgiler.ID.ToString();
                //TempData["Ad"] = bilgiler.AD.ToString();
                //TempData["Soyad"] = bilgiler.SOYAD.ToString();
                //TempData["Kullanıcıadı"] = bilgiler.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgiler.SİFRE.ToString();
                //TempData["Okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panelim"); // değerler doğruysa panelim controlddeki ındex sayfasına yönlendir.
            }
            else
            {
                return View();
            }
        }
    }
}