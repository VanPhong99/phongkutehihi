using LeVanPhong_Lab3.DTOs;
using LeVanPhong_Lab3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeVanPhong_Lab3.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbConText _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbConText();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == courseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId ==attendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
