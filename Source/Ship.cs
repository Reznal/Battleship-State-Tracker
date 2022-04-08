
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

    //Update data to show the ship has been hit
    public void ShipHit()
    {
        _timesHit++;

        if (_timesHit >= Length)
        {
            IsAlive = false;
            _owner.CheckForLoss();
        }
    }
}