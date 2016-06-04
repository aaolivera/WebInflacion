using Actualizador;
using Dominio.Entidades;
using Dominio.Vistas;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio repositorio;
        public HomeController(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public ActionResult Index()
        {
            ViewBag.Datos = repositorio.ListarVista<IpcDiario>().Cast<Ipc>().ToList();
            return View();
        }

        public ActionResult BuscarMaterial(string query)
        {
            
            return Json(repositorio.Listar<Material>(x => x.Nombre.Contains(query) || x.Marca == query, 20).Select(x => new { x.Nombre, Id = x.Id + "*" + x.Nombre }),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}