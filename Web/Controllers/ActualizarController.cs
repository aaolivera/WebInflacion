using Actualizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ActualizarController : Controller
    {
        private readonly IServicioActualizar repositorio;
        public ActualizarController(IServicioActualizar repositorio)
        {
            this.repositorio = repositorio;
        }

        public ActionResult Index()
        {
            ViewBag.CantidadDeProductos = repositorio.CantidadDeProductos();
            return View();
        }

       

        public bool Actualizar(int offset)
        {
            return repositorio.Actualizar(offset);
        }
    }
}