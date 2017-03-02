using System.Collections.Generic;

public abstract class State
{
	//Abstract State class (to enforce that all games have the same key things in them).
	public int[,] board;
	public int numbPiecesPlayed;
	public int[] lastPiecePlayed;
    public int winner = -1;

    protected State()
    {
        //board = new int[6,6];
        //for(int i = 0; i < 6; i++)
        //    for(int j = 0; j < 6; j++)
        //        board[i,j] = -1;
    }

	//returns the board
	public int[,] getBoard() {
		return board;
	}

	public void playPiece(int[] moveData)
	{
		//Plays a piece to the board
		board [moveData [0], moveData [1]] = moveData [2];
		//And updates the numb pieces played
		numbPiecesPlayed++;
	}

	//A state needs these functions
	public abstract bool checkGameEnd ();
	public abstract bool checkGameEnd(int[] piecePlayed);
}