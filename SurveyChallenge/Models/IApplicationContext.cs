using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyChallenge.Models
{
    public interface IApplicationContext
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Survey> Surveys { get; set; }

        DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        DbSet<QuestionAnswer> QuestionAnswer { get; set; }

        int SaveChanges();
    }
}
