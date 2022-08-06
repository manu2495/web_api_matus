using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    [Table("auth_group", Schema = "authentication")]
    public class Rol
    {
        [Key]
        [Column("id")]
        public int IdRol { get; set; }
        [Column("name")]
        public string Nombre { get; set; } = "";
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
    }
}
