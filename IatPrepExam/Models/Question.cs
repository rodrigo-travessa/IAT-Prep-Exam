namespace IatPrepExam.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? Statement { get; set; }
        public List<Alternative>? Alternatives { get; set; } = new ();

    }
}
