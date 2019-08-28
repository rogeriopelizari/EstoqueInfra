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
    public class CelularController : Controller
    {
        // GET: Celular
        public ViewResult Index(int? pagina)
        {
            int itensPorPagina = 12;
            int paginat = pagina ?? 1;

            List<CelularModel> lista = new List<CelularModel>();
            lista = new CelularDao().Listar(new CelularModel());

            return View(lista.ToPagedList(paginat, itensPorPagina));
        }

        // GET: Celular/Details/5
        public ActionResult Details(int id)
        {
            var model = new CelularDao().Obter(id);
            return View(model);
        }

        // GET: Celular/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Celular/Create
        [HttpPost]
        public ActionResult Create(CelularModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                new CelularDao().Inserir(model);
                               
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Celular/Edit/
        public ActionResult Edit(int id)
        {
            var model = new CelularDao().Obter(id);
            return View(model);
        }

        // POST: Celular/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CelularModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add update logic here
                new CelularDao().Editar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Celular/Delete/
        public ActionResult Delete(int id)
        {
            var model = new CelularDao().Obter(id);
            return View(model);
        }

        // POST:Celular/Delete/
        [HttpPost]
        public ActionResult Delete(int id, CelularModel model)
        {
            try
            {
                new CelularDao().Deletar(model);
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
