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
            DLModel model = new DLModel();

            model.train(1000, 10000, () => { return new TTTAIState(); });
            Console.Write("Done");
        }

        public static void runSimulation()
        {
            BasicMCTS aiBasic = new BasicMCTS (0.25, 1.4, 10);
            DLModel model = new DLModel("TTTTest.model");
            RandomAgent aiRandom = new RandomAgent();
            FitnessBasedAI aiFitness = new FitnessBasedAI(model);
            MCTSWithLearning aiLearnt = new MCTSWithLearning(0.25, 1.4, 10, model);
            GameMaster game = new TicTacToe();
            game = new TicTacToe();
            //game.runGameSimulations(10, aiRandom, aiLearnt);
            //game.runGameSimulations(10, aiLearnt, aiRandom);
            game.runGameSimulations(30, aiLearnt, aiBasic);
            game.runGameSimulations(30, aiBasic, aiLearnt);
            //game.runGameSimulations(2000, aiRandom, aiRandom);
        }
    }
}