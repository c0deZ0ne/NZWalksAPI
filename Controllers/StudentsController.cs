using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{

    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET https://localhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents() {
            var studentNames = new string[] { "John", "Praise"};
            return Ok(studentNames);
        }
    }
}
