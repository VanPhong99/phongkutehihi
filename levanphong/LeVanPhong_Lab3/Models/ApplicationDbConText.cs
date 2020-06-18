using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeVanPhong_Lab3.Models
{
    public class ApplicationDbConText : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance>Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public ApplicationDbConText()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbConText Create()
        {
            return new ApplicationDbConText();
        }
        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Course)
                .WithMany()
                .WillCascadeOnDelete(false);
          

            modelBuilder.Entity<ApplicationUser>()
               .HasMany(u => u.Followers)
               .WithRequired(f => f.Followee)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
              .HasMany(u => u.Followees)
              .WithRequired(f => f.Follower)
              .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}