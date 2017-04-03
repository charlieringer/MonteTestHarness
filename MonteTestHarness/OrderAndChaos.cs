using System;
using Monte;

public class OrderAndChaos : GameMaster
{
    private int[] lastMovePlayed;

    public OrderAndChaos()
    {
        latestAIState = new OCAIState();
    }

	// Update is called once per frame
	public override int play () {
	    //If the game is running and it is time for the AI to play

	    if (!currentAI.started)
	    {
	        numbMovesPlayed++;
	        AIState currentState = new OCAIState(currentPlayersTurn, null, 0, latestAIState.stateRep, lastMovePlayed, numbMovesPlayed);
	        currentAI.run(currentState);
	    }
	    else if (currentAI.done)
	    {
	        OCAIState nextAIState = (OCAIState)currentAI.next;
	        if (nextAIState == null) reset();
	        else
	        {
	            latestAIState = nextAIState;
	            currentAI.reset();
	            currentPlayersTurn = (currentPlayersTurn + 1) % 2;
	            currentAI = ais[currentPlayersTurn];
	            lastMovePlayed = nextAIState.lastPiecePlayed;
	            numbMovesPlayed++;
	        }
	    }
	    return latestAIState.getWinner();
	}

    public override void reset()
    {
        latestAIState = new OCAIState();
        numbMovesPlayed = 0;
        currentPlayersTurn = 0;
    }
}