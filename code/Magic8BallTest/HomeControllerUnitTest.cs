using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using FrontEnd;
using FrontEnd.Controllers;
using FrontEnd.Interfaces;
using FrontEnd.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using Xunit;

namespace Magic8BallTest
{
    public class HomeControllerUnitTest
    {
        private Mock<IRepositoryWrapper> mockRepo;
        
        //private Mock<IConfiguration> mockConfig;
        private HomeController homeController;

         
        public HomeControllerUnitTest()
        {
            mockRepo = new Mock<IRepositoryWrapper>();

            //mockConfig = new Mock<IConfiguration>();
            var allHistory = GetHistory();

        }

        private AppSettings appSettings = new AppSettings()
        {
            Service4URL = "https://seanservice4.azurewebsites.net",
        };

        [Fact]
        public async void AnswerPage_Test()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://seanservice4.azurewebsites.net/service4")
                .Respond("application/json", "{\"service4\":\"C: My reply is no\",\"resultProbability\":60}");
            var client = new HttpClient(mockHttp);
            string question = "Will i join the army?";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            HomeController homeController = new HomeController(client, options.Object, mockRepo.Object);
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
            var options = new Mock<IOptions<AppSettings>>();
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            options.Setup(x => x.Value).Returns(appSettings);
            HomeController homeController = new HomeController(client, options.Object, mockRepo.Object);
            //Act
            var controllerActionResult = homeController.AnswerPage(question);
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void Index_Test()
        {
            //Act
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            HomeController homeController = new HomeController(client, options.Object, mockRepo.Object);
            var controllerActionResult = homeController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void History_Test()
        {
            //Arrange
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            HomeController homeController = new HomeController(client, options.Object, mockRepo.Object);
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
