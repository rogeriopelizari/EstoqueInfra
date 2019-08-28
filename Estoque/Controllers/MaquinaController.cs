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
    public class MaquinaController : Controller
    {
        // GET: Maquina
        public ViewResult Index(int? pagina)
        {
            int itensPorPagina = 12;
            int paginat = pagina ?? 1;

            List<MaquinaModel> lista = new List<MaquinaModel>();
            lista = new MaquinaDao().Listar(new MaquinaModel());

            return View(lista.ToPagedList(paginat, itensPorPagina));
        }

        // GET: Maquina/Details/5
        public ActionResult Details(int id)
        {
            var model = new MaquinaDao().Obter(id);
            return View(model);
        }

        // GET: Maquina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maquina/Create
        [HttpPost]
        public ActionResult Create(MaquinaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                new MaquinaDao().Inserir(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Maquina/Edit/
        public ActionResult Edit(int id)
        {
            var model = new MaquinaDao().Obter(id);
            return View(model);
        }

        // POST: Maquina/Edit/
        [HttpPost]
        public ActionResult Edit(int id, MaquinaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add update logic here
                new MaquinaDao().Editar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Maquina/Delete/
        public ActionResult Delete(int id)
        {
            var model = new MaquinaDao().Obter(id);
            return View(model);
        }

        // POST: Maquina/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MaquinaModel model)
        {
            try
            {
                new MaquinaDao().Deletar(model);
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
