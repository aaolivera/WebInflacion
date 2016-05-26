using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Precio
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual Material Material { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual decimal PrecioMinimo { get; set; }
        public virtual decimal PrecioMaximo { get; set; }
    }
}
