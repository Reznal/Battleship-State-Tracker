
using System;
using System.Collections.Generic;

public class Player
{
    public Action<int> OnPlayerLoss;

    public int Id { get; private set; }
    public string Username { get; private set; }
    public Board Board { get; private set; }

    private List<Ship> _ships;

    public Player(int id, string username)
    {
        Id = id;
        Username = username;

        Board = new Board();
        _ships = new List<Ship>();
    }

    /// <summary>
    /// Place a ship for player
    /// Returns result of placement
    /// </summary>
    /// <returns></returns>
    public bool PlaceShip(Ship ship, int x, int y)
    {
        if (!Board.PlaceShip(ship, x, y)) return false;

        _ships.Add(ship);
        return true;
    }

    /// <summary>
    /// Player has been attacked - return hit or not
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Attacked(int x, int y) => Board.AttackCell(x, y);

    /// <summary>
    /// Checks to see if all players ships are destroyed
    /// </summary>summary>
    public bool CheckForLoss()
    {
        foreach (Ship ship in _ships)
        {
            if (ship.IsAlive) return false;
        }

        //Player has lost
        OnPlayerLoss?.Invoke(Id);

        return true;
    }

}