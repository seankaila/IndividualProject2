using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Service2.Controllers;
using Xunit;

namespace Magic8BallTest
{
    public class Service2ControllerUnitTest
    {

        private Service2Controller service2Controller;
        public Service2ControllerUnitTest()
        {
            service2Controller = new Service2Controller();

        }

        [Fact]
        public void Get_Test()
        {
            //Act
            var controllerActionResult = service2Controller.Get();
            //Assert
            Assert.NotNull(controllerActionResult);
        }


    }
}
