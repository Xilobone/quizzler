using Microsoft.AspNetCore.Mvc;
using Quizzler.Data;

namespace Quizzler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        DBContext _context;
        public QuestionsController(DBContext _context) : base()
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            return Ok(_context.Questions);
        }

        [HttpPost]
        public IActionResult AddQuestion([FromBody] Question question)
        {
            question.Id = Guid.NewGuid();
            _context.Questions.Add(question);
            _context.SaveChanges();

            return Ok($"question added {question}");
        }
    }
}