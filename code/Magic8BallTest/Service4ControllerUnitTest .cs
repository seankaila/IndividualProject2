using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using Service4;
using Service4.Controllers;
using Xunit;

namespace Magic8BallTest
{
    public class Service4ControllerUnitTest
    {

        private Service4Controller service4Controller;

        private AppSettings appSettings = new AppSettings()
        {
            Service2URL = "https://seanservice2.azurewebsites.net",
            Service3URL = "https://seanservice3.azurewebsites.net"
        };
        [Fact]
        public async void GetTest()
        {
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://seanservice2.azurewebsites.net/service2")
                .Respond("text/plain", "My reply is no");

            mockHttp.When("https://seanservice3.azurewebsites.net/service3")
                .Respond("text/plain", "E");

            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            var controllerActionResult = await service4Controller.Get();

            Assert.NotNull(controllerActionResult);
            Assert.IsType<OkObjectResult>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityZ_Test()
        {
            //Arrange
            string Service3ResponceCall = "Z";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }

        [Fact]
        public void ProbabilityW_Test()
        {
            //Arrange
            string Service3ResponceCall = "W";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityX_Test()
        {
            //Arrange
            string Service3ResponceCall = "X";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityY_Test()
        {
            //Arrange
            string Service3ResponceCall = "Y";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityV_Test()
        {
            //Arrange
            string Service3ResponceCall = "V";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }

        [Fact]
        public void ProbabilityDeafult_Test()
        {
            //Arrange
            string Service3ResponceCall = "Deafult";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            var mockHttp = new MockHttpMessageHandler();
            var client = new HttpClient(mockHttp);
            Service4Controller service4Controller = new Service4Controller(client, options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }

    }
}
