
public class BoardCell
{
    public CellState State { get; private set; }
    private Ship _ship;

    /// <summary>
    /// Set ship for cell
    /// </summary>
    /// <param name="ship"></param>
    public void SetShip(Ship ship)
    {
        _ship = ship;
        State = CellState.Ship;
    }

    /// <summary>
    /// Set cell to be in the hit state
    /// Checks if this cell contains a ship
    /// </summary>
    public void HitCell()
    {
        if (State != CellState.Ship) return;

        State = CellState.Hit;
        _ship.ShipHit();
    }
}