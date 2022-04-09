using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void CreateGameTest()
        {
            Game game = new Game();
            int gameId = game.CreateGame(new Player(1, "Sam"));

            Assert.IsTrue(game.GetGameSession(gameId) != null);
        }
    }
}