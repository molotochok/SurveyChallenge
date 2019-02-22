using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SurveyChallenge.Models;

namespace SurveyChallenge.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string Comment { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
