using System.ComponentModel.DataAnnotations;

namespace BackPrueba_WebAPI.Models
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set;}

        public ICollection<Contacto>? lstContactos { get; set; }
    }
}
