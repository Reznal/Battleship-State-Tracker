using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void AttackCellTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);

            //Place ship
            board.PlaceShip(ship, 0, 0);

            //Check for hits across the whole ship
            for (int i = 0; i < ship.Length; i++)
                Assert.IsTrue(board.AttackCell(0 + i, 0));
        }

        [TestMethod()]
        public void AttackCellTwiceTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);

            //Place ship
            board.PlaceShip(ship, 0, 0);

            //Check that double hits arent counter as a hit
            board.AttackCell(0, 0);
            Assert.IsFalse(board.AttackCell(0, 0));
        }
        [TestMethod()]
        public void AttackCellOutOfBoundsTest()
        {
            Board board = new Board();

            //Check for out of bounds hit
            Assert.IsFalse(board.AttackCell(-1, -1));
            Assert.IsFalse(board.AttackCell(20, 20));
        }

        [TestMethod()]
        public void PlaceShipTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            Ship ship2 = new Ship(6, ShipDirection.Vertical, player);

            //Check placement of ships on new board
            Assert.IsTrue(board.PlaceShip(ship, 0, 0));
            Assert.IsTrue(board.PlaceShip(ship2, 0, 1));
        }

        [TestMethod()]
        public void PlaceShipOccupiedTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);

            board.PlaceShip(ship, 0, 0);

            //Check failure of ship on occupied spaces
            Assert.IsFalse(board.PlaceShip(ship, 0, 0));
        }

        [TestMethod()]
        public void PlaceShipOutOfBoundsTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);

            //Check placement out of bounds
            Assert.IsFalse(board.PlaceShip(ship, -1, -1));
            Assert.IsFalse(board.PlaceShip(ship, 20, 20));
        }

        [TestMethod()]
        public void CheckIfCellsAreFreeTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            Ship ship2 = new Ship(6, ShipDirection.Vertical, player);

            //Check placement of ships on new board
            Assert.IsTrue(board.CheckIfCellsAreFree(ship, 0, 2));
        }

        [TestMethod()]
        public void CheckIfCellsAreFreeOccupiedTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            Ship ship2 = new Ship(6, ShipDirection.Vertical, player);

            board.PlaceShip(ship, 0, 2);

            //Check that occupied spaces are occupied
            Assert.IsFalse(board.CheckIfCellsAreFree(ship, 0, 2));

            //Check for part intersection
            Assert.IsFalse(board.CheckIfCellsAreFree(ship2, 0, 0));
        }

        [TestMethod()]
        public void SetCellsTest()
        {
            Board board = new Board();
            Player player = new Player(1, "Gerald");
            Ship ship = new Ship(5, ShipDirection.Horizontal, player);
            Ship ship2 = new Ship(6, ShipDirection.Vertical, player);

            board.SetCells(ship, 0, 2);

            //Check that occupied spaces are occupied
            Assert.IsFalse(board.CheckIfCellsAreFree(ship, 0, 2));

            //Check for part intersection
            Assert.IsFalse(board.CheckIfCellsAreFree(ship2, 0, 0));
        }
    }
}