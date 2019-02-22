using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyChallenge.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Answer>   Answers   { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey>   Surveys   { get; set; }
    }
}
