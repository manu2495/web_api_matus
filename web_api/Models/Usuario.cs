using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    [Table("auth_user", Schema = "authentication")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int IdUser { get; set; }
        [Column("username")]
        public string Username { get; set; } = "";
        [Column("password")]
        public string Password { get; set; } = "";
        [Column("email")]
        public string Email { get; set; } = "";
        [Column("first_name")]
        public string FirstName { get; set; } = "";
        [Column("last_name")]
        public string LastName { get; set; } = "";
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
