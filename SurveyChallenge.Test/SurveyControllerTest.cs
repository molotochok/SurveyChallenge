using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        #region POST
        [Fact]
        public void Post_ValidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var surveyDto = new SurveyDto()
            {
                AuthorName = "Opera",
                DateCreated = DateTime.Now,
                Description = "Some description",
                Name = "Test Experimental surveyDto",
                ViewCount = 0
            };

            // Act
            var result = _controller.PostSurvey(surveyDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Act
            var result = _controller.PostSurvey(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Post_ValidObjectPassed_CreatedNewSurvey()
        {
            // Arrange
            var surveyDto = new SurveyDto()
            {
                AuthorName = "Markiian",
                DateCreated = DateTime.Now,
                Description = "New description",
                Name = "Some surveyDto",
                ViewCount = 0
            };

            // Act
            var result = _controller.PostSurvey(surveyDto) as CreatedResult;
            var responseSurvey = result.Value as SurveyDto;

            // Assert
            Assert.IsType<SurveyDto>(responseSurvey);
            Assert.Equal("Some surveyDto", responseSurvey.Name);
        }
        #endregion

        #region GET
        [Fact]
        public void Get_TakeAllSurveys_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetSurveys();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Get_TakeAllSurveys_ReturnsListOfSurveys()
        {
            // Act
            var result = _controller.GetSurveys() as OkObjectResult;
            var surveyDtos = result.Value as List<SurveyDto>;

            // Assert
            Assert.NotEmpty(surveyDtos);
        }

        [Fact]
        public void Get_SurveyIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var id = 2;

            // Act
            var result = _controller.GetSurvey(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_SurveyIdPassed_ReturnsSurvey()
        {
            // Arrange
            var id = 2;

            // Act
            var result = _controller.GetSurvey(id) as OkObjectResult;
            var surveyDto = result.Value as SurveyDto;

            // Assert
            Assert.Equal(id, surveyDto.Id);
        }

        [Fact]
        public void Get_InvalidSurveyIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _controller.GetSurvey(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region PUT
        [Fact]
        public void Put_ValidIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var surveyDto = new SurveyDto
            {
                AuthorName = "Updated Author",
                DateCreated = DateTime.Now,
                Description = "",
                Name = "Updated Name",
                ViewCount = 0
            };
            var id = 2;
            // Act
            var result = _controller.PutSurvey(id, surveyDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Put_InValidIdPassed_ReturnsNotFound()
        {
            // Arrange
            var surveyDto = new SurveyDto
            {
                AuthorName = "Updated Author",
                DateCreated = DateTime.Now,
                Description = "",
                Name = "Updated Name",
                ViewCount = 0
            };
            var id = -1;

            // Act
            var result = _controller.PutSurvey(id, surveyDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region DELETE
        [Fact]
        public void Delete_InValidIdPassed_ReturnsNotFound()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _controller.DeleteSurvey(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
