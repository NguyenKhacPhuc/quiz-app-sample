using quiz_app_example.Model;

namespace quiz_app_example
{
    public class Attempt
    {
        public string Id { get; set; }
        public Question[] Questions { get; set; }

        public string StartedTime { get; set; }

    }
}
