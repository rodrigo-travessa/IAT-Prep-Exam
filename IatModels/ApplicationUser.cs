using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IatModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DisplayName("Nome")]
        [MaxLength(20)]
        public string Name { get; set; }
        public List<Quizz> Quizzes { get; set; } = new List<Quizz>();
        
    }
}
