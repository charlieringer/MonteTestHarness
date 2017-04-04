using System;
using Monte;

public class Hex : Game
{
    public Hex()
    {
        latestAIState = new HexAIState();
    }

    // Play is called once per tick
    public override int play () {
        //If the game is running and it is time for the AI to play
        if (!currentAI.started)
        {
            AIState currentState = new HexAIState(currentPlayersTurn, null, 0, latestAIState.stateRep, numbMovesPlayed);
            currentAI.run(currentState);
        }
        else if (currentAI.done)
        {
            HexAIState nextAIState = (HexAIState)currentAI.next;
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

        return latestAIState.getWinner();
    }

    public override void reset()
    {
        latestAIState = new TTTAIState();
        numbMovesPlayed = 0;
        currentPlayersTurn = 0;
    }
}
