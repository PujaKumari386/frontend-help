using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SchoolManagement.API.Models
{
    [Table("NoticeTable")]
    public partial class NoticeTable
    {
        [Key]
        [Column("Notice_id")]
        public int NoticeId { get; set; }
        [Required]
        [Column("title", TypeName = "text")]
        public string Title { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("Login_id")]
        public int LoginId { get; set; }

        [ForeignKey(nameof(LoginId))]
        [InverseProperty(nameof(LoginTable.NoticeTables))]
        public virtual LoginTable Login { get; set; }
    }
}
