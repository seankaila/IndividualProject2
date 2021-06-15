using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Service4.Controllers;
using Xunit;

namespace Magic8BallTest
{
    public class Service4ControllerUnitTest
    {

        private Service4Controller service4Controller;
        private Mock<IConfiguration> mockConfig;

        public Service4ControllerUnitTest()
        {
            mockConfig = new Mock<IConfiguration>();
            service4Controller = new Service4Controller(mockConfig.Object);
        }

        [Fact]
        public void Get_Test()
        {
            //Act
            var controllerActionResult = service4Controller.Get();
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void Probability_Test()
        {
            //Arrange
            string Service3ResponceCall = "A";
            //Act
            var controllerActionResult = service4Controller.probability(Service3ResponceCall);
            //Assert
            Assert.NotNull(controllerActionResult);
        }



    }
}
