using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyChallenge.Controllers.Api;
using SurveyChallenge.Dtos;
using SurveyChallenge.Models;
using Xunit;

namespace SurveyChallenge.Test
{
    public class SurveyQuestionsControllerTest
    {
        private readonly SurveyQuestionsController _controller;

        public SurveyQuestionsControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            var mapper = mappingConfig.CreateMapper();

            _controller = new SurveyQuestionsController(new TestApplicationContext(), mapper);
        }

        #region Post
        [Fact]
        public void Post_AddQuestionToSurvey_ReturnsCreatedRequest()
        {
            // Arrange
            var questionDto = new QuestionDto
            {
                Comment = "Connecting to survey comment",
                Text = "Connecting to survey text"
            };
            var id = 2;

            // Act
            var result = _controller.AddQuestionToSurvey(id, questionDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public void Post_AddInvalidQuestionToSurvey_ReturnsBadRequest()
        {
            // Arrange
            QuestionDto questionDto = null;
            var id = 2;

            // Act
            var result = _controller.AddQuestionToSurvey(id, questionDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void Post_AddQuestionToInvalidSurveyId_ReturnsNotFound()
        {
            // Arrange
            QuestionDto questionDto = null;
            var id = -1;

            // Act
            var result = _controller.AddQuestionToSurvey(id, questionDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void Post_AddQuestionToSurvey_ReturnsSurveyQuestion()
        {
            // Arrange
            var questionDto = new QuestionDto
            {
                Comment = "Connecting to survey comment",
                Text = "Connecting to survey text"
            };
            var id = 2;

            // Act
            var result = _controller.AddQuestionToSurvey(id, questionDto) as CreatedResult;
            var surveyQuestion = result.Value as SurveyQuestion;

            // Assert
            Assert.Equal(id, surveyQuestion.Survey.Id);
            Assert.Equal(questionDto.Text, surveyQuestion.Question.Text);
        }
        #endregion

        #region Get
        [Fact]
        public void Get_PassValidSurveyId_ReturnsOkObjectResult()
        {
            // Arrange
            var surveyId = 2;

            // Act
            var result = _controller.GetQuestionsOfSurvey(surveyId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Get_PassValidSurveyId_ReturnsQuestionList()
        {
            // Arrange
            var surveyId = 2;

            // Act
            var result = _controller.GetQuestionsOfSurvey(surveyId) as OkObjectResult;
            var questionDtos = result.Value as List<QuestionDto>;

            // Assert
            Assert.NotNull(questionDtos);
        }
        [Fact]
        public void Get_PassInvalidSurveyId_ReturnsNotFound()
        {
            // Arrange
            var surveyId = -1;

            // Act
            var result = _controller.GetQuestionsOfSurvey(surveyId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_PassValidSurveyId_ReturnsOkObjectResult()
        {
            // Arrange
            var surveyId = 3;

            // Act
            var result = _controller.RemoveQuestionsFromSurvey(surveyId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Delete_PassInvalidSurveyId_ReturnsNotFoundResult()
        {
            // Arrange
            var surveyId = -1;

            // Act
            var result = _controller.RemoveQuestionsFromSurvey(surveyId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
