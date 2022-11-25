namespace quiz_app_example.Model
{
    public class Attempt
    {
        public Attempt()
        {
        }

        public Attempt(string id, Question[] questions, string startedTime)
        {
            id = id;
            questions = questions;
            startedTime = startedTime;
        }

        public string id { get; set; }
        public Question[] questions { get; set; }

        public string startedTime { get; set; }

    }
}
