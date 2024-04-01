namespace BackPrueba_WebAPI.Models
{
    public class Correo
    {
        public int IdCorreo { get; set; }
        public int IdContacto { get; set; }
        public Contacto? Contacto { get; set; }
        public string Mail { get; set; }
    }
}
