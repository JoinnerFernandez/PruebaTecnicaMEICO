using System.Diagnostics.Contracts;

namespace BackPrueba_WebAPI.Models
{
    public class Telefono
    {
        public int IdTelefono { get; set; }
        public int IdContacto { get; set; }
        public Contacto? Contacto { get; set; }
        public string NumTelefono { get; set; }
    }
}
