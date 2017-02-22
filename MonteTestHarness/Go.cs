using System;
using Monte;

//Game master object for Go specifically
public class Go : GameMaster {
    GOState gameState;
    private int numbMovesPlayed = 0;

    public Go(MCTSMaster ai1) : base(ai1)
    {
        gameState = new GOState();
    }

	// Play is called once per tick
	public override int play () {
		//If the game is running and it is time for the AI to play
	    if (!ai.started)
	    {
	        numbMovesPlayed++;
	        Console.WriteLine("Kicking off AI. Move: " + numbMovesPlayed);
	        AIState currentState = new GOAIState(gameState, currentPlayersTurn, null, 0);
	        ai.run(currentState);
	    }
	    else if (ai.done)
	    {
	        Console.WriteLine("White Score: " + gameState.whiteCaptureScore + " Black Score: " + gameState.blackCaptureScore);
	        Console.WriteLine("");
	        GOAIState nextAIState = (GOAIState)ai.next;
	        gameState = nextAIState.state;
	        ai.reset();
	        currentPlayersTurn = (currentPlayersTurn + 1) % 2;
	    }
	    if (numbMovesPlayed == 100) reset();
	    gameState.checkGameEnd();

	    return gameState.winner;
	}

    public override void reset()
    {
        gameState = new GOState();
        numbMovesPlayed = 0;
    }
}

