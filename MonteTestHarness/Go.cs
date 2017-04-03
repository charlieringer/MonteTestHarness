//using System;
//using Monte;
//
////Game master object for Go specifically
//public class Go : GameMaster {
//    GOState gameState;
//    private int numbMovesPlayed = 0;
//
//    public Go()
//    {
//        gameState = new GOState();
//    }
//
//	// Play is called once per tick
//	public override int play () {
//		//If the game is running and it is time for the AI to play
//	    if (!currentAI.started)
//	    {
//	        numbMovesPlayed++;
//	        AIState currentState = new GOAIState(gameState, currentPlayersTurn, null, 0);
//	        currentAI.run(currentState);
//	    }
//	    else if (currentAI.done)
//	    {
//	        GOAIState nextAIState = (GOAIState)currentAI.next;
//	        gameState = nextAIState.state;
//	        currentAI.reset();
//	        currentAI = ais[currentPlayersTurn];
//	        currentPlayersTurn = (currentPlayersTurn + 1) % 2;
//	    }
//	    if (numbMovesPlayed == 100) reset();
//	    gameState.checkGameEnd();
//
//	    return gameState.winner;
//	}
//
//    public override void reset()
//    {
//        gameState = new GOState();
//        numbMovesPlayed = 0;
//    }
//}
//
