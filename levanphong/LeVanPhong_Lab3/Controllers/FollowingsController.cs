using LeVanPhong_Lab3.DTOs;
using LeVanPhong_Lab3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LeVanPhong_Lab3.Controllers
{
    public class FollowingsController:ApiController
    {
        private readonly ApplicationDbConText _dbConText;
        public FollowingsController()
        {
            _dbConText = new ApplicationDbConText();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbConText.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exists");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbConText.Followings.Add(folowing);
            _dbConText.SaveChanges();
            return Ok();
        }
    }
}