
using Monte;
using System;

abstract public class GameMaster {
	//Stores all the variables needed for the Game that are shared between the two.
	protected MCTSMaster ai;
	protected bool gamePlaying = true;
	protected int currentPlayersTurn;

    protected GameMaster(MCTSMaster _ai)
    {
        ai = _ai;
    }
    public void runGameSimulations(int numbGames)
    {
        int gamesPlayed = 0;
        int[] wins = new int[2];
        while (gamesPlayed < numbGames)
        {
            int result = play();
            if (result >= 0)
            {
                gamesPlayed++;
                wins[result]++;
                reset();
            }
        }
        Console.WriteLine("Player 1 wins: " + wins[0] + " Player 2 wins: " + wins[1]);
    }

    public abstract int play();
    public abstract void reset();
}