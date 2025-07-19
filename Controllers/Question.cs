using Microsoft.AspNetCore.Mvc;
using Quizzler.Data;
using Quizzler.Models;

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
            List<Question> questions = new List<Question>();

            foreach (Question question in _context.Questions)
            {
                if (question.GetType() == typeof(OpenQuestion)) questions.Add((OpenQuestion)question);
            }
            return Ok(_context.Questions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(string id)
        {
            if (!Guid.TryParse(id, out Guid guid)) return BadRequest("Not a valid guid");
            

            Question? question = _context.Questions.FirstOrDefault(question => question.Id == guid);

            if (question == null) return NotFound($"No question with guid {guid} was found");
            return Ok(question);
        }

        [HttpPost("open")]
        public IActionResult AddOpenQuestion([FromBody] OpenQuestion question)
        {
            question.Process();
            Console.WriteLine(question);
            _context.Questions.Add(question);
            _context.SaveChanges();

            return Ok($"question added {question}");
        }

        [HttpPost("multiplechoice")]
        public IActionResult AddMultipleChoiceQuestion([FromBody] MultipleChoiceQuestion question)
        {
            question.Process();

            _context.Questions.Add(question);
            _context.SaveChanges();

            return Ok($"question added {question}");
        }

        [HttpPost("binary")]
        public IActionResult AddBinaryQuestion([FromBody] BinaryQuestion question)
        {
            question.Process();
            _context.Questions.Add(question);
            _context.SaveChanges();

            return Ok($"question added {question}");
        }

        [HttpPost("numeric")]
        public IActionResult AddNumericQuestion([FromBody] NumericQuestion question)
        {
            question.Process();
            _context.Questions.Add(question);
            _context.SaveChanges();

            return Ok($"question added {question}");
        }
    }
}