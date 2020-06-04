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
        public ApplicationDbConText()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbConText Create()
        {
            return new ApplicationDbConText();
        }
    }
}