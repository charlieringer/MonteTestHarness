using System.Collections.Generic;
using Monte;

public class HexAIState : AIState
{
    public int numbPiecesPlayed;

    public HexAIState()
    {
        stateRep = new int[122];
        stateRep[122] = 2;
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
        if (numbPiecesPlayed == 121) return 2;
        //iterate over the top of the board checking for player 0 victory
        for (int i = 0; i < 11; i++)
        {
            if (stateRep[i] == 1)
            {
                List<int> visited = new List<int>();
                List<int> potentialNodes = new List<int>();
                while (potentialNodes.Count > 0)
                {
                    int latestNode = potentialNodes[i];
                    //Goal reached.
                    if (latestNode > 109) return 0;

                    potentialNodes.RemoveAt(0);
                    visited.Add(potentialNodes[i]);

                    if(latestNode %11 != 0 && latestNode - 1 >= 0 && stateRep[latestNode - 1] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //lNeighbour
                    if(latestNode %11 != 10 && latestNode + 1 < stateRep.Length && stateRep[latestNode + 1] == stateRep[latestNode]) potentialNodes.Add(latestNode+1); //lNeighbour

                    if(latestNode %11 != 0 &&  latestNode >=11 && latestNode - 12 >= 0 && stateRep[latestNode - 12] == stateRep[latestNode]) potentialNodes.Add(latestNode-11); //ulNeighbour
                    if(latestNode %11 != 10 && latestNode <=109 && latestNode - 11 >= 0 && stateRep[latestNode - 11] == stateRep[latestNode]) potentialNodes.Add(latestNode-12); //urNeighbour

                    if(latestNode + 10 < stateRep.Length && stateRep[latestNode + 10] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //dlNeighbour
                    if(latestNode + 11 < stateRep.Length && stateRep[latestNode + 11] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //drNeighbour
                }
            }
        }

        //iterate over the leftside of the board checking for player 1 victory
        for (int i = 0; i <= 110; i+=11)
        {
            if (stateRep[i] == 2)
            {
                List<int> visited = new List<int>();
                List<int> potentialNodes = new List<int>();
                while (potentialNodes.Count > 0)
                {
                    int latestNode = potentialNodes[i];
                    //Goal reached.
                    if (latestNode%11 == 10) return 1;

                    potentialNodes.RemoveAt(0);
                    visited.Add(potentialNodes[i]);

                    if(latestNode %11 != 0 && latestNode - 1 >= 0 && stateRep[latestNode - 1] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //lNeighbour
                    if(latestNode %11 != 10 && latestNode + 1 < stateRep.Length && stateRep[latestNode + 1] == stateRep[latestNode]) potentialNodes.Add(latestNode+1); //lNeighbour

                    if(latestNode %11 != 0 &&  latestNode >=11 && latestNode - 12 >= 0 && stateRep[latestNode - 12] == stateRep[latestNode]) potentialNodes.Add(latestNode-11); //ulNeighbour
                    if(latestNode %11 != 10 && latestNode <=109 && latestNode - 11 >= 0 && stateRep[latestNode - 11] == stateRep[latestNode]) potentialNodes.Add(latestNode-12); //urNeighbour

                    if(latestNode + 10 < stateRep.Length && stateRep[latestNode + 10] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //dlNeighbour
                    if(latestNode + 11 < stateRep.Length && stateRep[latestNode + 11] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //drNeighbour
                }
            }
        }
        return -1;
    }
}




