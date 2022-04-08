
using System;
using System.Collections.Generic;

public class Player
{
    public Action<int> OnPlayerLoss;

    public int Id { get; private set; }
    private Board _board;
    private List<Ship> _ships;

    public Player(int id)
    {
        Id = id;

        _board = new Board();
        _ships = new List<Ship>();
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