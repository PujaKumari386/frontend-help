using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchoolManagement.API.Models
{
    public partial class MydatabaseContext : DbContext
    {
        public MydatabaseContext()
        {
        }

        public MydatabaseContext(DbContextOptions<MydatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttendanceTable> AttendanceTables { get; set; }
        public virtual DbSet<ClassTable> ClassTables { get; set; }
        public virtual DbSet<LeaveTable> LeaveTables { get; set; }
        public virtual DbSet<LoginTable> LoginTables { get; set; }
        public virtual DbSet<NoticeTable> NoticeTables { get; set; }
        public virtual DbSet<StudentTable> StudentTables { get; set; }
        public virtual DbSet<SubjectTable> SubjectTables { get; set; }
        public virtual DbSet<TeacherTable> TeacherTables { get; set; }
        public virtual DbSet<Timetable> Timetables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PUJA\\MSSQLSERVER01; database=Mydatabase; trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AttendanceTable>(entity =>
            {
                entity.Property(e => e.Status).IsFixedLength(true);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AttendanceTables)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttendanceTable_ClassTable");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AttendanceTables)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttendanceTable_StudentTable");
            });

            modelBuilder.Entity<ClassTable>(entity =>
            {
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ClassTables)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassTable_TeacherTable");
            });

            modelBuilder.Entity<LeaveTable>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.LeaveTables)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveTable_StudentTable");
            });

            modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.Property(e => e.IsUser).IsUnicode(false);
            });

            modelBuilder.Entity<NoticeTable>(entity =>
            {
                entity.HasOne(d => d.Login)
                    .WithMany(p => p.NoticeTables)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoticeTable_LoginTable");
            });

            modelBuilder.Entity<SubjectTable>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SubjectTables)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectTable_ClassTable");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.SubjectTables)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectTable_TeacherTable");
            });

            modelBuilder.Entity<TeacherTable>(entity =>
            {
                entity.HasOne(d => d.Login)
                    .WithMany(p => p.TeacherTables)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK_TeacherTable_LoginTable");
            });

            modelBuilder.Entity<Timetable>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Timetables)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Timetable_ClassTable");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Timetables)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Timetable_SubjectTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
