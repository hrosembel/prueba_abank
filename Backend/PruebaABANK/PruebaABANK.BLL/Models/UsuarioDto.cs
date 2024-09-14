namespace PruebaABANK.BLL.Models
{
    public class UsuarioDto
    {
        public  int id { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Direccion { get; set; }
        public required string Password { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
    }
}
