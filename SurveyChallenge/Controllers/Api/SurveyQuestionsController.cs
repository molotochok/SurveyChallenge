using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public class SurveyQuestionsController : ControllerBase
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public SurveyQuestionsController(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST /survey/{id}
        [HttpPost("survey/{id}")]
        public ActionResult AddQuestionToSurvey(int id, QuestionDto questionDto)
        {
            if (questionDto == null)
                return BadRequest();

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

            var displayUrl = (Request != null) ? Request.GetDisplayUrl() : "http://localhost/survey/" + id;

            return Created(new Uri(displayUrl + "/" + surveyQuestion.Id), surveyQuestion);
        }

        // GET /surveyquestions/{surveyId}
        [HttpGet("surveyquestions/{surveyId}")]
        public ActionResult GetQuestionsOfSurvey(int surveyId)
        {
            var questions = _context.SurveyQuestions
                .Where(s => s.Survey.Id == surveyId)
                .Select(q => _mapper.Map<QuestionDto>(q.Question))
                .ToList();

            if(questions.Count <= 0)
                return NotFound();

            return Ok(questions);
        }

        // DELETE/surveyquestions/{surveyId}
        [HttpDelete("surveyquestions/{surveyId}")]
        public ActionResult RemoveQuestionsFromSurvey(int surveyId)
        {
            var surveyInDb = _context.Surveys.SingleOrDefault(s => s.Id == surveyId);

            if (surveyInDb == null)
                return NotFound();

            var surveyQuestions = _context.SurveyQuestions;
            foreach (var surveyQuestion in surveyQuestions)
            {
                if (surveyQuestion.SurveyId == surveyId)
                    surveyQuestions.Remove(surveyQuestion);

            }
            _context.SaveChanges();

            return Ok();
        }
    }
}