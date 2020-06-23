using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaNeri2.Controllers
{
    public class PaginaNaoExisteController : Controller
    {
        // GET: PaginaNaoExiste
        public ActionResult erro404()
        {
            return View();
        }
    }
}