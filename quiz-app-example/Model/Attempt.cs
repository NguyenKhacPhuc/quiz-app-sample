namespace quiz_app_example.Model
{
    public class Attempt
    {
        public string Id { get; set; }
        public Question[] Questions { get; set; }

        public string StartedTime { get; set; }

    }
}
