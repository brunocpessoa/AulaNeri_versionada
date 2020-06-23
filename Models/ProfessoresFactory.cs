using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaNeri2.Models
{
    public class ProfessoresFactory
    {
        public static ProfessoresCrud InstanciarProfessores()
        {
            if(HttpContext.Current.Application["cadastroProfessor"] == null)
            {
                return new ProfessoresCrud();
            }
            return (ProfessoresCrud)HttpContext.Current.Application["cadastroProfessor"];
            
        }
    }
}