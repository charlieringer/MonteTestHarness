using System;
using Monte;

namespace MonteTestHarness
{
    internal class TestHarness
    {
        public static void Main(string[] args)
        {

           //trainSimulation();
           runSimulation();
           Console.Write("Done");
        }

        public static void trainSimulation()
        {
            Model model = new Model();

            //model.train(100, 1000, () => new TTTAIState());
            model.train(100, 1000, () => new OCAIState());
        }

        public static void runSimulation()
        {
            runTicTacToeGames();
            //runOrderAndChaosGames();
        }

        public static void runTicTacToeGames()
        {
            MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (0.25, 1.4, 10);
            RandomAgent aiRandom = new RandomAgent();

            Model modelA = new Model("TTTTest_1Layer.model");
            Model modelB = new Model("TTTTest_3Layers.model");

            ModelBasedAgent modelBasedAI1 = new ModelBasedAgent(modelA);
            ModelBasedAgent modelBasedAI2 = new ModelBasedAgent(modelB);

            MCTSWithLearning aiLearnt1 = new MCTSWithLearning(0.25, 1.4, 10, modelA);
            MCTSWithLearning aiLearnt2 = new MCTSWithLearning(0.25, 1.4, 10, modelB);

            MCTSWithPruning aiPruning1 = new MCTSWithPruning(0.25, 1.4, 10, modelA, 0.2);
            MCTSWithPruning aiPruning2 = new MCTSWithPruning(0.25, 1.4, 10, modelB, 0.2);

            GameMaster game = new TicTacToe();
//
//            Console.WriteLine("Random vs Model 1");
//            game.runGameSimulations(5000, aiRandom, modelBasedAI1);
//            game.runGameSimulations(5000, modelBasedAI1, aiRandom);
//
//            Console.WriteLine("Random vs Model 2");
//            game.runGameSimulations(5000, aiRandom, modelBasedAI2);
//            game.runGameSimulations(5000, modelBasedAI2, aiRandom);
//
//
//            Console.WriteLine("Model 1 vs Model 2");
//            game.runGameSimulations(5000, modelBasedAI1, modelBasedAI2);
//            game.runGameSimulations(5000, modelBasedAI2, modelBasedAI1);
//
            Console.WriteLine("Pruning 1 vs Basic");
            game.runGameSimulations(100, aiPruning1, aiMctsSimpleAgent);
            game.runGameSimulations(100, aiMctsSimpleAgent, aiPruning1);

            Console.WriteLine("Pruning 2 vs Basic");
            game.runGameSimulations(100, aiPruning2, aiMctsSimpleAgent);
            game.runGameSimulations(100, aiMctsSimpleAgent, aiPruning2);

//            Console.WriteLine("Pruning 1 vs Pruning 2");
//            game.runGameSimulations(100, aiPruning1, aiPruning2);
//            game.runGameSimulations(100, aiPruning2, aiPruning1);

        }

        public static void runOrderAndChaosGames()
        {
            MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (0.25, 1.4, 10);
            RandomAgent aiRandom = new RandomAgent();

            Model modelA = new Model("OCTest_3Layers.model");
            Model modelB = new Model("OCTest_3Layers.model");

            ModelBasedAgent modelBasedAI1 = new ModelBasedAgent(modelA);
            ModelBasedAgent modelBasedAI2 = new ModelBasedAgent(modelB);

            MCTSWithLearning aiLearnt1 = new MCTSWithLearning(0.5, 1.4, 10, modelA);
            MCTSWithLearning aiLearnt2 = new MCTSWithLearning(0.5, 1.4, 10, modelB);

            MCTSWithPruning aiPruning1 = new MCTSWithPruning(0.5, 1.4, 10, modelA, 0.2);
            MCTSWithPruning aiPruning2 = new MCTSWithPruning(0.5, 1.4, 10, modelB, 0.2);

            GameMaster game = new OrderAndChaos();

            Console.WriteLine("Random vs Model 1");
            game.runGameSimulations(200, aiRandom, modelBasedAI1);
            game.runGameSimulations(200, modelBasedAI1, aiRandom);
//
//            Console.WriteLine("Random vs Model 2");
//            game.runGameSimulations(5000, aiRandom, modelBasedAI2);
//            game.runGameSimulations(5000, modelBasedAI2, aiRandom);
//
//
//            Console.WriteLine("Model 1 vs Model 2");
//            game.runGameSimulations(5000, modelBasedAI1, modelBasedAI2);
//            game.runGameSimulations(5000, modelBasedAI2, modelBasedAI1);
//
            Console.WriteLine("Pruning 1 vs Basic");
            game.runGameSimulations(10, aiPruning1, aiMctsSimpleAgent);
            game.runGameSimulations(10, aiMctsSimpleAgent, aiPruning1);
//
//            Console.WriteLine("Pruning 2 vs Basic");
//            game.runGameSimulations(100, aiPruning2, aiMctsSimpleAgent);
//            game.runGameSimulations(100, aiMctsSimpleAgent, aiPruning2);

//            Console.WriteLine("Pruning 1 vs Pruning 2");
//            game.runGameSimulations(100, aiPruning1, aiPruning2);
//            game.runGameSimulations(100, aiPruning2, aiPruning1);

        }
    }
}