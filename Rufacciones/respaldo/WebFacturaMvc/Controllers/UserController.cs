using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFacturaMvc.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuario objUser)
        {
            if (ModelState.IsValid)
            {
                using (dbVentasEntities db = new dbVentasEntities())
                {
                    var obj = db.usuarios.Where(a => a.Usuario1.Equals(objUser.Usuario1) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.IdUsuario.ToString();
                        Session["UserName"] = obj.Usuario1.ToString();
                        return RedirectToAction("Index","Inicio");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}