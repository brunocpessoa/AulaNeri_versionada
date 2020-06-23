using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaNeri2.Models
{
    public class ProfessoresCrud
    {
        private static IList<Professores> professores;

        public ProfessoresCrud()//Método construtor
        {
            professores = new List<Professores>();
            professores.Add(new Professores()
            {
                profCodigo = 1,
                profCurso = "ASP.NET",
                profNome = "Bruno"

            });
            professores.Add(new Professores()
            {
                profCodigo = 2,
                profCurso = "História do Brasil",
                profNome = "Carlos"

            });
            professores.Add(new Professores()
            {
                profCodigo = 3,
                profCurso = "Culinária",
                profNome = "Viviane"

            });
            professores.Add(new Professores()
            {
                profCodigo = 4,
                profCurso = "Cosmética",
                profNome = "Viviane"

            });
            professores.Add(new Professores()
            {
                profCodigo = 5,
                profCurso = "Saber viver",
                profNome = "Viviane"

            });
            professores.Add(new Professores()
            {
                profCodigo = 6,
                profCurso = "Coisas da vida",
                profNome = "Viviane"

            });
        }

        public IList<Professores> ListaProfessores()
        {
            return professores;
        }

        public void InserirProfessor(Professores professor)
        {
            professores.Add(professor);
        }
        public void AlterarProfessor(Professores professor)
        {
            professores.Where(prof => prof.profCodigo == professor.profCodigo).FirstOrDefault().profNome = professor.profNome;
            professores.Where(prof => prof.profCodigo == professor.profCodigo).FirstOrDefault().profCurso = professor.profCurso;
        }

        public void excluirProfessor(Professores professor)
        {
            professores.Remove(professores.Where(prof => prof.profCodigo == professor.profCodigo).First());
        }
        //public static IList<Professores> ListaProfessores() Método comum
        //{
        //    professores = new List<Professores>();
        //    professores.Add(new Professores()
        //    {
        //        profCodigo = 1,
        //        profCurso = "ASP.NET",
        //        profNome = "Bruno"

        //    });
        //    professores.Add(new Professores()
        //    {
        //        profCodigo = 2,
        //        profCurso = "História do Brasil",
        //        profNome = "Carlos"

        //    });
        //    professores.Add(new Professores()
        //    {
        //        profCodigo = 3,
        //        profCurso = "Culinária",
        //        profNome = "Viviane"

        //    });
        //    return professores;
        //}
    }
}