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
            //runSimulation();
        }

        public static void trainSimulation()
        {
            DLModel model = new DLModel(10);

            model.train(100, 1000, () => { return new TTTAIState(new TTTState(), 0, null, 0); });
            Console.Write("Done");
        }

        public static void runSimulation()
        {
            BasicMCTS aiBasic = new BasicMCTS (0.25, 1.4, 10);
            DLModel model = new DLModel("TTTTest.model");
            RandomAgent aiRandom = new RandomAgent();
            //FitnessBasedAI aiFitness = new FitnessBasedAI(model);
            MCTSWithLearning aiLearnt = new MCTSWithLearning(0.25, 1.4, 10, model);
            GameMaster game = new TicTacToe(aiBasic, aiLearnt);
            game.runGameSimulations(10);
            game = new TicTacToe(aiLearnt, aiBasic);
            game.runGameSimulations(10);

          //  game = new TicTacToe(aiRandom, aiRandom);
          //  game.runGameSimulations(10);


           // game.runGameSimulations(10);
           // game = new Go(aiRandom,aiLearnt);
           // game.runGameSimulations(10);
        }
    }
}