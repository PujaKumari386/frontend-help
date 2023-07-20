using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("StudentTable")]
    [Index(nameof(EmailId), Name = "IX_StudentTable", IsUnique = true)]
    public partial class StudentTable
    {
        public StudentTable()
        {
            AttendanceTables = new HashSet<AttendanceTable>();
            LeaveTables = new HashSet<LeaveTable>();
        }

        [Key]
        [Column("Student_id")]
        public int StudentId { get; set; }
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
        [Column("Class_id")]
        public int? ClassId { get; set; }
        [Column("Login_id")]
        public int? LoginId { get; set; }
        [Required]
        [Column("password")]
        [StringLength(20)]
        public string Password { get; set; }

        [InverseProperty(nameof(AttendanceTable.Student))]
        public virtual ICollection<AttendanceTable> AttendanceTables { get; set; }
        [InverseProperty(nameof(LeaveTable.Student))]
        public virtual ICollection<LeaveTable> LeaveTables { get; set; }
    }
}
