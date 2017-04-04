using System.Collections.Generic;
using Monte;

public class HexAIState : AIState
{
    public int numbPiecesPlayed;

    public HexAIState()
    {
        stateRep = new int[37];
        stateRep[36] = 2;
        playerIndex = 0;
        parent = null;
        depth = 0;
    }

    public HexAIState(int pIndex, AIState _parent, int _depth, int[] _stateRep,
        int _numbPiecesPlayed) : base(pIndex, _parent, _depth,
        _stateRep)
    {
        numbPiecesPlayed = _numbPiecesPlayed;
    }

    public override List<AIState> generateChildren()
    {
        //Generates all possible child states from this state
        List<AIState> children = new List<AIState> ();
        //Swap the player
        int newPIndx = (playerIndex + 1) % 2;
        //Increment the number of peices played
        int newNumbPieces = numbPiecesPlayed+1;
        //Loop through all of the board pieces
        for (int i = 0; i < stateRep.Length; i++) {
            //if it is 0 (therefore empty)
            if (stateRep[i] == 0) {
                //We have a possible peice to play so clone the board
                int[] newStateRep = (int[])stateRep.Clone ();
                int[] move = {i, 1};
                //and simululate playing a white piece
                newStateRep [i] = playerIndex+1;
                HexAIState childAIState = new HexAIState (newPIndx, this, depth+1, newStateRep, newNumbPieces);
                //And add this state as a child
                children.Add (childAIState);
            }
        }
        //Set the children of this node
        this.children = children;
        //Also return it.
        return children;
    }

    public override int getWinner()
    {
        return -1;
    }
}




