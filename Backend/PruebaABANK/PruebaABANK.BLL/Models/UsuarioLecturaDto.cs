using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaABANK.BLL.Models
{
    public class UsuarioLecturaDto
    {
        public int id { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
    }
}
