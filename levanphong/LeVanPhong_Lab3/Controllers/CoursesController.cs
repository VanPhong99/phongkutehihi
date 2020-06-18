using LeVanPhong_Lab3.Models;
using LeVanPhong_Lab3.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeVanPhong_Lab3.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbConText _dbConText;
        public CoursesController()
        {
            _dbConText = new ApplicationDbConText();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbConText.Categories.ToList()
            };
            return View(viewModel);
        }
        // GET: Courses
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbConText.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbConText.Courses.Add(course);
            _dbConText.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}