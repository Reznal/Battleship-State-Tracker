using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class GameSessionTests
    {
        [TestMethod()]
        public void PlayerExistsValidTest()
        {
            Player player = new Player(1, "Mavis");
            GameSession session = new GameSession(player);

            Assert.IsTrue(session.PlayerExists(player.Id));
        }

        [TestMethod()]
        public void PlayerExistsInvalidTest()
        {
            Player player = new Player(1, "Mavis");
            GameSession session = new GameSession(player);

            Assert.IsFalse(session.PlayerExists(5));
        }
    }
}