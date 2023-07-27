using IatModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IatDataAccess.Data
{
    public class AppDbContext : IdentityDbContext
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
