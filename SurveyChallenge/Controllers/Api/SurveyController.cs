using System;
using System.Collections.Generic;
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
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        public readonly ApplicationContext _context;
        public readonly IMapper _mapper;

        public SurveyController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetSurveys()
        {
            var surveys = _context.Surveys.Select(m => _mapper.Map<SurveyDto>(m)).ToList();

            return Ok(surveys);
        }
        

        [HttpGet("{id}")]
        public ActionResult GetSurvey(int id)
        {
            var survey = _context.Surveys.SingleOrDefault(s => s.Id == id);

            if (survey == null)
                return NotFound();

            return Ok(_mapper.Map<SurveyDto>(survey));
        }

        [HttpPost]
        public ActionResult PostSurvey(SurveyDto surveyDto)
        {
            var survey = _mapper.Map<Survey>(surveyDto);

            _context.Surveys.Add(survey);
            _context.SaveChanges();

            surveyDto.Id = survey.Id;
            return Created(new Uri(Request.GetDisplayUrl() + "/" + survey.Id), surveyDto);
        }
    }
}