using System.Collections.Generic;
using Monte;

public class TTTAIState : AIState
{
    public TTTAIState()
    {
        stateRep = new int[9];
        playerIndex = 0;
        parent = null;
        depth = 0;
    }
    public TTTAIState(int[] _stateRep, int pIndex, AIState _parent, int _depth) : base(pIndex, _parent, _depth)
    {
        stateRep = new int[_stateRep.Length];
        for (int i = 0; i < _stateRep.Length; i++)
        {
            if (_stateRep[i] == 1) stateRep[i] = -1;
            else if (_stateRep[i] == -1) stateRep[i] = 1;
        }
    }

    public override List<AIState> generateChildren()
    {
        List<AIState> children = new List<AIState> ();
        int newPIndx = (playerIndex == 0) ? 1 : 0;

        for (int i = 0; i < stateRep.Length; i++) {
            if (stateRep[i] == 0) {
                int[] newBoard = (int[])stateRep.Clone ();
                newBoard [i] = 1;
                TTTAIState childAIState = new TTTAIState (newBoard, newPIndx, this, depth + 1);
                children.Add (childAIState);
            }
        }
        this.children = children;
        return children;
    }

    public override int getWinner()
    {
        if (stateRep[0] == stateRep[3] && stateRep[3] == stateRep[6] && stateRep[0] != 0)
            return (playerIndex+1)%2;
        if (stateRep[1] == stateRep[4] && stateRep[4] == stateRep[7] && stateRep[1] != 0)
            return (playerIndex+1)%2;
        if (stateRep[2] == stateRep[5] && stateRep[5] == stateRep[8] && stateRep[2] != 0)
            return (playerIndex+1)%2;
        if (stateRep[0] == stateRep[1] && stateRep[1] == stateRep[2] && stateRep[0] != 0)
            return (playerIndex+1)%2;
        if (stateRep[3] == stateRep[4] && stateRep[4] == stateRep[5] && stateRep[3] != 0)
            return (playerIndex+1)%2;
        if (stateRep[6] == stateRep[7] && stateRep[7] == stateRep[8] && stateRep[6] != 0)
            return (playerIndex+1)%2;
        if (stateRep[0] == stateRep[4] && stateRep[4] == stateRep[8] && stateRep[0] != 0)
            return (playerIndex+1)%2;
        if (stateRep[2] == stateRep[4] && stateRep[4] == stateRep[6] && stateRep[2] != 0)
            return (playerIndex+1)%2;
        return -1;
    }

    public void flipBoard()
    {
        for (int i = 0; i < stateRep.Length; i++)
        {
            if (stateRep[i] == 1) stateRep[i] = -1;
            else if (stateRep[i] == -1) stateRep[i] = 1;
        }

    }
}