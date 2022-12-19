using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SwipepickServer.Controllers
{
    [ApiController]
    [Route("api/user/auth")]
    public class UserAutnController : Controller
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Json(new TestClass() { Question ="who are u?", Answer="kirill sloboda"});
        }
        private class TestClass
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }

    }
}
