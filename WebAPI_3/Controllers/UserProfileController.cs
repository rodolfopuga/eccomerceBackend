using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI_3.Models;

namespace WebAPI_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
        

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("forAdmin")]
        public string GetForAdmin()
        {
            return "Web method for admin";
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("forUser")]
        public string GetForUser()
        {
            return "Web method for User";
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        [Route("forAdminOrUser")]
        public string GetForAdminOrUser()
        {
            return "Web method for admin or user";
        }
    }
}