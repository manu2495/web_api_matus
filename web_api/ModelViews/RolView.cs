using web_api.Models;

namespace web_api.ModelViews
{
    public class RolView
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public RolView(Rol rol)
        {
            if (rol != null)
            {
                Id = rol.IdRol;
                Name = rol.Nombre;
            }
        }
    }
}
