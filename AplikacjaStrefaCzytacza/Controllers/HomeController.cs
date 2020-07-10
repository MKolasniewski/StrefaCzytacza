using AplikacjaStrefaCzytacza.DAL;
using AplikacjaStrefaCzytacza.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplikacjaStrefaCzytacza.Controllers
{
    public class HomeController : Controller
    {
        private DbStrefaConfig db = new DbStrefaConfig();


        public ActionResult Index()
        {
            var kategorie = db.Kategorias.ToList().Take(5);
            //przy tabelach (guid) może sie zle posortować!
            //stempel czasowy
            var ksiazki = db.Ksiazkas.OrderBy(a => Guid.NewGuid()).Take(3).ToList();
            var cytaty = db.Cytats.OrderBy(c => Guid.NewGuid()).Take(1).ToList();

            var kkc = new HomeViewModel
            {
                Ksiazki = ksiazki,
                Kategorie = kategorie,
                Cytaty = cytaty
            };

            return View(kkc);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Jeżeli podoba Ci się ta aplikacja, poinformuj mnie o tym";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Zapraszamy do kontaktu";

            return View();
        }
    }
}