
using System;
using System;

public class Ship
{
    public ShipDirection Direction { get; private set; }
    public int Length { get; private set; }
    public bool IsAlive { get; private set; }

    private int _timesHit;
    private Player _owner;

    public Ship(int length, ShipDirection direction, Player owner)
    {
        Length = length;
        Direction = direction;
        IsAlive = true;
        _owner = owner;
    }

    /// <summary>
    /// Update data to show the ship has been hit
    /// </summary>
    public void ShipHit()
    {
        _timesHit++;
        Console.WriteLine(_timesHit);

        if (_timesHit >= Length)
        {
            IsAlive = false;
            _owner.CheckForLoss();
        }
    }
}