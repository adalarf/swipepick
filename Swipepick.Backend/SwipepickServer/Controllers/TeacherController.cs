using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class TeacherController : Controller
    {
        [HttpGet("teacher/list")]
        public IActionResult GetTeachers()
        {
            return Ok();
        }
    }
}
