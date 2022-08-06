using Microsoft.EntityFrameworkCore;
using web_api.Helpers;
using web_api.ModelDto;
using web_api.Models;
using web_api.ModelViews;
using web_api.Security;
using web_api.Services.Interfaces;

namespace web_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenSecurity _tokenSecurity;

        public AuthService(IConfiguration configuration, ITokenSecurity tokenSecurity)
        {
            _configuration = configuration;
            _tokenSecurity = tokenSecurity;
        }

        public TokenSecurityModel Login(AuthDto authDto)
        {
            try
            {
                using var mainContext = ContextHelper.BuildMainContext(_configuration);
                Usuario usuario = mainContext
                    .Usuarios
                    .Where(x => x.Username == authDto.Username)
                    .FirstOrDefault();

                if (usuario == null || !BCrypt.Net.BCrypt.Verify(authDto.Password, usuario.Password))
                {
                    throw new Exception("EL USUARIO NO EXISTE EN LA BD");
                }

                // BUSCAR PERMISOS
                List<Rol> roles = mainContext
                    .UsuarioRoles
                    .Include(x => x.Rol)
                    .Where(x => x.UsuarioId == usuario.IdUser)
                    .Select(x => x.Rol)
                    .ToList();

                List<Permiso> rolPermisos = mainContext
                    .RolPermisos
                    .Include(x => x.Permiso)
                    .ToList()
                    .Where(x => roles.Any(rol => rol.IdRol == x.RolId))
                    .Select(x => x.Permiso)
                    .ToList();

                List<Permiso> usuarioPermisos = mainContext
                    .UsuarioPermisos
                    .Include(x => x.Permiso)
                    .Where(x => x.UsuarioId == usuario.IdUser)
                    .Select(x => x.Permiso)
                    .ToList();

                usuarioPermisos.AddRange(rolPermisos);
                List<Permiso> permisos = usuarioPermisos.GroupBy(x => x.IdPermission).Select(x => x.First()).ToList();

                AuthView authView = new AuthView(usuario, roles, permisos);
                return _tokenSecurity.JwtSecurityToken(authView);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message);
                throw new Exception(ex.Message);
            }
        }

        public Usuario SignIn(UsuarioDto usuarioDto)
        {
            try
            {
                // BUSCAR LISTA DE USUARIOS
                using var mainContext = ContextHelper.BuildMainContext(_configuration);
                List<Usuario> usuarios = mainContext
                    .Usuarios
                    .ToList();

                if (usuarios.Any(e => e.Username == usuarioDto.Username))
                {
                    throw new Exception("YA EXISTE UN USUARIO CON ESE NOMBRE");
                }

                // ENCRIPTAR PASSWORD
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);

                // CREAR USUARIO
                Usuario usuario = new Usuario
                {
                    Username = usuarioDto.Username,
                    Password = passwordHash,
                    FirstName = usuarioDto.FirstName,
                    LastName = usuarioDto.LastName,
                    Email = usuarioDto.Email,
                    CreatedBy = usuarioDto.CreadoPor,
                    UpdatedBy = usuarioDto.CreadoPor,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true
                };

                mainContext.Usuarios.Add(usuario);
                mainContext.SaveChanges();

                return usuario;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
