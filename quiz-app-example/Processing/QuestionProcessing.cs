using quiz_app_example.Controllers;
using quiz_app_example.Model;
using quiz_app_example.Resources;

namespace quiz_app_example.Processing
{
    public interface QuestionProcessing
    {
        Task<List<Question>> GetAllQuestions();

        void SubmitAnswer(int idQUestion, int correctAnswerIndex);

        Task StoreQUestion(Question question);

        Task<Response> DeleteQuestion(String id);

        Task<Response> UpdateQuestion(Question question);
    }

    public class QuestionProcessingImpl : QuestionProcessing
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly QuestionStore _questionStore;
        public QuestionProcessingImpl(ILogger<QuestionController> logger, QuestionStore questionStore)
        {
            _logger = logger;
            _questionStore = questionStore;
        }
        public async Task<List<Question>> GetAllQuestions()
        {
            return await _questionStore.GetAllQuestion();
        }

        public async Task StoreQUestion(Question question)
        {
            await _questionStore.InsertQuestion(question);
        }

        public void SubmitAnswer(int idQUestion, int correctAnswerIndex)
        {
            // Todo Handle logic
            throw new NotImplementedException();
        }

        public async Task<Response> DeleteQuestion(String id)
        {
            return await _questionStore.DeleteQuestion(id);
        }

        public async Task<Response> UpdateQuestion(Question question)
        {
            return await _questionStore.UpdateQuestion(question);
        }
    }
}
