using System.ComponentModel.DataAnnotations;

namespace web_api.ModelDto
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        public string Email { get; set; }
        public bool Activo { get; set; } = true;
        public string CreadoPor { get; set; } = "NA";
    }
}
