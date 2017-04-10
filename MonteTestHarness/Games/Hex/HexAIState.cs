using System.Collections.Generic;
using Monte;

public class HexAIState : AIState
{
    public int numbPiecesPlayed;
    private const int width = 9;
    
    public HexAIState()
    {
        stateRep = new int[width*width+1];
        stateRep[stateRep.Length-1] = 2;
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
        if (numbPiecesPlayed == width*width) return 2;
        //iterate over the top of the board checking for player 0 victory
        for (int i = 0; i < width; i++)
        {
            if (stateRep[i] == 1)
            {
                List<int> visited = new List<int>();
                List<int> potentialNodes = new List<int>();
                while (potentialNodes.Count > 0)
                {
                    int latestNode = potentialNodes[i];
                    //Goal reached.
                    if (latestNode > (width*width)-width-1) return 0;

                    potentialNodes.RemoveAt(0);
                    visited.Add(potentialNodes[i]);

                    if(latestNode %width != 0 && latestNode - 1 >= 0 && stateRep[latestNode - 1] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //lNeighbour
                    if(latestNode %width != width-1 && latestNode + 1 < stateRep.Length && stateRep[latestNode + 1] == stateRep[latestNode]) potentialNodes.Add(latestNode+1); //lNeighbour

                    if(latestNode %width != 0 &&  latestNode >=width && latestNode - (width+1) >= 0 && stateRep[latestNode - (width+1)] == stateRep[latestNode]) potentialNodes.Add(latestNode-width); //ulNeighbour
                    if(latestNode %width != (width-1) && latestNode <=((width*width)-width-1) && latestNode - width >= 0 && stateRep[latestNode - width] == stateRep[latestNode]) potentialNodes.Add(latestNode-(width+1)); //urNeighbour

                    if(latestNode + (width-1) < stateRep.Length && stateRep[latestNode + (width-1)] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //dlNeighbour
                    if(latestNode + width < stateRep.Length && stateRep[latestNode + width] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //drNeighbour
                }
            }
        }

        //iterate over the leftside of the board checking for player 1 victory
        for (int i = 0; i <= width*width-width; i+=width)
        {
            if (stateRep[i] == 2)
            {
                List<int> visited = new List<int>();
                List<int> potentialNodes = new List<int>();
                while (potentialNodes.Count > 0)
                {
                    int latestNode = potentialNodes[i];
                    //Goal reached.
                    if (latestNode%width == width-1) return 1;

                    potentialNodes.RemoveAt(0);
                    visited.Add(potentialNodes[i]);

                    if(latestNode %width != 0 && latestNode - 1 >= 0 && stateRep[latestNode - 1] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //lNeighbour
                    if(latestNode %width != width-1 && latestNode + 1 < stateRep.Length && stateRep[latestNode + 1] == stateRep[latestNode]) potentialNodes.Add(latestNode+1); //lNeighbour

                    if(latestNode %width != 0 &&  latestNode >=width && latestNode - (width+1) >= 0 && stateRep[latestNode - (width+1)] == stateRep[latestNode]) potentialNodes.Add(latestNode-width); //ulNeighbour
                    if(latestNode %width != width-1 && latestNode <=((width*width)-width-1) && latestNode - width >= 0 && stateRep[latestNode - width] == stateRep[latestNode]) potentialNodes.Add(latestNode-(width+1)); //urNeighbour

                    if(latestNode + (width-1) < stateRep.Length && stateRep[latestNode + (width-1)] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //dlNeighbour
                    if(latestNode + width < stateRep.Length && stateRep[latestNode + width] == stateRep[latestNode]) potentialNodes.Add(latestNode-1); //drNeighbour
                }
            }
        }
        return -1;
    }
}




