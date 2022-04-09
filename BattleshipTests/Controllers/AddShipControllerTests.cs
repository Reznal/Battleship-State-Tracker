using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class AddShipControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            Game game = new Game();
            Player player = new Player(1, "George");
            game.CreateGame(player);

            AddShipController controller = new AddShipController();
            AddShipData data = new AddShipData()
            {
                GameId = 0,
                Id = 1,
                ShipDirection = ShipDirection.Horizontal,
                ShipLength = 5,
                X = 0,
                Y = 0
            };

            StatusCodeResult result = controller.Post(data) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod()]
        public void PostInvalidGameTest()
        {
            Game game = new();
            Player player = new(1, "George");
            game.CreateGame(player);

            AddShipController controller = new();
            AddShipData data = new()
            {
                GameId = 1,
                Id = 1,
                ShipDirection = ShipDirection.Horizontal,
                ShipLength = 5,
                X = 0,
                Y = 0
            };

            BadRequestObjectResult result = controller.Post(data) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod()]
        public void PostInvalidUserTest()
        {
            Game game = new Game();
            Player player = new Player(1, "George");
            game.CreateGame(player);

            AddShipController controller = new AddShipController();
            AddShipData data = new AddShipData()
            {
                GameId = 0,
                Id = 5,
                ShipDirection = ShipDirection.Horizontal,
                ShipLength = 5,
                X = 0,
                Y = 0
            };

            BadRequestObjectResult result = controller.Post(data) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod()]
        public void PostInvalidPositionTest()
        {
            Game game = new Game();
            Player player = new Player(1, "George");
            game.CreateGame(player);

            AddShipController controller = new AddShipController();
            AddShipData data = new AddShipData()
            {
                GameId = 0,
                Id = 1,
                ShipDirection = ShipDirection.Horizontal,
                ShipLength = 5,
                X = -1,
                Y = 0
            };

            BadRequestObjectResult result = controller.Post(data) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}