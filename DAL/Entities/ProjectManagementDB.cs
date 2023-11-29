using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class ProjectManagementDB : DbContext
    {
        public ProjectManagementDB()
            : base("name=ProjectManagementDB")
        {
        }

        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<Assigments> Assigments { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLog>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Files>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<Files>()
                .Property(e => e.FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Priority)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
