﻿
using Monte;
using System;

abstract public class GameMaster {
	//Stores all the variables needed for the Game that are shared between the two.
	protected MCTSMaster currentAI;
    protected MCTSMaster[] ais;
	protected bool gamePlaying;
	protected int currentPlayersTurn;

    protected GameMaster()
    {
        gamePlaying = true;
        currentPlayersTurn = 0;

    }

    public void runGameSimulations(int numbGames, MCTSMaster _ai1, MCTSMaster _ai2)
    {
        ais = new MCTSMaster[2];
        ais[0] = _ai1;
        ais[1] = _ai2;
        currentAI = ais[currentPlayersTurn];

        int gamesPlayed = 0;
        int[] wins = new int[3];
        while (gamesPlayed < numbGames)
        {
            int result = play();
            if (result >= 0)
            {
                reset();
                //if (result != 2)
                //{
                    Console.WriteLine("Game completed. Player " + result + " won.");
                    gamesPlayed++;
                    wins[result]++;
                //}

            }
        }
        Console.WriteLine("Player 0 wins: " + wins[0] + " Player 1 wins: " + wins[1]);
    }

    public abstract int play();
    public abstract void reset();
}