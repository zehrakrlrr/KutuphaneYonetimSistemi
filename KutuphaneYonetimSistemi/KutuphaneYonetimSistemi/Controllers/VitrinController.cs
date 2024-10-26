using System.Linq;
using System.Web.Mvc;
using KutuphaneYonetimSistemi.Models.Entity;
using KutuphaneYonetimSistemi.Models.Sınıflarım;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKİTAP.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
           // var degerler = db.TBLKİTAP.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}