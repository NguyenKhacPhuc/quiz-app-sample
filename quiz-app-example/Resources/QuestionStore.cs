using quiz_app_example.Model;
using quiz_app_example.Utils;

namespace quiz_app_example.Resources
{
   public interface QuestionStore
    {
        Task<Response> AddQuestion(Question question);

        Task<List<Question>> GetAllQuestion();

        Task<Response> DeleteQuestion(String id);

        Task<Response> UpdateQuestion(Question question);

    }

    public class QuestionStoreImpl : QuestionStore
    {
        private readonly string STORE_PATH_FILE = OperationSystemHelper.ISOSXSystem() ?
            System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "questions_storage.json") :
            System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\", "questions_storage.json");

        private readonly string ATTEMPT_STORE_PATH_FILE = OperationSystemHelper.ISOSXSystem() ?
            System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "attempt_storage.json") :
            System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\", "attempt_storage.json");

        private Attempt attempt = new Attempt();

        List<Question> question = new List<Question>();

        private readonly FileJsonHandler _fileJsonHandler;
        public QuestionStoreImpl(FileJsonHandler fileJsonHandler)
        {
            _fileJsonHandler = fileJsonHandler;
        }

        public async Task<List<Question>> GetAllQuestion()
        {
            attempt = await _fileJsonHandler.readFile<Attempt>(ATTEMPT_STORE_PATH_FILE);
            Console.WriteLine("quyenn " + System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory));
            var questions = attempt.questions;
            for (int i = 0; i < questions.Length; i++)
            {
                question.Add(questions[i]);
            }
            return question;
        }

        public async Task<Response> AddQuestion(Question question)
        {
            List<Question> questions = new List<Question>();
            questions = await _fileJsonHandler.readFile<List<Question>>(STORE_PATH_FILE);
            if (questions.ConvertAll(question => new String(question.Text)).Contains(question.Text))
            {
                return new Response(500, "Can not add duplicated question");
            }
            else
            {
                questions.Add(question);
                await _fileJsonHandler.wirteFile(STORE_PATH_FILE, questions);
                return new Response(200, "Insert new question");
            }    
        }

        public async Task<Response> DeleteQuestion(String id)
        {
            List<Question> questions = new List<Question>();
            questions = await _fileJsonHandler.readFile<List<Question>>(STORE_PATH_FILE);
            bool contains = questions.Any(p => p.Id.Equals(id));
            if (contains)
            {
                var index = questions.FindIndex(p => p.Id.Equals(id));
                questions.RemoveAt(index);
                await _fileJsonHandler.wirteFile(STORE_PATH_FILE, questions);
                return new Response(200, "Success");
            } else
            {
                return new Response(500, "Not Exist Item");  
            }

        }

        public async Task<Response> UpdateQuestion(Question question)
        {
            List<Question> questions = new List<Question>();
            questions = await _fileJsonHandler.readFile<List<Question>>(STORE_PATH_FILE);
            bool existedQuestion = questions.Any(question => question.Id.Equals(question.Id) && question.Text.Equals(question.Text));
            if (existedQuestion)
            {
                var index = questions.FindIndex(question => question.Id.Equals(question.Id) || question.Text.Equals(question.Text));
                if (index != -1)
                {
                    questions[index] = question;
                    await _fileJsonHandler.wirteFile(STORE_PATH_FILE, questions);
                    return new Response(200, "Question updated");
                }
            }
            var addQuestionResult = AddQuestion(question);
            if (addQuestionResult.Result.StatusCode !=  200)
            {
                return await addQuestionResult;
            }
            return new Response(200, "Insert new question");
        }
    } 
}
