
using System;
using System.Collections.Generic;

public class Game
{
    public static Game instance;

    private Dictionary<int, GameSession> _games;
    private int _nextGameId;

    public Game()
    {
        if (instance != null)
            return;

        instance = this;
        _games = new Dictionary<int, GameSession>();
    }

    public int CreateGame(Player player)
    {
        _games.Add(_nextGameId, new GameSession(player));
        _nextGameId++;

        return _nextGameId - 1;
    }

    public GameSession GetGameSession( int id)
    {
        if (_games.ContainsKey(id))
            return _games[id];

        return null;
    }
}