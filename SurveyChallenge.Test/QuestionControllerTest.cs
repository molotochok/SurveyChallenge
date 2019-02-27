using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestionChallenge.Controllers.Api;
using SurveyChallenge.Controllers.Api;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;
using Xunit;

namespace SurveyChallenge.Test
{
    public class QuestionControllerTest
    {
        private readonly QuestionController _controller;

        public QuestionControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            var mapper = mappingConfig.CreateMapper();

            _controller = new QuestionController(new TestApplicationContext(), mapper);
        }


        #region POST
        [Fact]
        public void Post_ValidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var questionDto = new QuestionDto
            {
                Comment = "Some comment",
                Text = "Some text"
            };

            // Act
            var result = _controller.PostQuestion(questionDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Act
            var result = _controller.PostQuestion(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Post_ValidObjectPassed_CreatedNewSurvey()
        {
            // Arrange
            var questionDto = new QuestionDto
            {
                Comment = "Some comment",
                Text = "Some text"
            };

            // Act
            var result = _controller.PostQuestion(questionDto) as CreatedResult;
            var responseQuestion = result.Value as QuestionDto;

            // Assert
            Assert.IsType<QuestionDto>(responseQuestion);
            Assert.Equal("Some text", responseQuestion.Text);
        }
        #endregion

        #region GET
        [Fact]
        public void Get_TakeAllQuestions_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetQuestions();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Get_TakeAllQuestions_ReturnsListOfQuestions()
        {
            // Act
            var result = _controller.GetQuestions() as OkObjectResult;
            var questionDtos = result.Value as List<QuestionDto>;

            // Assert
            Assert.NotEmpty(questionDtos);
        }

        [Fact]
        public void Get_QuestionIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.GetQuestion(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_QuestionIdPassed_ReturnsSurvey()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.GetQuestion(id) as OkObjectResult;
            var questionDto = result.Value as QuestionDto;

            // Assert
            Assert.Equal(id, questionDto.Id);
        }

        [Fact]
        public void Get_InvalidQuestionIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _controller.GetQuestion(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region PUT
        [Fact]
        public void Put_ValidIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var questionDto = new QuestionDto
            {
                Comment = "Updated Comment",
                Text = "Updated Text"
            };

            var id = 1;
            // Act
            var result = _controller.PutQuestion(id, questionDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Put_InValidIdPassed_ReturnsNotFound()
        {
            // Arrange
            var questionDto = new QuestionDto
            {
                Comment = "Updated Comment",
                Text = "Updated Text"
            };

            var id = -1;

            // Act
            var result = _controller.PutQuestion(id, questionDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region DELETE
        [Fact]
        public void Delete_InvalidIdPassed_ReturnsNotFound()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _controller.DeleteQuestion(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
