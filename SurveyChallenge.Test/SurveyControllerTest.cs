using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyChallenge.Controllers.Api;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;
using Xunit;

namespace SurveyChallenge.Test
{
    public class SurveyControllerTest
    {
        private readonly SurveyController _controller;

        public SurveyControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>mc.AddProfile(new MappingProfile()));
            var mapper = mappingConfig.CreateMapper();

            _controller = new SurveyController(new TestApplicationContext(), mapper);
        }


        [Fact]
        public void Post_AddNewSurvey_ReturnsCreatedResult()
        {
            // Arrange
            var survey = new SurveyDto()
            {
                AuthorName = "Opera",
                DateCreated = DateTime.Now,
                Description = "Some description",
                Name = "Test Experimental survey",
                ViewCount = 0
            };

            // Act
            var result = _controller.PostSurvey(survey);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }
    }
}
