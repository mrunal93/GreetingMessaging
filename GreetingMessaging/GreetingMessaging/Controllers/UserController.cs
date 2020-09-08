using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GreetingMessagingModelLayer;
using GreetingMessagingRepositoryLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreetingMessaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var userResult = userRepository.GetUsers();
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
            var userResult = userRepository.AddUserModelData(user);
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User Cridential", userResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of User Cridential Not Found", userResult));
            }
            catch(System.Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of User Cridential Cant be display", null));
            }
        }


        [HttpDelete]
        public IActionResult DeleteUserModelData(int userId)
        {
            var userResult = userRepository.DeleteUserModelData(userId);
            try
            {
                if (userResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of User", userResult));
                }
                return NotFound();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}
