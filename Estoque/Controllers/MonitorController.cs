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
    public class MonitorController : Controller
    {
        // GET: Monitor
        public ViewResult Index(int? pagina, string patrimonio)
        {
            int itensPorPagina = 12;
            int paginat = pagina ?? 1;

            List<MonitorModel> lista = new List<MonitorModel>();
            lista = new MonitorDao().Listar(new MonitorModel { Patrimonio = patrimonio });

            return View(lista.ToPagedList(paginat, itensPorPagina));
        }

        // GET: Monitor/Details/
        public ActionResult Details(int id)
        {
            var model = new MonitorDao().Obter(id);
            return View(model);
        }

        // GET: Monitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monitor/Create
        [HttpPost]
        public ActionResult Create(MonitorModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                new MonitorDao().Inserir(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Monitor/Edit/
        public ActionResult Edit(int id)
        {
            var model = new MonitorDao().Obter(id);
            return View(model);
        }

        // POST: Monitor/Edit/
        [HttpPost]
        public ActionResult Edit(int id, MonitorModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add update logic here
                new MonitorDao().Editar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Monitor/Delete/
        public ActionResult Delete(int id)
        {
            var model = new MonitorDao().Obter(id);
            return View(model);
        }

        // POST: Monitor/Delete/
        [HttpPost]
        public ActionResult Delete(int id, MonitorModel model)
        {
            try
            {
                new MonitorDao().Deletar(model);
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
