using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;

namespace SurveyChallenge.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAnswersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public QuestionAnswersController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("questionanswers/{questionId}")]
        public ActionResult GetAnswersOfQuestion(int questionId)
        {
            var answers = _context.QuestionAnswer
                .Where(q => q.Question.Id == questionId)
                .Select(a => _mapper.Map<AnswerDto>(a.Answer))
                .ToList();

            return Ok(answers);
        }
    }
}