using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Marca
    {
        [Key]
        public virtual string Nombre { get; set; }
        public virtual ICollection<Material> Material { get; set; }
    }
}
