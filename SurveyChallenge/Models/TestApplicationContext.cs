using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyChallenge.Models
{
    public class TestApplicationContext : DbContext
    {
        public TestApplicationContext(DbContextOptions<TestApplicationContext> options) : base(options) { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
