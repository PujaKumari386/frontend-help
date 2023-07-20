using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("SubjectTable")]
    [Index(nameof(SubjectName), Name = "IX_SubjectTable", IsUnique = true)]
    public partial class SubjectTable
    {
        public SubjectTable()
        {
            Timetables = new HashSet<Timetable>();
        }

        [Key]
        [Column("Subject_id")]
        public int SubjectId { get; set; }
        [Required]
        [Column("Subject_name")]
        [StringLength(10)]
        public string SubjectName { get; set; }
        [Column("Teacher_id")]
        public int TeacherId { get; set; }
        [Column("Class_id")]
        public int ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty(nameof(ClassTable.SubjectTables))]
        public virtual ClassTable Class { get; set; }
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty(nameof(TeacherTable.SubjectTables))]
        public virtual TeacherTable Teacher { get; set; }
        [InverseProperty(nameof(Timetable.Subject))]
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}
