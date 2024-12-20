using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https://localhost:portnumber/api/students
        [HttpGet]
        // lets create get action method 
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Ankur", "Dhananjay", "Abhishek", "Shashank", "Sahil" };
            return Ok(studentNames);
        }
    }
}