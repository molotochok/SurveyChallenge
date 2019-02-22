using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyChallenge.Models
{
    public class Survey
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Author name")]
        public string AuthorName { get; set; }

        public List<Question> Questions { get; set; }
    }
}
