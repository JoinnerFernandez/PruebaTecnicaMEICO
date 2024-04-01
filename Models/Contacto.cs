namespace BackPrueba_WebAPI.Models
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }    
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Empresa { get; set; }
        public string Nota { get; set; }

        public ICollection<Telefono> lstTelefonos { get; set;}
        public ICollection<Correo> lstCorreos { get; set; }
    }
}
