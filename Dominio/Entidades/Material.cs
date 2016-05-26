using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Material
    {
        [Key]
        public virtual string Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual bool Activo { get; set; }
        public virtual ICollection<Precio> Precio { get; set; }

    }
}
