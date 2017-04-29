using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentroOdontologicoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Orden()
        {
            ViewBag.Message = "Órdenes de Pago.";

            return View();
        }

        public ActionResult GenerarOrden()
        {
            ViewBag.Message = "Generar Orden de Pago";
            return View();
        }
    }
}