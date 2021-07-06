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

        public ActionResult Contacto() {

            try {
                string contenido = " El cliente" + Request.Form["nombres"].ToString() 
                    + Request.Form["apellidos"].ToString() 
                    + " ingresó el día " + DateTime.Now.ToString() + " "
                    + " Nombre de empresa: " + Request.Form["nombreEmpresa"].ToString() 
                    + " RUC: " + Request.Form["ruc"].ToString() + " Celular: " 
                    + Request.Form["celular"].ToString() + " Email: " +
                    Request.Form["email"].ToString() + " Solicitando la siguiete información: "
                    + Request.Form["mensaje"].ToString();

                enviarEmail(Request.Form["asunto"].ToString(), contenido);
                return View("Index");
            }
            catch { }                      
            return View("Index");
        }

        public void enviarEmail(string subject,string mensaje) {

            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("76927894@continental.edu.pe");
            mmsg.Subject = subject;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = mensaje;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;

            mmsg.From = new System.Net.Mail.MailAddress("fer.storetest@gmail.com");

            System.Net.Mail.SmtpClient emisor = new System.Net.Mail.SmtpClient();
            emisor.Credentials = new System.Net.NetworkCredential("fer.storetest@gmail.com", "KIPLS8899");
            emisor.Port = 587;
            emisor.EnableSsl = true;    
            emisor.Host = "smtp.gmail.com";

            emisor.Send(mmsg); 
           
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