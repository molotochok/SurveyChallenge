using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyChallenge.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }

        [Required]
        public Survey Survey { get; set; }
        [Required]
        public Question Question { get; set; }
    }
}
