using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Context
{
    public class DatabaseContext : DbContext
    {
        #region DbSet
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamTaken> ExamsTaken { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=OnlineExam;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Exams)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.TimeSlot)
                .WithOne(ts => ts.Exam)
                .HasForeignKey<TimeSlot>(ts => ts.ExamId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Professors)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Professors)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Exam)
                .WithMany(e => e.Questions)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
