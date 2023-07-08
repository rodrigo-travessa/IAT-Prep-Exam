using System.Net;

namespace IatPrepExam.Models
{
    public class Quizz
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.Now;
        public DateTime FinishedAt { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public double Score { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
    }
}
