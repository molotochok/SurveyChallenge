using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;

namespace QuestionChallenge.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public QuestionController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/questions
        [HttpGet("questions")]
        public ActionResult GetQuestions()
        {
            var questions = _context.Questions.Select(m => _mapper.Map<QuestionDto>(m)).ToList();

            return Ok(questions);
        }

        // GET api/question/{id}
        [HttpGet("question/{id}")]
        public ActionResult GetQuestion(int id)
        {
            var question = _context.Questions.SingleOrDefault(s => s.Id == id);

            if (question == null)
                return NotFound();

            return Ok(_mapper.Map<QuestionDto>(question));
        }

        // POST api/question
        [HttpPost("question")]
        public ActionResult PostQuestion(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            _context.Questions.Add(question);
            _context.SaveChanges();

            questionDto.Id = question.Id;
            return Created(new Uri(Request.GetDisplayUrl() + "/" + question.Id), questionDto);
        }

        // PUT api/question/{id}
        [HttpPut("question/{id}")]
        public ActionResult PutQuestion(int id, QuestionDto questionDto)
        {
            var questionInDb = _context.Questions.SingleOrDefault(s => s.Id == id);

            if (questionInDb == null)
                return NotFound();

            questionDto.Id = questionInDb.Id;
            _mapper.Map(questionDto, questionInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/question/{id}
        [HttpDelete("question/{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            var questionInDb = _context.Questions.SingleOrDefault(s => s.Id == id);

            if (questionInDb == null)
                return NotFound();

            _context.Questions.Remove(questionInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}