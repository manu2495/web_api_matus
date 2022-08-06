using web_api.Models;

namespace web_api.ModelViews
{
    public class PermisoView
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public PermisoView(Permiso permiso)
        {
            if (permiso != null)
            {
                Id = permiso.IdPermission;
                Name = permiso.Nombre;
                Code = permiso.Codigo;
            }
        }
    }
}
