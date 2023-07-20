using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("LoginTable")]
    [Index(nameof(LoginEmailId), Name = "IX_LoginTable", IsUnique = true)]
    public partial class LoginTable
    {
        public LoginTable()
        {
            NoticeTables = new HashSet<NoticeTable>();
            TeacherTables = new HashSet<TeacherTable>();
        }

        [Key]
        [Column("Login_id")]
        public int LoginId { get; set; }
        [Required]
        [Column("login_email_id")]
        [StringLength(50)]
        public string LoginEmailId { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("Is_verified")]
        public bool? IsVerified { get; set; }
        [Column("Is_user")]
        [StringLength(10)]
        public string IsUser { get; set; }
        [Column("token")]
        [StringLength(100)]
        public string Token { get; set; }
        [Column("token_expired")]
        public bool? TokenExpired { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at", TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

        [InverseProperty(nameof(NoticeTable.Login))]
        public virtual ICollection<NoticeTable> NoticeTables { get; set; }
        [InverseProperty(nameof(TeacherTable.Login))]
        public virtual ICollection<TeacherTable> TeacherTables { get; set; }
    }
}
