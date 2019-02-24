using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyChallenge.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
