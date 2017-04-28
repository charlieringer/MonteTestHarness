using System;
using Monte;

public class Test
{
    public static void TestMain(string[] arguments)
    {
        if(arguments.Length != 5)
        {
            Console.WriteLine("Monte Test Harness: Fatal Error: Unable to Run Tests, not enough or too many arguements.");
            return;
        }
        Game game = null;
        if (arguments[1].Equals("TicTacToe")) game = new TicTacToe();
        else if (arguments[1].Equals("OrderAndChaos")) game = new OrderAndChaos();
        else if (arguments[1].Equals("Hex")) game = new Hex();

        Model model = new Model(arguments[2]);
        string settings = arguments[3];
        int numbGames = int.Parse(arguments[4]);

        if (game == null || model == null || settings == "")
        {
            Console.WriteLine("Monte Test Harness: Fatal Error: Unable to Run Tests, command line arguements did not match expected values.");
            return;
        }
        runTrials(game,model,settings,numbGames);
    }

    public static void TestMain()
    {
        Console.WriteLine("Starting Testing");
        runHexDevTest();

//        //Full Trials
//        Console.WriteLine("Running Trials for TicTacToe.");
//        runTrials(new TicTacToe(), new Model("ModelExamples/TicTacToe_Example.model"), "Settings/TicTacToeSettings.xml", 500);
//        Console.WriteLine("");
//        Console.WriteLine("Running Trials for Order and Chaos.");
//        runTrials(new OrderAndChaos(), new Model("ModelExamples/OrderChaos_Example.model"), "Settings/OrderAndChaosSettings.xml", 50);
//        Console.WriteLine("");
//        Console.WriteLine("Running Trials for Hex.");
//        runTrials(new Hex(), new Model("ModelExamples/Hex_Example.model"), "Settings/HexSettings.xml", 50);
//        Console.WriteLine("Done");
    }
    public static void runTrials(Game game, Model model, string settings, int games)
    {
        RandomAgent random = new RandomAgent();
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
        MCTSSimpleAgent simple = new MCTSSimpleAgent (settings);
        MCTSWithLearning learnt = new MCTSWithLearning(model, settings);
        MCTSWithPruning pruned = new MCTSWithPruning(model, settings);
        MCTSWithSoftPruning softPruned = new MCTSWithSoftPruning(model, settings);

        Console.WriteLine("Random vs Model Based");
        game.runGameSimulations(games, random, modelBased);
        game.runGameSimulations(games, modelBased, random);
        Console.WriteLine("");

        Console.WriteLine("Random vs Basic");
        game.runGameSimulations(games, random, simple);
        game.runGameSimulations(games, simple, random);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Learnt");
        game.runGameSimulations(games, simple, learnt);
        game.runGameSimulations(games, learnt, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Pruned");
        game.runGameSimulations(games, simple, pruned);
        game.runGameSimulations(games, pruned, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Soft Pruned");
        game.runGameSimulations(games, simple, softPruned);
        game.runGameSimulations(games, softPruned, simple);
        Console.WriteLine("");

    }

    public static void runHexDevTest()
    {
        Console.WriteLine("Running Hex Tests.");
        Model model = new Model("ModelExamples/Hex_Example.model");
        string settings = "Settings/HexSettings.xml";

        RandomAgent aiRandom = new RandomAgent();
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (settings);
        MCTSWithPruning aiPruning = new MCTSWithPruning(model, settings);
        MCTSWithSoftPruning aiSoftPruning = new MCTSWithSoftPruning(model, settings);
        MCTSWithLearning aiLearnt = new MCTSWithLearning(model, settings);

        Game game = new Hex();

//        Console.WriteLine("Random vs Model");
//        game.runGameSimulations(50, aiRandom, modelBased);
//        game.runGameSimulations(50, modelBased, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Random vs Basic");
//        game.runGameSimulations(50, aiRandom, aiMctsSimpleAgent);
//        game.runGameSimulations(50, aiMctsSimpleAgent, aiRandom);
//        Console.WriteLine("");

        Console.WriteLine("Learnt vs Basic");
 //       game.runGameSimulations(50, aiLearnt, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiLearnt);
        Console.WriteLine("");

        Console.WriteLine("Hard Pruning vs Basic");
        game.runGameSimulations(50, aiPruning, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiPruning);
        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.25 vs Basic");
        game.runGameSimulations(50, aiSoftPruning, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiSoftPruning);
        Console.WriteLine("");
    }
}