using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Platzi.Models
{
    public class Tareas
    {
        public Guid TareaId { get; set; }
        public Guid CategoriaId { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }

}