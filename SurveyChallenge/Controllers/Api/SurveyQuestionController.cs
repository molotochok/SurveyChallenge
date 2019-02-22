using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;

namespace SurveyChallenge.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class SurveyQuestionController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public SurveyQuestionController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST /survey/{id}
        [HttpPost("survey/{id}")]
        public ActionResult AddQuestionToSurvey(int id, QuestionDto questionDto)
        {
            var surveyInDb = _context.Surveys.SingleOrDefault(s => s.Id == id);
            if (surveyInDb == null)
                return NotFound();

            var surveyQuestion = new SurveyQuestion
            {
                Survey = surveyInDb,
                Question = _mapper.Map<Question>(questionDto)
            };

            _context.SurveyQuestions.Add(surveyQuestion);
            _context.SaveChanges();

            return Created(new Uri(Request.GetDisplayUrl() + "/" + surveyQuestion.Id), surveyQuestion);
        }

        // GET /surveyquestions/{surveyId}
        [HttpGet("surveyquestions/{surveyId}")]
        public ActionResult GetQuestionsOfSurvey(int surveyId)
        {
            var questions = _context.SurveyQuestions
                .Where(s => s.Survey.Id == surveyId)
                .Select(q => _mapper.Map<QuestionDto>(q.Question))
                .ToList();

            return Ok(questions);
        }
    }
}