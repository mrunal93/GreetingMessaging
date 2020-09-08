using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GreetingMessagingBussinessLayer;
using GreetingMessagingModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreetingMessagingApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingEmployeeController : Controller
    {
        private readonly IGreetingMessagingBussiness messagingBussiness;
        public GreetingEmployeeController(IGreetingMessagingBussiness messagingBussiness)
        {
            this.messagingBussiness = messagingBussiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GreetingEmployeeDetails>> GetAllEmployees()
        {
            var employeeResult = messagingBussiness.GetAllEmployees();
            try
            {
                if (employeeResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of Employees", employeeResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of Employees is Not Found", employeeResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of Employees cannot be displayed", null));
            }
        }

        [HttpPost]
        public IActionResult AddEmployeeData(GreetingEmployeeDetails employeeDetails)
        {
            var employeeResult = messagingBussiness.AddEmployeeData(employeeDetails);
            try
            {
                if (employeeResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of Employees", employeeResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of Employees is Not Found", employeeResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of Employees cannot be displayed", null));
            }
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeData(int Id)
        {
            var employeeResult = messagingBussiness.DeleteEmployeeData(Id);
            try
            {
                if (employeeResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of Employees", employeeResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of Employees is Not Found", employeeResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of Employees cannot be displayed", null));
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployeeData(GreetingEmployeeDetails employeeDetails)
        {
            var employeeResult = messagingBussiness.UpdateEmployeeData(employeeDetails);
            try
            {
                if (employeeResult != null)
                {
                    return Ok(new Response(HttpStatusCode.OK, "List of Employees", employeeResult));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List of Employees is Not Found", employeeResult));
            }
            catch (Exception)
            {

                return BadRequest(new Response(HttpStatusCode.BadRequest, "List of Employees cannot be displayed", null));
            }
        }

    }
}
