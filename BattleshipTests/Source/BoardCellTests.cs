using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class BoardCellTests
    {
        [TestMethod()]
        public void SetShipTest()
        {
            BoardCell cell = new BoardCell();
            Player player = new Player(1, "Frank");
            Ship ship = new Ship(2, ShipDirection.Horizontal, player);

            cell.SetShip(ship);
            Assert.AreEqual(ship, cell.Ship);
        }

        [TestMethod()]
        public void HitCellWithoutShipTest()
        {
            BoardCell cell = new BoardCell();

            //Check hit cell when there is no ship
            cell.HitCell();
            Assert.IsTrue(cell.State == CellState.Empty);
        }

        [TestMethod()]
        public void HitCellWithShipTest()
        {
            BoardCell cell = new BoardCell();
            Player player = new Player(1, "Frank");
            Ship ship = new Ship(2, ShipDirection.Horizontal, player);

            cell.SetShip(ship);

            //Check hit cell when there is a ship
            cell.HitCell();
            Assert.IsTrue(cell.State == CellState.Hit);
        }
    }
}