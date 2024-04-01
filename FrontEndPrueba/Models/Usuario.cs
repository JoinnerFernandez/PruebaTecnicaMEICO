using System.ComponentModel.DataAnnotations;

namespace FrontEndPrueba.Models
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        [Required(ErrorMessage ="El Nombre es Obligatorio")]
        public string Nombre { get; set; }

        public ICollection<Contacto>? lstContactos { get; set; }
    }
}
