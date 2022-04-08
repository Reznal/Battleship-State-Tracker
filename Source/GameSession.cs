
public class GameSession
{

    private Player player1;
    private Player player2;

    private byte _playerTurn;

    public GameSession()
    {
        player1 = new Player(1);
        player2 = new Player(2);

        player1.OnPlayerLoss += Player_OnPlayerLoss;
        player2.OnPlayerLoss += Player_OnPlayerLoss;
    }

    //Called when a player has lost
    private void Player_OnPlayerLoss(int id)
    {
        //#TODO finish game here

        player1.OnPlayerLoss -= Player_OnPlayerLoss;
        player2.OnPlayerLoss -= Player_OnPlayerLoss;
    }
}