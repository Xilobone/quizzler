using Microsoft.AspNetCore.Mvc;

namespace Quizzler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello");
        }
    }
}