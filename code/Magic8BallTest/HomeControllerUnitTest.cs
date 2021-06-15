using System;
using System.Collections.Generic;
using System.Linq;
using FrontEnd.Controllers;
using FrontEnd.Interfaces;
using FrontEnd.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Magic8BallTest
{
    public class HomeControllerUnitTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        private Mock<IConfiguration> mockConfig;
        private HomeController homeController;

         
        public HomeControllerUnitTest()
        {
            mockRepo = new Mock<IRepositoryWrapper>();
            mockConfig = new Mock<IConfiguration>();
            var allHistory = GetHistory();
            homeController = new HomeController(mockConfig.Object, mockRepo.Object);

        }

        [Fact]
        public void AnswerPage_Test()
        {
            //Arrange
            string question = "Will i join the army?";
            //Act
            var controllerActionResult = homeController.AnswerPage(question);
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void AnswerPageNoQuestion_Test()
        {
            //Arrange
            string question = null;
            //Act
            var controllerActionResult = homeController.AnswerPage(question);
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void Index_Test()
        {
            //Act
            var controllerActionResult = homeController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void History_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Historys.FinalALL()).Returns(GetHistorys);
            //Act
            var controllerActionResult = homeController.History();
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        private IEnumerable<History> GetHistorys()
        {
            var historys = new List<History>
            {
               new History(){ID = 1, Question = "Will England win?", Answer = "E: Maybe", Probability = "20" },
               new History(){ID = 2, Question = "Will i get a promotion?", Answer = "A: Highly likely", Probability = "100" },
            };
            return historys;
        }
        private History GetHistory()
        {
            return GetHistorys().ToList()[0];
        }


    }
}
