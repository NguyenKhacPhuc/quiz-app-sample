namespace quiz_app_example.Model
{
    public class AttemptResult
    {
        public string[] UserAnswers { get; set; }

        public string[] CorrectAnswers { get; set; }

        public int Score { get; set; }

        public int ScoreText { get; set; }
    }
}
