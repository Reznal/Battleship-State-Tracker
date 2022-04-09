using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void PlaceShipTest()
        {
            Player player = new Player(7, "Jerry");
            Ship ship = new Ship(4, ShipDirection.Horizontal, player);
            player.PlaceShip(ship, 5, 5);

            Assert.IsFalse(player.Board.CheckIfCellsAreFree(ship, 5, 5));
        }

        [TestMethod()]
        public void PlaceShipOutOfBoundsTest()
        {
            Player player = new Player(7, "Jerry");
            Ship ship = new Ship(4, ShipDirection.Horizontal, player);

            Assert.IsFalse(player.PlaceShip(ship, -1, 5));
            Assert.IsFalse(player.PlaceShip(ship, 0, 20));
        }

        [TestMethod()]
        public void CheckForLossTest()
        {
            Player player = new Player(7, "Jerry");
            Ship ship = new Ship(4, ShipDirection.Vertical, player);
            player.PlaceShip(ship, 5, 5);

            player.Attacked(5, 5);
            player.Attacked(5, 6);
            player.Attacked(5, 7);
            player.Attacked(5, 8);

            Assert.IsTrue(player.CheckForLoss());
        }

        [TestMethod()]
        public void CheckForLossInvalidTest()
        {
            Player player = new Player(7, "Jerry");
            Ship ship = new Ship(4, ShipDirection.Horizontal, player);
            player.PlaceShip(ship, 5, 5);

            player.Attacked(5, 5);

            Assert.IsFalse(player.CheckForLoss());
        }
    }
}