
public class BoardCell
{
    public CellState State { get; private set; } = CellState.Empty;

    public Ship Ship { get; private set; }

    /// <summary>
    /// Set ship for cell
    /// </summary>
    /// <param name="ship"></param>
    public void SetShip(Ship ship)
    {
        Ship = ship;
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
        Ship.ShipHit();
    }
}