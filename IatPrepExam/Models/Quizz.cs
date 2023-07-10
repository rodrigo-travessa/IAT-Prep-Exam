using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public Dictionary<string, string> Answers { get; set; } = new Dictionary<string, string>();
        [DisplayName("Nome do Estudante")]
        public string? NameOfStudent { get; set; }
        [DisplayName("Número de Questões")]
        public int NumberOfQuestions { get; set; }
        public double ScoreRatio { get; set; }
        public int Rights { get; set; }
    }
}
