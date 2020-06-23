using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace AulaNeri2.Models
{
    public class Professores
    {
        [Display(Name = "Código")]
        [HiddenInput(DisplayValue =false)]
        public int profCodigo { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome requerido")]
        public string profNome { get; set; }
        [Display(Name = "Curso que ele ministra")]
        [Required(ErrorMessage = "Curso requerido")]
        public string profCurso { get; set; }

        [Range(16,40,ErrorMessage ="A idade não está dentro do range permitido")]
        public int profIdade { get; set; }
        [DisplayFormat(DataFormatString ="dd/mm/yyyy")]
        public string profDatata { get; set; }

        [DataType(DataType.Password)]
        public string profSenha { get; set; }
        [DataType(DataType.Password)]
        [Compare("profSenha",ErrorMessage ="As senhas não conferem")]
        public string profSenha2 { get; set; }
    }
}