using web_api.Models;

namespace web_api.ModelViews
{
    public class AuthView
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string FullName { get; set; } = "";
        public List<RolView> Groups { get; set; } = new List<RolView>();
        public List<PermisoView> Permissions { get; set; } = new List<PermisoView>();

        public AuthView(Usuario usuario, List<Rol> roles, List<Permiso> permisos)
        {
            if (usuario != null)
            {
                Id = usuario.IdUser;
                Username = usuario.Username;
                FullName = usuario.FirstName + " " + usuario.LastName;

                Groups = roles.Select(x => new RolView(x)).ToList();
                Permissions = permisos.Select(x => new PermisoView(x)).ToList();
            }
        }
    }
}
