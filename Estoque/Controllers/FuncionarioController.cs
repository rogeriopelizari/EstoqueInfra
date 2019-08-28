using Estoque.Dao;
using Estoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Estoque.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ViewResult Index(int? pagina)
        {
            int itensPorPagina = 12;
            int paginat = pagina ?? 1;

            List<FuncionarioModel> lista = new List<FuncionarioModel>();
            lista = new FuncionarioDao().Listar(new FuncionarioModel());

            return View(lista.ToPagedList(paginat, itensPorPagina));
        }

        // GET: Funcionario/Details/
        public ActionResult Details(int id)
        {
            var model = new FuncionarioDao().Obter(id);
            return View(model);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        public ActionResult Create(FuncionarioModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                new FuncionarioDao().Inserir(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new FuncionarioDao().Obter(id);
            return View(model);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FuncionarioModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add update logic here
                new FuncionarioDao().Editar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new FuncionarioDao().Obter(id);
            return View(model);
        }

        // POST:Funcionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FuncionarioModel model)
        {
            try
            {
                new FuncionarioDao().Deletar(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
