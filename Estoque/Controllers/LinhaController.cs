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
    public class LinhaController : Controller
    {
        // GET: Linha
        public ViewResult Index(int? pagina, string numero)
        {
            int itensPorPagina = 12;
            int paginat = pagina ?? 1;

            List<LinhaModel> lista = new List<LinhaModel>();
            lista = new LinhaDao().Listar(new LinhaModel { Numero = numero });

            return View(lista.ToPagedList(paginat, itensPorPagina )) ;
        }

        // GET: Linha/Details/
        public ActionResult Details(int id)
        {
            var model = new LinhaDao().Obter(id);
            return View(model);
        }

        // GET: Linha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Linha/Create
        [HttpPost]
        public ActionResult Create(LinhaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                new LinhaDao().Inserir(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Linha/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new LinhaDao().Obter(id);
            return View(model);
        }

        // POST: Linha/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LinhaModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add update logic here
                new LinhaDao().Editar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Linha/Delete/
        public ActionResult Delete(int id)
        {
            var model = new LinhaDao().Obter(id);
            return View(model);
        }

        // POST:Linha/Delete/
        [HttpPost]
        public ActionResult Delete(int id, LinhaModel model)
        {
            try
            {
                new LinhaDao().Deletar(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        
        // GET: Linha/Pesquisa  
        // public ActionResult Pesquisa()
       //  {
       //     var model = new LinhaDao.
       //  }
        

    }
}
