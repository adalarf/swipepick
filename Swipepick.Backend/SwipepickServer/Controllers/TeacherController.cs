using DAL.Entities.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class TeacherController : Controller
    {
        private ITeacherRepository _teacher;

        public TeacherController(ITeacherRepository repository)
        {
            _teacher = repository;
        }

        [HttpGet("teacher/list")]
        public IActionResult GetTeachers()
        {
            var all = _teacher.GetAll();
            return Ok(all);
        }
    }
}
