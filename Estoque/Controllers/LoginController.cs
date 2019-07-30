using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Estoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //
        [HttpPost]
        public ActionResult Autherize(Estoque.Models.login userModel)
        {
            using (EstoqueInfraEntities db = new EstoqueInfraEntities())
            {
                try
                {
                    login userDetails = db.logins.Where(x => x.usuario == userModel.usuario && x.senha == userModel.senha).FirstOrDefault();
                    if (userDetails == null)
                    {
                        userModel.LoginErrorMessage = "Usuário ou Senha inválidos!";
                        return View("Index", userModel);
                    }
                    else
                    {
                        Session["userID"] = userDetails.UserID;
                        Session["Usuario"] = userDetails.usuario;
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}