using LeVanPhong_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeVanPhong_Lab3.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcomingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}