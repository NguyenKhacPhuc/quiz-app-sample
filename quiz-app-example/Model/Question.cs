namespace quiz_app_example.Model
{
    public class Question
    {
        public Question() { }
        public Question(String id, string text, string[] answers, int correctAnswerIndex)
        {
            Id = id;
            Text = text;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public String Id { get; set; }
        public string Text { get; set; }

        public string[] Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }
    }
}
