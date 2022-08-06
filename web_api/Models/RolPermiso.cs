using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    [Table("auth_group_permission", Schema = "authentication")]
    public class RolPermiso
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("auth_group_id")]
        public int RolId { get; set; }
        [Column("auth_permission_id")]
        public int PermisoId { get; set; }
        [Column("active")]
        public bool IsActive { get; set; } = true;
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; } = "";
        [Column("updated_by")]
        public string UpdatedBy { get; set; } = "";
        public virtual Rol Rol { get; set; }
        public virtual Permiso Permiso { get; set; }
    }
}
