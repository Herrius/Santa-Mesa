using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Catalogo(int? id)
        {
           
            switch (id)
            {
                case 0:
                    return View(db.Productos.OrderBy(i => i.precio));
                case 1:
                    return View(db.Productos.OrderByDescending(i => i.precio));
                case 2:
                    return View(db.Productos.OrderByDescending(i => i.estado));
                case 6:
                    return View(db.Productos.OrderBy(i=>i.edad_player));
              
                default:
                    return View(db.Productos.ToList());
            }
            
        }
        public ActionResult ProductoDetalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }
        
        public ActionResult Whislist()
        {
            ViewBag.Message = "Your catalogo page.";

            return View();
        }
    }
}