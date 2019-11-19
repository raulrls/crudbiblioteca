using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_Biblioteca.Models.EntidadesBiblioteca;


namespace WebApp_Biblioteca.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Login
        public ActionResult IniciarSesion() {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Administrador admin) {
            using (Entities dbcon = new Entities())
            {
                var nombre = dbcon.SP_login_administrador(admin.correo, admin.contrasena).ToList();
                if (nombre.Count != 0)
                {
                    return Redirect("Menu");
                }
                else
                {
                    return Redirect("IniciarSesion");
                }
                
            }
        }

        public ActionResult Menu() {
            return View();
        }


    }
}