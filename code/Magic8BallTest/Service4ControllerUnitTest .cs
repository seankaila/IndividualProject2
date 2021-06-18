using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
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

            Service4Controller service4Controller = new Service4Controller(options.Object);
            var controllerActionResult = await service4Controller.Get();

            Assert.NotNull(controllerActionResult);
            Assert.IsType<OkObjectResult>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityA_Test()
        {
            //Arrange
            string Service3ResponceCall = "A";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            Service4Controller service4Controller = new Service4Controller(options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }

        [Fact]
        public void ProbabilityB_Test()
        {
            //Arrange
            string Service3ResponceCall = "B";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            Service4Controller service4Controller = new Service4Controller(options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityC_Test()
        {
            //Arrange
            string Service3ResponceCall = "C";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            Service4Controller service4Controller = new Service4Controller(options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityD_Test()
        {
            //Arrange
            string Service3ResponceCall = "D";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            Service4Controller service4Controller = new Service4Controller(options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }
        [Fact]
        public void ProbabilityE_Test()
        {
            //Arrange
            string Service3ResponceCall = "E";
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            Service4Controller service4Controller = new Service4Controller(options.Object);
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
            Service4Controller service4Controller = new Service4Controller(options.Object);
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.IsType<int>(controllerActionResult);
        }

    }
}
