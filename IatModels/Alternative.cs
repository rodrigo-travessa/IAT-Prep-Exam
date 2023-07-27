using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace IatModels
{
    public class Alternative
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public bool IsRight { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        [ValidateNever]
        public Question? Question { get; set; }
    }
}
