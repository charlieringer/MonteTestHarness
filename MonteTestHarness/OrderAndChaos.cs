using System;
using Monte;

public class OrderAndChaos : GameMaster {
	OCState gameState;
    private int numbMovesPlayed = 0;

    public OrderAndChaos(MCTSMaster ai1, MCTSMaster ai2) : base(ai1, ai2)
    {
        gameState = new OCState();
    }

	// Update is called once per frame
	public override int play () {
	    //If the game is running and it is time for the AI to play

	    if (!currentAI.started)
	    {
	        numbMovesPlayed++;
	        AIState currentState = new OCAIState(gameState, currentPlayersTurn, null, 0);
	        currentAI.run(currentState);
	    }
	    else if (currentAI.done)
	    {
	        OCAIState nextAIState = (OCAIState)currentAI.next;
	        gameState = nextAIState.state;
	        currentAI.reset();
	        currentAI = ais[currentPlayersTurn];
	        currentPlayersTurn = (currentPlayersTurn + 1) % 2;
	    }
	    gameState.checkGameEnd();
	    return gameState.winner;
	}

    public override void reset()
    {
        gameState = new OCState();
        numbMovesPlayed = 0;
    }
}