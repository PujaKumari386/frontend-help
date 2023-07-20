using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("ClassTable")]
    [Index(nameof(ClassName), Name = "IX_ClassTable", IsUnique = true)]
    public partial class ClassTable
    {
        public ClassTable()
        {
            AttendanceTables = new HashSet<AttendanceTable>();
            SubjectTables = new HashSet<SubjectTable>();
            Timetables = new HashSet<Timetable>();
        }

        [Key]
        [Column("Class_id")]
        public int ClassId { get; set; }
        [Required]
        [Column("Class_name")]
        [StringLength(10)]
        public string ClassName { get; set; }
        [Column("Teacher_id")]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty(nameof(TeacherTable.ClassTables))]
        public virtual TeacherTable Teacher { get; set; }
        [InverseProperty(nameof(AttendanceTable.Class))]
        public virtual ICollection<AttendanceTable> AttendanceTables { get; set; }
        [InverseProperty(nameof(SubjectTable.Class))]
        public virtual ICollection<SubjectTable> SubjectTables { get; set; }
        [InverseProperty(nameof(Timetable.Class))]
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}
