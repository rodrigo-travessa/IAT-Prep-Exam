using Microsoft.EntityFrameworkCore;
using IatPrepExam.Models;

namespace IatPrepExam.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<Alternative> Alternatives { get; set; } = default!;
        public DbSet<Quizz> Quizzes { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;
    }
}
