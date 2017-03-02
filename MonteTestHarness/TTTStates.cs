using System.Collections.Generic;
using Monte;

public class TTTState : State
{

    public TTTState()
    {
        //Makes a blank game state (for the start of the game)
        numbPiecesPlayed = 0;
        board = new int[3,3];
        //for(int i = 0; i < 3; i++)
            //for(int j = 0; j < 3; j++)
                //board[i,j] = 0;
    }

    public TTTState(int[,] _board, int _numbPiecesPlayed, int[] _lastPiecePlayed)
    {
        board = _board;
        numbPiecesPlayed = _numbPiecesPlayed;
        lastPiecePlayed = _lastPiecePlayed;
    }

    public override bool checkGameEnd()
    {
        //Check the game end.
        return checkGameEnd(lastPiecePlayed);
    }

    public override bool checkGameEnd(int[] piecePlayed)
    {
        if (piecePlayed == null) return false;

        int x = piecePlayed[0];
        int y = piecePlayed[1];
        int colourPlayed = piecePlayed[2];
        int countX = 0;
        int countY = 0;
        int countD1 = 0;
        int countD2 = 0;
        for (int i = 0; i < 3; i++)
        {
            //Check orthognal directions
            if (board[x, i] == colourPlayed) //If we find a match
                countX++; //Increment the count
            if (board[i, y] == colourPlayed) //If we find a match
                countY++; //Increment the count
            if (board[i, i] == colourPlayed)
                countD1++;
            if ((i < 1 && board[0,2] == colourPlayed) ||(i == 1 && board[1,1] == colourPlayed) || (i > 1 && board[2,0] == colourPlayed))
                countD2++;
        }
        //if either direction is at least 3
        if (countX >= 3 || countY >= 3 || countD1 >= 3 || countD2 >= 3)
        {
            winner = colourPlayed-10;
            //The game is over (Order wins)
            return true;
        }
        //Otherwise game is still going on.
        return false;
    }
}


public class TTTAIState : AIState
{
    public TTTState state;

    public TTTAIState(TTTState _state, int pIndex, AIState _parent, int _depth) : base(pIndex, _parent, _depth)
    {
        state = _state;
        stateRep = new int[10];
        int[,] board = state.getBoard();
        int i = 0;
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                stateRep[i] = board[x, y];
                i++;
            }
        }
        stateRep[9] = pIndex;
    }

    public override List<AIState> generateChildren()
    {
        List<AIState> children = new List<AIState> ();
        int newPIndx = (playerIndex == 0) ? 1 : 0;
        int newNumbPieces = state.numbPiecesPlayed+1;

        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                int pieceAtPosition = state.getBoard () [x, y];
                if (pieceAtPosition == 0) {
                    int[,] newBoard = (int[,])state.getBoard().Clone ();
                    newBoard [x, y] = newPIndx+10;
                    TTTState childState = new TTTState (newBoard, newNumbPieces, new int[3]{ x, y, newPIndx+10});
                    TTTAIState childAIState = new TTTAIState (childState, newPIndx, this, depth + 1);
                    children.Add (childAIState);
                }
            }
        }
        this.children = children;
        return children;
    }

    public override int getWinner()
    {
        //If the game is over
        if (state.checkGameEnd ()) {
            //Return the indx of the player who won
            return state.winner;
        }
        //Otherwise still playing so return -1
        return -1;
    }
}
