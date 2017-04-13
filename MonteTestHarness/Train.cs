using System;
using Monte;

public class Train
{
    public static void TrainMain()
    {
        Console.WriteLine("Starting Training.");
        Model model = new Model("Settings/OrderAndChaosSettings.xml");
        //model.train(100, 1000, () => new TTTAIState());
        //model.train(100, 1000, () => new OCAIState());
        model.train(100, 1000, () => new HexAIState());
        Console.WriteLine("Done");
    }

}
