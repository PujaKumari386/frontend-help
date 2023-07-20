using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("TeacherTable")]
    [Index(nameof(EmailId), Name = "IX_TeacherTable", IsUnique = true)]
    public partial class TeacherTable
    {
        public TeacherTable()
        {
            ClassTables = new HashSet<ClassTable>();
            SubjectTables = new HashSet<SubjectTable>();
        }

        [Key]
        [Column("Teacher_id")]
        public int TeacherId { get; set; }
        [Required]
        [Column("email_id")]
        [StringLength(50)]
        public string EmailId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(10)]
        public string LastName { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Required]
        [Column("phone")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("salary")]
        public int Salary { get; set; }
        [Column("Login_id")]
        public int? LoginId { get; set; }
        [Required]
        [Column("password")]
        [StringLength(20)]
        public string Password { get; set; }

        [ForeignKey(nameof(LoginId))]
        [InverseProperty(nameof(LoginTable.TeacherTables))]
        public virtual LoginTable Login { get; set; }
        [InverseProperty(nameof(ClassTable.Teacher))]
        public virtual ICollection<ClassTable> ClassTables { get; set; }
        [InverseProperty(nameof(SubjectTable.Teacher))]
        public virtual ICollection<SubjectTable> SubjectTables { get; set; }
    }
}
