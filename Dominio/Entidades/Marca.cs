using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Marca
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual ICollection<Material> Material { get; set; }
    }
}
