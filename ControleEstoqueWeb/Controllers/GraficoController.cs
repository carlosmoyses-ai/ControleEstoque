using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoqueWeb.Controllers
{
    public class GraficoController : Controller
    {
        // GET: Grafico
        public ActionResult PerdaMes()
        {
            return View();
        }
        public ActionResult EntradaSaidaMes()
        {
            return View();
        }

    }
}