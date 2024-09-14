namespace PruebaABANK.API.Models
{
    public class Usuario
    {
        public  int id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
