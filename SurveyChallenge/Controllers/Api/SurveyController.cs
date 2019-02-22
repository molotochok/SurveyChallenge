using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyChallenge.Models;

namespace SurveyChallenge.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        public readonly ApplicationContext _context;

        public SurveyController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetSurveys()
        {
            var surveys = _context.Surveys;

            if (surveys == null)
                return NotFound();

            return Ok(surveys);
        }


        [HttpGet("{id}")]
        public ActionResult GetSurvey(int id)
        {
            var survey = _context.Surveys.SingleOrDefault(s => s.Id == id);

            if (survey == null)
                return NotFound();

            return Ok(survey);
        }
    }
}