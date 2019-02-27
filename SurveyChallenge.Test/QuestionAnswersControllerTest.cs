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
    public class QuestionAnswersControllerTest
    {
        private readonly QuestionAnswersController _controller;

        public QuestionAnswersControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            var mapper = mappingConfig.CreateMapper();

            _controller = new QuestionAnswersController(new TestApplicationContext(), mapper);
        }

        #region Post
        [Fact]
        public void Post_AddAnswerToQuestion_ReturnsCreatedRequest()
        {
            // Arrange
            var answerDto = new AnswerDto
            {
                Text = "Answer to question"
            };
            var id = 1;

            // Act
            var result = _controller.AddAnswerToQuestion(id, answerDto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public void Post_AddInvalidAnswerToQuestion_ReturnsBadRequest()
        {
            // Arrange
            AnswerDto answerDto = null;
            var id = 1;

            // Act
            var result = _controller.AddAnswerToQuestion(id, answerDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void Post_AddAnswerToInvalidQuestionId_ReturnsNotFound()
        {
            // Arrange
            var answerDto = new AnswerDto
            {
                Text = "Answer to question"
            };
            var id = -1;

            // Act
            var result = _controller.AddAnswerToQuestion(id, answerDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Post_AddAnswerToQuestion_ReturnsQuestionAnswer()
        {
            // Arrange
            var answerDto = new AnswerDto
            {
                Text = "Answer to question"
            };
            var id = 1;

            // Act
            var result = _controller.AddAnswerToQuestion(id, answerDto) as CreatedResult;
            var questionAnswer = result.Value as QuestionAnswer;

            // Assert
            Assert.Equal(id, questionAnswer.QuestionId);
            Assert.Equal(answerDto.Text, questionAnswer.Answer.Text);
        }

        [Fact]
        public void Post_AddListOfAnswersToQuestion_ReturnsCreatedRequest()
        {
            // Arrange
            var answerDtos = new List<AnswerDto>()
            {
                new AnswerDto() {Text = "Answer 1"},
                new AnswerDto() {Text = "Answer 2"}
            };
            
            var id = 2;

            // Act
            var result = _controller.AddMultipleAnswersToQuestion(id, answerDtos);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        public void Post_AddListOfAnswersToInvalidQuestionId_ReturnsNotFoundRequest()
        {
            // Arrange
            var answerDtos = new List<AnswerDto>()
            {
                new AnswerDto() {Text = "Answer 1"},
                new AnswerDto() {Text = "Answer 2"}
            };

            var id = -1;

            // Act
            var result = _controller.AddMultipleAnswersToQuestion(id, answerDtos);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_AddInvalidListOfAnswersToQuestion_ReturnsBadRequest()
        {
            // Arrange
            List<AnswerDto> answerDtos = null;
            var id = 2;

            // Act
            var result = _controller.AddMultipleAnswersToQuestion(id, answerDtos);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        #endregion

        #region Get
        [Fact]
        public void Get_PassValidQuestionId_ReturnsOkObjectResult()
        {
            // Arrange
            var questionId = 1;

            // Act
            var result = _controller.GetAnswersOfQuestion(questionId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Get_PassValidQuestionId_ReturnsAnswerList()
        {
            // Arrange
            var questionId = 1;

            // Act
            var result = _controller.GetAnswersOfQuestion(questionId) as OkObjectResult;
            var answerDtos = result.Value as List<AnswerDto>;

            // Assert
            Assert.NotNull(answerDtos);
        }
        [Fact]
        public void Get_PassInvalidQuestionId_ReturnsNotFound()
        {
            // Arrange
            var questionId = -1;

            // Act
            var result = _controller.GetAnswersOfQuestion(questionId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
