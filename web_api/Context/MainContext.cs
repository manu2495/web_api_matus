using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolPermiso>()
                .HasOne(x => x.Rol)
                .WithMany()
                .HasForeignKey(x => x.RolId);

            modelBuilder.Entity<RolPermiso>()
                .HasOne(x => x.Permiso)
                .WithMany()
                .HasForeignKey(x => x.PermisoId);

            modelBuilder.Entity<UsuarioRol>()
               .HasOne(x => x.Rol)
               .WithMany()
               .HasForeignKey(x => x.RolId);

            modelBuilder.Entity<UsuarioRol>()
                .HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<UsuarioPermiso>()
               .HasOne(x => x.Usuario)
               .WithMany()
               .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<UsuarioPermiso>()
                .HasOne(x => x.Permiso)
                .WithMany()
                .HasForeignKey(x => x.PermisoId);
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<UsuarioPermiso> UsuarioPermisos { get; set; }
    }
}
