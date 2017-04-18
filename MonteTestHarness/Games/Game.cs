using Monte;
using System;

//Base class for all of the games
public abstract class Game {
	//Stores all the variables needed for the Game that are common
	protected AIAgent currentAI;
    protected AIAgent[] ais;
    protected int currentPlayersTurn = 0;
    protected int numbMovesPlayed = 0;
    protected AIState latestAIState = null;

    public void runGameSimulations(int numbGames, AIAgent _ai1, AIAgent _ai2)
    {
        //Set the two passed in AIs to the ais array
        ais = new AIAgent[2];
        ais[0] = _ai1;
        ais[1] = _ai2;
        //And set the current move
        currentAI = ais[currentPlayersTurn];
        //We have played 0 games
        int gamesPlayed = 0;
        //For storing the results
        int[] results = new int[3];
        //Whilst we still have games left
        while (gamesPlayed < numbGames)
        {
            //Play
            int result = play();
            //And if the game is over
            if (result >= 0)
            {
                //Increment the games played
                gamesPlayed++;
                //Update which player won (or draw)
                results[result]++;
                //Reset the state for another game
                reset();
            }
        }
        //Once done output the results
        Console.WriteLine("Player 0 wins: " + results[0] + "     Player 1 wins: " + results[1] + "     Draws: " + results[2]);
    }

    //Functions implemented by the games
    public abstract int play();
    public abstract void reset();
}