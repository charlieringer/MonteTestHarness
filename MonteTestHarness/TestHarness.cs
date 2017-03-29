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
            Learner model = new Learner();

            model.train(100, 1000, () => new TTTAIState());
            Console.Write("Done");
        }

        public static void runSimulation()
        {
            MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (0.5, 1.4, 10);
            Learner model = new Learner("TTTTest_Best.model");
            RandomAgent aiRandom = new RandomAgent();
            ModelBased modelBasedAI = new ModelBased(model);
            ModelBased modelBasedAI1 = new ModelBased(new Learner("TTTTest_New.model"));
            MCTSWithLearning aiLearnt = new MCTSWithLearning(0.5, 1.4, 10, model);
            MCTSWithPruning aiPruning = new MCTSWithPruning(0.25, 1.4, 10, model, 0.2);
            //MCTSWithPruning aiPruning2 = new MCTSWithPruning(0.25, 1.4, 10, new Learner("TTTTest_Rand.model"), 0.2);
            GameMaster game = new TicTacToe();
            game = new TicTacToe();
            Console.WriteLine("Random vs Model 1");
            game.runGameSimulations(50000, aiRandom, modelBasedAI);
            game.runGameSimulations(50000, modelBasedAI, aiRandom);
            Console.WriteLine("Random vs Model 2");
            game.runGameSimulations(50000, aiRandom, modelBasedAI1);
            game.runGameSimulations(50000, modelBasedAI1, aiRandom);

            //game.runGameSimulations(50, aiPruning, aiMctsSimpleAgent);
            //game.runGameSimulations(50, aiMctsSimpleAgent, aiPruning);
            Console.WriteLine("Model 1 vs Model 2");
            game.runGameSimulations(50000, modelBasedAI, modelBasedAI1);
            game.runGameSimulations(50000, modelBasedAI1, modelBasedAI);

            //game.runGameSimulations(50, aiPruning, aiPruning2);
            //game.runGameSimulations(50, aiPruning2, aiPruning);
        }
    }
}