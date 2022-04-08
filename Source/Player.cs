
using System;
using System.Collections.Generic;

public class Player
{
    public Action<int> OnPlayerLoss;

    public int Id { get; private set; }
    public string Username { get; private set; }

    private Board _board;
    private List<Ship> _ships;

    public Player(int id, string username)
    {
        Id = id;
        Username = username;

        _board = new Board();
        _ships = new List<Ship>();
    }

    /// <summary>
    /// Place a ship for player
    /// Returns result of placement
    /// </summary>
    /// <returns></returns>
    public bool PlaceShip(Ship ship, int x, int y)
    {
        if (!_board.PlaceShip(ship, x, y)) return false;

        _ships.Add(ship);
        return true;
    }

    /// <summary>
    /// Player has been attacked - return hit or not
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Attacked(int x, int y) => _board.AttackCell(x, y);

    /// <summary>
    /// Checks to see if all players ships are destroyed
    /// </summary>summary>
    public void CheckForLoss()
    {
        foreach (Ship ship in _ships)
        {
            if (ship.IsAlive) return;
        }

        //Player has lost
        OnPlayerLoss?.Invoke(Id);
    }

}