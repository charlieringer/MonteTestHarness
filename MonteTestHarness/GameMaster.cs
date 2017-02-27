
using Monte;
using System;

abstract public class GameMaster {
	//Stores all the variables needed for the Game that are shared between the two.
	protected MCTSMaster currentAI;
    protected MCTSMaster[] ais;
	protected bool gamePlaying = true;
	protected int currentPlayersTurn = 0;

    protected GameMaster(MCTSMaster _ai1, MCTSMaster _ai2)
    {

        ais = new MCTSMaster[2];
        ais[0] = _ai1;
        ais[1] = _ai2;
        currentAI = ais[currentPlayersTurn];
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
                Console.WriteLine("Game completed. Player " + result + " won.");
                gamesPlayed++;
                wins[result]++;
                reset();
            }
        }
        Console.WriteLine("Player 0 wins: " + wins[0] + " Player 1 wins: " + wins[1]);
    }

    public abstract int play();
    public abstract void reset();
}