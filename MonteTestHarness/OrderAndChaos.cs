using System;
using Monte;

public class OrderAndChaos : GameMaster {
	OCState gameState;
    private int numbMovesPlayed = 0;

    public OrderAndChaos(MCTSMaster ai1) : base(ai1)
    {
        gameState = new OCState();
    }

	// Update is called once per frame
	public override int play () {
	    //If the game is running and it is time for the AI to play
	    if (!ai.started)
	    {
	        numbMovesPlayed++;
	        Console.WriteLine("Kicking off AI. Move: " + numbMovesPlayed);
	        AIState currentState = new OCAIState(gameState, currentPlayersTurn, null, 0);
	        ai.run(currentState);
	    }
	    else if (ai.done)
	    {
	        Console.WriteLine("");
	        OCAIState nextAIState = (OCAIState)ai.next;
	        gameState = nextAIState.state;
	        ai.reset();
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