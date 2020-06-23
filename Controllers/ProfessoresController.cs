using AulaNeri2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaNeri2.Controllers
{
    public class ProfessoresController : Controller
    {
        private ProfessoresCrud profcrud;
        public ProfessoresController()
        {
            profcrud = ProfessoresFactory.InstanciarProfessores();
        }
        // GET: Professores
        public ActionResult Index()//Listar todos
        {
            //var professores = ProfessoresCrud.ListaProfessores(); Listar todos
            var professores = profcrud.ListaProfessores();
            return View(professores);
        }
        public ActionResult ListaUm()
        {
            //var professores = ProfessoresCrud.ListaProfessores()[0]; //Listar somente o índice
            var professores = profcrud.ListaProfessores()[1];
            return View(professores);
        }

        public ActionResult NovoProfessor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NovoProfessor(Professores professor)
        {
            //var ultimoProfessor = ProfessoresFactory.InstanciarProfessores().ListaProfessores().
            //                        OrderByDescending(prof => prof.profCodigo).FirstOrDefault();//peguei o último código
            //professor.profCodigo = ultimoProfessor.profCodigo + 1;
            //ProfessoresFactory.InstanciarProfessores().InserirProfessor(professor);
            //var professores = ProfessoresFactory.InstanciarProfessores().ListaProfessores();

            if (ModelState.IsValid)
            {
                TempData["mensagem"] = "Professor gravado com sucesso";

                var ultimoProfessor = profcrud.ListaProfessores().
                                        OrderByDescending(prof => prof.profCodigo).FirstOrDefault();//peguei o último código
                professor.profCodigo = ultimoProfessor.profCodigo + 1;
                profcrud.InserirProfessor(professor);
                var professores = profcrud.ListaProfessores();
                return View("Index", professores);
            }
            else
                return View();

        }
        public ActionResult EditarProfessor(int id)
        {
            //var qualProfessor = profcrud.ListaProfessores()[id];
            var qualProfessor = profcrud.ListaProfessores().Where(prof => prof.profCodigo == id).FirstOrDefault();
            return View(qualProfessor);
        }
        [HttpPost]
        public ActionResult EditarProfessor(Professores professor)
        {
            if (ModelState.IsValid)
            {
                profcrud.AlterarProfessor(professor);
                var professores = profcrud.ListaProfessores();

                TempData["mensagem"] = "Professor alterado com sucesso";
                return View("Index", professores);
            }
            else
                return View();

        }
        public ActionResult ExcluirProfessor(int id)
        {
            //var qualProfessor = profcrud.ListaProfessores()[id];
            var qualProfessor = profcrud.ListaProfessores().Where(prof => prof.profCodigo == id).FirstOrDefault();
            return View(qualProfessor);
        }
        [HttpPost]
        public ActionResult ExcluirProfessorSim(Professores professor)
        {
            profcrud.excluirProfessor(professor);
            var professores = profcrud.ListaProfessores();
            TempData["mensagem"] = "Professor foi excluído";
            return View("Index", professores);
        }
    }
}