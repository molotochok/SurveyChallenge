using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyChallenge.Models
{
    // Db context for testing
    public class TestApplicationContext : DbContext, IApplicationContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TestSurveyChallenge.Db;Trusted_Connection=True;";

        public TestApplicationContext() : base(new DbContextOptionsBuilder<TestApplicationContext>().UseSqlServer(connectionString).Options) {}

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
