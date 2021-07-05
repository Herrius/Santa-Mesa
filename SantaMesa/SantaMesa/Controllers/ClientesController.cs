﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using SantaMesa.Models;

namespace SantaMesa.Controllers
{
    public class ClientesController : Controller
    {
        private BD_SantaMesaEntities db = new BD_SantaMesaEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        public ActionResult Login() {
            return View();
        }
        public ActionResult Cuenta()
        {
            int id =6;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        [HttpPost]
        public ActionResult ActualizarDatos(){

            Clientes clientes=new Clientes();

            clientes.id_Cliente = 1;
            clientes.nombres= Request.Form["name"].ToString();
            clientes.telefono= Request.Form["telefono"].ToString();
            clientes.email = Request.Form["email"].ToString();
            clientes.dni = Request.Form["dni"].ToString();
            clientes.direccion = Request.Form["direccion"].ToString();
            clientes.ciudad = Request.Form["ciudad"].ToString();

            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        public ActionResult LoginValidador()
        {

            string emailR = Request.Form["username"].ToString();
            string passwordR = Request.Form["password"].ToString();
            try
            {   
                Clientes clientes = db.Clientes.Single(a => a.email == emailR);
                //Clientes clientes = db.Clientes.Find(1);
                if (clientes == null || clientes.clave!=passwordR)
                {
                    return View("Login");
                }
                else
                {
                    return View("Cuenta", clientes);
                }
            }
            catch
            {
                return View("Login");
            }
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Cliente,nombres,telefono,email,direccion,dni,ciudad,estado,clave")] Clientes clientes)
        {
           try {
                if (ModelState.IsValid)
                {
                    db.Clientes.Add(clientes);
                    clientes.estado = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(clientes);

            } catch {
                ViewBag.mensaje = "El email ya se encuentra registrado";
                return View();
            }

        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Cliente,nombres,telefono,email,direccion,dni,ciudad,estado")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
