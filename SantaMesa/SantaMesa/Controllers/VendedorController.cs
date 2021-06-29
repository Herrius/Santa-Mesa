using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantaMesa.Controllers
{
    public class VendedorController : Controller
    {
       
        public ActionResult Catalogo()
        {
            ViewBag.Message = "Your catalogo page.";

            return View();
        }
        public ActionResult Banner()
        {
            ViewBag.Message = "Your catalogo page.";

            return View();
        }
        public ActionResult AgregarProducto()
        {
            ViewBag.Message = "Your catalogo page.";

            return View();
        }
    }
}
