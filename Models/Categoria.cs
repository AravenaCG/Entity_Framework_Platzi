using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Platzi.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Tareas>  Tareas { get; set; }
    }
}