using quiz_app_example.Model;

namespace quiz_app_example.Resources
{
   public interface QuestionStore
    {
        Task InsertQuestion(Question question);
        Task<List<Question>> GetAllQuestion();

        Task<Response> DeleteQuestion(String id);
        Task<Response> UpdateQuestion(Question question);

    }

    public class QuestionStoreImpl : QuestionStore
    {
        private readonly string STORE_PATH_FILE = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\", "questions_storage.json");

        private readonly FileJsonHandler _fileJsonHandler;
        public QuestionStoreImpl(FileJsonHandler fileJsonHandler)
        {
            _fileJsonHandler = fileJsonHandler;
        }

        public async Task<List<Question>> GetAllQuestion()
        {
            return await _fileJsonHandler.readFile<List<Question>>(STORE_PATH_FILE);
        }

        public async Task InsertQuestion(Question question)
        {
            List<Question> questions = new List<Question>();
            questions =  await _fileJsonHandler.readFile<List<Question>>(STORE_PATH_FILE);
            questions.Add(question);
            await _fileJsonHandler.wirteFile(STORE_PATH_FILE, questions);
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
            InsertQuestion(question);
            return new Response(200, "Insert new question");
        }
    } 
}
