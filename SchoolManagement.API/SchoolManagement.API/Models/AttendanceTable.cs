using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("AttendanceTable")]
    public partial class AttendanceTable
    {
        [Key]
        [Column("Attendance_id")]
        public int AttendanceId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("status")]
        [StringLength(10)]
        public string Status { get; set; }
        [Column("Class_id")]
        public int ClassId { get; set; }
        [Column("Student_id")]
        public int StudentId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty(nameof(ClassTable.AttendanceTables))]
        public virtual ClassTable Class { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(StudentTable.AttendanceTables))]
        public virtual StudentTable Student { get; set; }
    }
}
