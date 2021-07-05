using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantaMesa.Models;

namespace SantaMesa.Controllers
{
    public class HomeController : Controller
    {
        private BD_SantaMesaEntities db = new BD_SantaMesaEntities();
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
        public ActionResult Catalogo()
        {
            ViewBag.Message = "Your catalogo page.";

            return View(db.Productos.ToList());
        }
        public ActionResult ProductoDetalle()
        {
            ViewBag.Message = "Your catalogo page.";

            return View();
        }
        
        public ActionResult Whislist()
        {
            ViewBag.Message = "Your catalogo page.";

            return View();
        }
    }
}