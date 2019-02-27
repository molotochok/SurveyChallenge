using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SurveyChallenge.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }

        [Required]
        public Question Question { get; set; }
        public int QuestionId { get; set; }

        [Required]
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
    }
}
