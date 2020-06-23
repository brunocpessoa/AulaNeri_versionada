using AulaNeri2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaNeri2.Controllers
{
    public class cursoController : Controller
    {

        Aula2Entities tabelas = new Aula2Entities();

        // GET: curso
        public ActionResult Index()
        {
            return View(tabelas.curso.ToList());
        }

        // GET: curso/Details/5
        public ActionResult Details(int id)
        {
            var cursoEscolhido = (from cat in tabelas.curso where cat.curCodigo == id select cat).First();
            return View(cursoEscolhido);
        }

        // GET: curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: curso/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "curCodigo")] curso gravacurso)
        //public ActionResult Create(curso gravacurso)
        {
            try
            {
                tabelas.curso.Add(gravacurso);
                tabelas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: curso/Edit/5
        public ActionResult Edit(int id)
        {
            var cursoEscolhido = (from cat in tabelas.curso where cat.curCodigo == id select cat).First();
            return View(cursoEscolhido);
        }

        // POST: curso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, curso editarCurso)
        {
            try
            {
                var cursoEscolhido = (from cat in tabelas.curso where cat.curCodigo == id select cat).First();
                tabelas.curso.AddOrUpdate(editarCurso);
                var v = tabelas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: curso/Delete/5
        public ActionResult Delete(int id)
        {
            var cursoEscolhido = (from cat in tabelas.curso where cat.curCodigo == id select cat).First();
            return View(cursoEscolhido);
        }

        // POST: curso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, curso exlcuirCurso)
        {
            try
            {
                var cursoEscolhido = (from cat in tabelas.curso where cat.curCodigo == id select cat).First();
                tabelas.curso.Remove(cursoEscolhido);
                tabelas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}