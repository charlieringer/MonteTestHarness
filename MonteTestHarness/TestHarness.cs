using System;
using System.Collections.Generic;
using Monte;

namespace MonteTestHarness
{
    internal class TestHarness
    {
        public static void Main(string[] args)
        {
            //trainSimulation();
            runSimulation();
        }

        public static void trainSimulation()
        {
            DLModel model = new DLModel(37);

            model.train(1000, 10000, () => { return new GOAIState(new GOState(), 0, null, 0); });
            Console.Write("Done");
        }

        public static void runSimulation()
        {
            BasicMCTS aiBasic = new BasicMCTS (0.5, 1.4, 36);
            DLModel model = new DLModel("TestGoModel.model");
            RandomAgent aiRandom = new RandomAgent();
            MCTSWithLearning aiLearnt = new MCTSWithLearning(2, 1.4, 36, model);
            GameMaster game = new Go(aiBasic, aiBasic);
            game.runGameSimulations(10);


           // game.runGameSimulations(10);
           // game = new Go(aiRandom,aiLearnt);
           // game.runGameSimulations(10);
        }
    }
}