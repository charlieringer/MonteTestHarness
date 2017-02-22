using System;
using System.Collections.Generic;
using Monte;

namespace MonteTestHarness
{
    internal class TestHarness
    {
        public static void Main(string[] args)
        {
            trainSimulation();
        }

        public static void trainSimulation()
        {
            DLModel model = new DLModel(37);

            model.train(10, 1, () => { return new GOAIState(new GOState(), 1, null, 0); });
            Console.Write("Done");
        }

        public static void runSimulation()
        {
            BasicMCTS ai = new BasicMCTS (1.0, 1.4, 36);
            GameMaster game = new OrderAndChaos(ai);
            game.runGameSimulations(2);

        }
    }
}