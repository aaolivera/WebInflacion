using Actualizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicioActualizar repositorio;
        public HomeController(IServicioActualizar repositorio)
        {
            this.repositorio = repositorio;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public int Actualizar()
        {
            return repositorio.Actualizar();
        }
    }
}