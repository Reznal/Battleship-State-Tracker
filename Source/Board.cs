
public class Board
{
    private readonly int BOARD_SIZE = 10;

    private BoardCell[][] _cells;

    public Board()
    {
        _cells = new BoardCell[BOARD_SIZE][];

        for (int i = 0; i < BOARD_SIZE; i++)
        {
            _cells[i] = new BoardCell[BOARD_SIZE];

            for (int j = 0; j < BOARD_SIZE; j++)
            {
                _cells[i][j] = new BoardCell();
            }
        }
    }

    //Attack a given cell
    public bool AttackCell(int x, int y)
    {
        if (_cells[x][y].State != CellState.Ship) return false;

        _cells[x][y].HitCell();
        return true;
    }

    //Checks if a cell has been hit
    public bool HasBeenHit(int x, int y) => _cells[x][y].State == CellState.Hit;

    //Place a ship at the given position
    public bool PlaceShip(Ship ship, int x, int y)
    {
        //Check that placement position is within board
        if (x >= BOARD_SIZE || x < 0 || y >= BOARD_SIZE || y < 0) return false;

        //Check that all cells in the correct direction are free
        if (!CheckIfCellsAreFree(ship, x, y)) return false;

        //Add ship to cells needed
        SetCells(ship, x, y);

        return true;
    }

    //Check if the cells the ship needs are free
    private bool CheckIfCellsAreFree(Ship ship, int x, int y)
    {
        if (ship.Direction == ShipDirection.Horizontal)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                if (x + i >= BOARD_SIZE) return false;
                if (_cells[x + i][y].State != CellState.Empty) return false;
            }
        }
        else
        {
            for (int i = 0; i < ship.Length; i++)
            {
                if (y + i >= BOARD_SIZE) return false;
                if (_cells[x][y + i].State != CellState.Empty) return false;
            }
        }

        return true;
    }

    //Set cell values for the given ship and position
    private void SetCells(Ship ship, int x, int y)
    {
        if (ship.Direction == ShipDirection.Horizontal)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                _cells[x + i][y].SetShip(ship);
            }
        }
        else
        {
            for (int i = 0; i < ship.Length; i++)
            {
                _cells[x][y + i].SetShip(ship);
            }
        }
    }
}
