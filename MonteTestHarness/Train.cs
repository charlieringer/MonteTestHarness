using System;
using Monte;

public class Train
{
    public static void TrainMain()
    {
        Model model = new Model();
        //model.train(100, 1000, () => new TTTAIState());
        model.train(100, 100, () => new OCAIState());
        Console.Write("Done");
    }

}
