using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GreetingMessagingBussinessLayer;
using GreetingMessagingModelLayer;
using GreetingMessagingRepositoryLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GreetingMessagingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IUserBussiness userBussiness;

        public UserController(IUserBussiness userBussiness,IConfiguration config)
        {
            this.config = config;
            this.userBussiness = userBussiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            var userResult = userBussiness.GetUsers();
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User is Not Found", userResult));
            }
            catch (System.Exception)
            {
                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User cannot be displayed", null));
            }
        }

        [HttpPost]
        public IActionResult AddUserModelData(UserModel user)
        {
            var userResult = userBussiness.UserRegistrationData(user);
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User Cridential", userResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User Cridential Not Found", userResult));
            }
            catch (System.Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User Cridential Cant be display", null));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(UserLoginData))]
        public IActionResult UserLoginData(UserModel user)
        {
            
            var userResult = userBussiness.UserLoginData(user);
            try
            {
                if (userResult != null)
                {
                   var jsonToken = userBussiness.GenerateToken(userResult,"User");

                    return Ok(new Response(HttpStatusCode.OK, "login done successfully",jsonToken));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List not fount", userResult));

            }
            catch (System.Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List canot display",null));
            }
        }

       
    }
}
