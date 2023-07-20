using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("Timetable")]
    public partial class Timetable
    {
        [Key]
        [Column("Timetable_id")]
        public int TimetableId { get; set; }
        [Column("Class_id")]
        public int ClassId { get; set; }
        [Required]
        [Column("day")]
        [StringLength(10)]
        public string Day { get; set; }
        [Column("start_time")]
        public TimeSpan StartTime { get; set; }
        [Column("end_time")]
        public TimeSpan EndTime { get; set; }
        [Column("Subject_id")]
        public int SubjectId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty(nameof(ClassTable.Timetables))]
        public virtual ClassTable Class { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(SubjectTable.Timetables))]
        public virtual SubjectTable Subject { get; set; }
    }
}
