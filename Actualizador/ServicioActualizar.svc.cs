using Dominio.Entidades;
using Repositorio;
using System;
using System.IO;
using System.Net;
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

        public async void ActualizarOffset(int pagina)
        {
            var url = $"https://8kdx6rx8h4.execute-api.us-east-1.amazonaws.com/prod/productos?string&lat=-34.5825338&lng=-58.4725089&offset={pagina}&limit=100";

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

            dynamic data = Json.Decode(respuesta);

            foreach (var producto in data.productos)
            {
                var material = repositorio.Obtener<Material>(producto.id);
                if(material == null)
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
                material.Precio.Add(new Precio {
                    Fecha = DateTime.Now,
                    Material = material,
                    PrecioMaximo = Convert.ToDecimal(producto.precioMax),
                    PrecioMinimo = Convert.ToDecimal(producto.precioMin),

                });                
            }
            repositorio.GuardarCambios();
        }
        public string Actualizar()
        {
            var offset = 1;
            ActualizarOffset(offset);



            return "1";
        }
        
    }
}
