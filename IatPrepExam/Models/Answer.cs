using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace IatPrepExam.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuizzId { get; set; }
        [ForeignKey("QuizzId")]
        [ValidateNever]
        public Quizz Quizz { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        [ValidateNever]
        public Question Question { get; set; }
        public string AnswerValue { get; set; } = string.Empty;
    }
}
