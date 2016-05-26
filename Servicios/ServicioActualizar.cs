using Dominio.Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Actualizador
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicioActualizar : IServicioActualizar
    {
        private readonly IRepositorio repositorio;
        public ServicioActualizar(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        private dynamic EnviarConsulta(int pagina, int limit)
        {
            var url = $"https://8kdx6rx8h4.execute-api.us-east-1.amazonaws.com/prod/productos?string&lat=-34.5825338&lng=-58.4725089&offset={pagina}&limit={limit}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();

            StreamReader objReader = new StreamReader(resStream);

            string sLine = "";
            string respuesta = "";

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                respuesta += sLine;
            }

            return Json.Decode(respuesta);
        }

        private int CantidadDeProductos()
        {
            var consulta = EnviarConsulta(0, 0);
            return consulta.total;
        }

        private async Task<int> ActualizarOffset(int pagina)
        {
            var data = EnviarConsulta(pagina, 100);

            foreach (var producto in data.productos)
            {
                var material = repositorio.Obtener<Material>(producto.id);
                if (material == null)
                {
                    var marca = repositorio.Obtener<Marca>(producto.marca);
                    material = new Material
                    {
                        Activo = true,
                        Id = producto.id,
                        Nombre = producto.nombre,
                        Marca = marca ?? new Marca { Nombre = producto.marca }
                    };
                    repositorio.Agregar(material);
                }
                repositorio.Agregar(new Precio
                {
                    Fecha = DateTime.Now,
                    Material = material,
                    PrecioMaximo = Convert.ToDecimal(producto.precioMax),
                    PrecioMinimo = Convert.ToDecimal(producto.precioMin),

                });
                
            }
            repositorio.GuardarCambios();
            Console.WriteLine($"Pagina analizada: {pagina}");
            return data.productos.Length;
        }

        private async Task<int> ActualizarAsync()
        {
            var offset = 1;
            var actualizadosTotal = 10;//CantidadDeProductos();
            var tasks = new List<Task>();
            while (offset < actualizadosTotal)
            {
                tasks.Add(ActualizarOffset(offset));
                offset++;
            }

            Task.WaitAll(tasks.ToArray());


            return 1;
        }

        public int Actualizar()
        {
            var task = ActualizarAsync();

            return task.Result;
        }

    }
}