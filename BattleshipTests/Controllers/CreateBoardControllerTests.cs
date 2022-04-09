using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class CreateBoardControllerTests
    {
        [TestMethod()]
        public void PostCreatedTest()
        {
            Game game = new Game();

            CreateBoardController controller = new CreateBoardController();
            CreateBoardData data = new CreateBoardData()
            {
                Id = 1,
                Username = "Harry"
            };

            OkObjectResult result = controller.Post(data) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}