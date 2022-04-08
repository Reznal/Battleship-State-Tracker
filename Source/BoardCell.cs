
public class BoardCell
{
    public CellState State { get; private set; }
    private Ship _ship;

    //Set ship for cell
    public void SetShip(Ship ship)
    {
        _ship = ship;
        State = CellState.Ship;
    }

    //Set cell to be in the hit state
    //Checks if this cell contains a ship
    public void HitCell()
    {
        if (State != CellState.Ship) return;

        State = CellState.Hit;
        _ship.ShipHit();
    }
}