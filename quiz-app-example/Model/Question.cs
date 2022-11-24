namespace quiz_app_example.Model
{
    public class Question
    {
        public String Id { get; private set; }

        public string Text { get; set; }

        public string[] Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }

        public Question(string id, string text, string[] answers, int correctAnswerIndex)
        {
            Id = id;
            Text = text;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        private String RandomIdByLength(int expectedLength)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, expectedLength)
                  .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }   
}
