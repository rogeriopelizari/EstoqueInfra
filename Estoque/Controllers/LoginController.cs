using Estoque.Dao;
using Estoque.Models;
using System;
using System.Web.Mvc;


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
        public ActionResult Autherize(UsuarioLoginViewModel loginViewModel)
        {
            var dao = new UsuarioDao();
            try
            {
                var model = dao.Login(loginViewModel.Login, loginViewModel.Senha);
                if (model == null)
                {
                    ModelState.AddModelError("Login", "Usuário ou Senha inválidos!");
                    return View("Index");
                }
                else
                {
                    Session["UserID"] = model.Id;
                    Session["Usuario"] = model;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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