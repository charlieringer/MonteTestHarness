
using Monte;
using System;

public abstract class Game {
	//Stores all the variables needed for the Game that are shared between the two.
	protected AIAgent currentAI;
    protected AIAgent[] ais;
	protected bool gamePlaying;
	protected int currentPlayersTurn;
    protected int numbMovesPlayed = 0;
    protected AIState latestAIState = null;

    protected Game()
    {
        gamePlaying = true;
        currentPlayersTurn = 0;
    }

    public void runGameSimulations(int numbGames, AIAgent _ai1, AIAgent _ai2)
    {
        ais = new AIAgent[2];
        ais[0] = _ai1;
        ais[1] = _ai2;
        currentAI = ais[currentPlayersTurn];

        int gamesPlayed = 0;
        int[] wins = new int[3];
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
        Console.WriteLine("Player 0 wins: " + wins[0] + "     Player 1 wins: " + wins[1] + "     Draws: " + wins[2]);
    }

    public abstract int play();
    public abstract void reset();
}