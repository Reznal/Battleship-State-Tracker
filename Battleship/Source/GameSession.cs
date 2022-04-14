
public class GameSession
{

    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }

    private byte _playerTurn; //#TODO

    public GameSession(Player player)
    {
        Player1 = player;

        //#TODO create joining state to game - using 1 player for now to test
        Player2 = new Player(player.Id + 1, "Bot");

        Player1.OnPlayerLoss += Player_OnPlayerLoss;
        Player2.OnPlayerLoss += Player_OnPlayerLoss;
    }

    /// <summary>
    /// Checks if the given id is in this game
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool PlayerExists(int id) => Player1.Id == id || Player2.Id == id;

    /// <summary>
    /// Called when a player has lost
    /// </summary>
    /// <param name="id"></param>
    private void Player_OnPlayerLoss(int id)
    {
        //#TODO finish game here

        Player1.OnPlayerLoss -= Player_OnPlayerLoss;
        Player2.OnPlayerLoss -= Player_OnPlayerLoss;
    }
}