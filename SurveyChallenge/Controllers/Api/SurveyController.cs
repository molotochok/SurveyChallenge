using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class SurveyController : ControllerBase
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public SurveyController(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/surveys
        [HttpGet("surveys")]
        public ActionResult<IEnumerable<SurveyDto>> GetSurveys()
        {
            var surveys = _context.Surveys.Select(m => _mapper.Map<SurveyDto>(m)).ToList();

            return Ok(surveys);
        }

        // GET api/survey/{id}
        [HttpGet("survey/{id}")]
        public ActionResult<SurveyDto> GetSurvey(int id)
        {
            var survey = _context.Surveys.SingleOrDefault(s => s.Id == id);

            if (survey == null)
                return NotFound();

            return Ok(_mapper.Map<SurveyDto>(survey));
        }

        // POST api/survey
        [HttpPost("survey")]
        public ActionResult PostSurvey(SurveyDto surveyDto)
        {
            if (surveyDto == null)
                return NotFound();

            var survey = _mapper.Map<Survey>(surveyDto);

            _context.Surveys.Add(survey);
            _context.SaveChanges();

            surveyDto.Id = survey.Id;

            var requestUrl = Request == null ? "http://localhost/api/survey" : Request.GetDisplayUrl();
            
            return Created(new Uri(requestUrl + "/" + survey.Id), surveyDto);
        }

        // PUT api/survey/{id}
        [HttpPut("survey/{id}")]
        public ActionResult PutSurvey(int id, SurveyDto surveyDto)
        {
            var surveyInDb = _context.Surveys.SingleOrDefault(s => s.Id == id);

            if (surveyInDb == null)
                return NotFound();

            surveyDto.Id = surveyInDb.Id;
            _mapper.Map(surveyDto, surveyInDb);
 
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/survey/{id}
        [HttpDelete("survey/{id}")]
        public ActionResult DeleteSurvey(int id)
        {
            var surveyInDb = _context.Surveys.SingleOrDefault(s => s.Id == id);

            if (surveyInDb == null)
                return NotFound();

            _context.Surveys.Remove(surveyInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}