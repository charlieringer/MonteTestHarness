using System;
using Monte;

public class TicTacToe : GameMaster{
    TTTState gameState;
    private int numbMovesPlayed = 0;

    public TicTacToe(MCTSMaster ai1, MCTSMaster ai2) : base(ai1, ai2)
    {
        gameState = new TTTState();
    }

    // Play is called once per tick
    public override int play () {
        //If the game is running and it is time for the AI to play
        if (!currentAI.started)
        {
            numbMovesPlayed++;
            AIState currentState = new TTTAIState(gameState, currentPlayersTurn, null, 0);
            currentAI.run(currentState);
        }
        else if (currentAI.done)
        {
            TTTAIState nextAIState = (TTTAIState)currentAI.next;
            if (nextAIState == null)
            {
                reset();
            }
            else
            {
                gameState = nextAIState.state;
                currentAI.reset();
                currentAI = ais[currentPlayersTurn];
                currentPlayersTurn = (currentPlayersTurn + 1) % 2;
            }
        }
        if (numbMovesPlayed == 10) reset();
        gameState.checkGameEnd();

        return gameState.winner;
    }

    public override void reset()
    {
        gameState = new TTTState();
        numbMovesPlayed = 0;
    }
}
