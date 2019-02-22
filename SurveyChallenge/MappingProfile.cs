using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;

namespace SurveyChallenge
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Survey
            CreateMap<Survey, SurveyDto>();
            CreateMap<SurveyDto, Survey>();


            // Question
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
        }
    }

}
