using System;
using Monte;

public class TicTacToe : GameMaster{
    private int numbMovesPlayed = 0;
    private AIState latestAIState;

    public TicTacToe()
    {
        latestAIState = new TTTAIState();
    }

    // Play is called once per tick
    public override int play () {
        //If the game is running and it is time for the AI to play
        if (!currentAI.started)
        {
            AIState currentState = new TTTAIState(currentPlayersTurn, null, 0, latestAIState.stateRep);
            currentAI.run(currentState);
        }
        else if (currentAI.done)
        {
            TTTAIState nextAIState = (TTTAIState)currentAI.next;
           // nextAIState.flipBoard();
            if (nextAIState == null)reset();
            else
            {
                latestAIState = nextAIState;
                currentAI.reset();
                currentPlayersTurn = (currentPlayersTurn + 1) % 2;
                currentAI = ais[currentPlayersTurn];
            }
            numbMovesPlayed++;
            //Console.WriteLine(numbMovesPlayed);
        }
        if (numbMovesPlayed == 9)
        {
            reset();
        }

        return latestAIState.getWinner();
    }

    public override void reset()
    {
        latestAIState = new TTTAIState();
        numbMovesPlayed = 0;
        currentPlayersTurn = 0;
    }
}
