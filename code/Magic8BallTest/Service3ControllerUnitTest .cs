using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Service3.Controllers;
using Xunit;

namespace Magic8BallTest
{
    public class Service3ControllerUnitTest
    {

        private Service3Controller service3Controller;
        public Service3ControllerUnitTest()
        {
            service3Controller = new Service3Controller();
        }

        [Fact]
        public void Get_Test()
        {
            //Act
            var controllerActionResult = service3Controller.Get();
            //Assert
            Assert.NotNull(controllerActionResult);
        }


    }
}
