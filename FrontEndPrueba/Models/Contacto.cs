using System.ComponentModel.DataAnnotations;

namespace FrontEndPrueba.Models
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public string Nota { get; set; } = string.Empty;

        public ICollection<Telefono> lstTelefonos { get; set; } = new List<Telefono>();
        public ICollection<Correo> lstCorreos { get; set; } = new List<Correo>();
    }
}
