
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

    public bool PlaceShip(Ship ship, int x, int y)
    {
        if (!_board.PlaceShip(ship, x, y)) return false;

        _ships.Add(ship);
        return true;
    }

    //Checks to see if all players ships are destroyed
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