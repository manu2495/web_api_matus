using System.ComponentModel.DataAnnotations;

namespace web_api.ModelDto
{
    public class AuthDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}
