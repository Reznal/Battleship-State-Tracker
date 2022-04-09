using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class AttackControllerTests
    {
        [TestMethod()]
        public void PostHitTest()
        {
            Game game = new Game();
            Player player = new Player(1, "George");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            game.CreateGame(player);
            game.GetGameSession(0).Player2.PlaceShip(ship, 0, 0);

            AttackController controller = new AttackController();
            AttackData data = new AttackData()
            {
                GameId = 0,
                Id = 1,
                X = 0,
                Y = 0
            };

            OkObjectResult result = controller.Post(data) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("hit", result.Value);
        }

        [TestMethod()]
        public void PostMissTest()
        {
            Game game = new Game();
            Player player = new Player(1, "George");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            game.CreateGame(player);
            game.GetGameSession(0).Player2.PlaceShip(ship, 0, 0);

            AttackController controller = new AttackController();
            AttackData data = new AttackData()
            {
                GameId = 0,
                Id = 1,
                X = 5,
                Y = 0
            };

            OkObjectResult result = controller.Post(data) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("miss", result.Value);
        }

        [TestMethod()]
        public void PostInvalidGameTest()
        {
            Game game = new Game();
            Player player = new Player(1, "George");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            game.CreateGame(player);
            game.GetGameSession(0).Player2.PlaceShip(ship, 0, 0);

            AttackController controller = new AttackController();
            AttackData data = new AttackData()
            {
                GameId = 5,
                Id = 1,
                X = 5,
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
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            game.CreateGame(player);
            game.GetGameSession(0).Player2.PlaceShip(ship, 0, 0);

            AttackController controller = new AttackController();
            AttackData data = new AttackData()
            {
                GameId = 0,
                Id = 10,
                X = 5,
                Y = 0
            };

            BadRequestObjectResult result = controller.Post(data) as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}