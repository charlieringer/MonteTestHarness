using Monte;

public class TicTacToe : Game{

    public TicTacToe()
    {
        latestAIState = new TTTAIState();
    }

    // Play is called once per tick
    public override int play () {
        //If the current AI has not been started
        if (!currentAI.started)
        {
            //Start it
            AIState currentState = new TTTAIState((currentPlayersTurn+1)%2, null, 0, latestAIState.stateRep);
            currentAI.run(currentState);
        }
        //Otherwise if it is done
        else if (currentAI.done)
        {
            //get the next state
            TTTAIState nextAIState = (TTTAIState)currentAI.next;
            //If it is null just reset (this is an error)
            if (nextAIState == null) reset();
            else
            {
                //Otherwise unpack the state
                latestAIState = nextAIState;
                //Reset the current AI
                currentAI.reset();
                //And update which AI is playing
                currentPlayersTurn = (currentPlayersTurn + 1) % 2;
                currentAI = ais[currentPlayersTurn];
            }
            //Update the number of moves
            numbMovesPlayed++;
        }
        //Return the winner (or -1 is the game is still going)
        return latestAIState.getWinner();
    }

    //resets the game (ready to be played again)
    public override void reset()
    {
        //Reset the state
        latestAIState = new TTTAIState();
        //And the number odf moves played
        numbMovesPlayed = 0;
        //And who is playing
        currentPlayersTurn = 0;
        currentAI = ais[currentPlayersTurn];
    }
}
