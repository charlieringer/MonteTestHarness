using System;
using Monte;

public class Train
{
    public static void TrainMain(string[] arguements)
    {
        //Kick off training
        Console.WriteLine("Starting Training.");
        if (arguements.Length != 4)
        {
            Console.WriteLine("Monte Test Harness: Fatal Error: Unable to Train, not enough or too many arguements.");
            return;
        }
        int games = int.Parse(arguements[2]);
        int episodes = int.Parse(arguements[3]);
        Model model = new Model("Settings/DefaultSettings.xml");
        if(arguements[1] == "TicTacToe") model.train(games, episodes, () => new TTTAIState());
        else if (arguements[1] == "OrderAndChaos") model.train(games, episodes, () => new OCAIState());
        else if (arguements[1] == "Hex") model.train(games, episodes, () => new HexAIState());
        else
        {
            Console.WriteLine("Monte Test Harness: Fatal Error: Unable to Train, command line arguement for game type did not match expected values.");
            return;
        }
        Console.WriteLine("Done");
    }
    public static void TrainMain()
    {
        //Kick off training
        Console.WriteLine("Starting Training.");
         Model model = new Model("Settings/DefaultSettings.xml");
        //model.train(100, 1000, () => new TTTAIState());
        model.train(100, 1000, () => new OCAIState());
        //model.train(100, 1000, () => new HexAIState());
        Console.WriteLine("Done");
    }

}
