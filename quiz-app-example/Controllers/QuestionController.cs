using Microsoft.AspNetCore.Mvc;
using quiz_app_example.Model;
using quiz_app_example.Processing;

namespace quiz_app_example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {


        private readonly ILogger<QuestionController> _logger;
        private readonly QuestionProcessing _questionProcessing;

        public QuestionController(ILogger<QuestionController> logger, QuestionProcessing questionProcessing)
        {
            _logger = logger;
            _questionProcessing = questionProcessing;
        }

        [HttpGet(Name = "GetAllQuiz")]
        public async Task<ActionResult<List<Question>>> Get()
        {
           
            return await _questionProcessing.GetAllQuestions();
        }

        [HttpDelete(Name = "DeleteAQuiz")]
        public async Task<ActionResult<Response>> Delete(String id)
        {
            return await _questionProcessing.DeleteQuestion(id);
        }

    }

}