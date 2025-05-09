using System.ComponentModel.DataAnnotations;

namespace Proyecto_Tokens.Models
{
    public class UserModels
    {
        public int ID { get; set; }

        [Required]
        public string Nombre_Usuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [EmailAddress]
        public string Correo_Electronico { get; set; }

        [Required]
        public string Rol { get; set; }

        public bool Activo { get; set; }
      
        public ICollection<LoginRegistro> RegistrosLogin { get; set; }
    }
}