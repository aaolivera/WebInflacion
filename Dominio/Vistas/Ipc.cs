using Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Vistas
{
    public class Ipc
    {
        public virtual DateTime Fecha { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual string Unidad { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}
