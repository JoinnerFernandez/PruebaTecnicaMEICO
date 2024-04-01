using System.ComponentModel.DataAnnotations;

namespace FrontEndPrueba.Models
{
    public class Telefono
    {
        public int IdTelefono { get; set; }
        public int IdContacto { get; set; }
        public Contacto? Contacto { get; set; }
        [Required(ErrorMessage ="El Telefono no puede ir vacio")]
        public string NumTelefono { get; set; }
    }
}
