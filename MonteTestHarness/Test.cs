using System;
using Monte;

public class Test
{
    public static void TestMain()
    {
        Console.WriteLine("Starting Testing");
        //Quick dev tests
        //runTicTacToeDevTest();
        //runOrderAndChaosDevTest();
        runHexDevTest();

        //Full Trials
        //Console.WriteLine("Running Trials for TicTacToe.");
        //runTrials(new TicTacToe(), new Model("ModelExamples/TicTacToe_Example.model"), "Settings/TicTacToeSettings.xml");
        //Console.WriteLine("");
        //Console.WriteLine("Running Trials for Order and Chaos.");
        //runTrials(new OrderAndChaos(), new Model("ModelExamples/OrderChaos_Example.model"), "Settings/OrderAndChaosSettings.xml");
        //Console.WriteLine("");
        //Console.WriteLine("Running Trials for Hex.");
        //runTrials(new Hex(), new Model("ModelExamples/Hex_Example.model"), "Settings/HexSettings.xml");
        //Console.WriteLine("Done");
    }
    public static void runTrials(Game game, Model model, string settings)
    {
        RandomAgent random = new RandomAgent();
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
        MCTSSimpleAgent simple = new MCTSSimpleAgent (settings);
        MCTSWithLearning learnt = new MCTSWithLearning(model, settings);
        MCTSWithPruning pruned = new MCTSWithPruning(model, settings);
        MCTSWithSoftPruning softPruned = new MCTSWithSoftPruning(model, settings);

        Console.WriteLine("Random vs Model Based");
        game.runGameSimulations(50, random, modelBased);
        game.runGameSimulations(50, modelBased, random);
        Console.WriteLine("");

        Console.WriteLine("Random vs Basic");
        game.runGameSimulations(50, random, simple);
        game.runGameSimulations(50, simple, random);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Learnt");
        game.runGameSimulations(50, simple, learnt);
        game.runGameSimulations(50, learnt, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Pruned");
        game.runGameSimulations(50, simple, pruned);
        game.runGameSimulations(50, pruned, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Soft Pruned");
        game.runGameSimulations(50, simple, softPruned);
        game.runGameSimulations(50, softPruned, simple);
        Console.WriteLine("");

    }

    public static void runTicTacToeDevTest()
    {
        Console.WriteLine("Running Tic Tac Toe Tests.");
        Model model = new Model("ModelExamples/TicTacToe_Example.model");
        string settings = "Settings/TicTacToeSettings.xml";

        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (settings);
        MCTSWithPruning aiPruning = new MCTSWithPruning(model, settings);
        MCTSWithSoftPruning aiSoftPruning = new MCTSWithSoftPruning(model, settings);
        MCTSWithLearning aiLearnt = new MCTSWithLearning(model, settings);
        RandomAgent aiRandom = new RandomAgent();
        ModelBasedAgent modelBased = new ModelBasedAgent(model);

        Game game = new TicTacToe();

//        Console.WriteLine("Random vs Model");
//        game.runGameSimulations(500, aiRandom, modelBased);
//        game.runGameSimulations(500, modelBased, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Random vs Basic");
//        game.runGameSimulations(500, aiRandom, aiMctsSimpleAgent);
//        game.runGameSimulations(500, aiMctsSimpleAgent, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Learnt vs Basic");
//        game.runGameSimulations(500, aiLearnt, aiMctsSimpleAgent);
//        game.runGameSimulations(500, aiMctsSimpleAgent, aiLearnt);
//        Console.WriteLine("");

        Console.WriteLine("Hard Pruning vs Basic");
        game.runGameSimulations(500, aiPruning, aiMctsSimpleAgent);
        game.runGameSimulations(500, aiMctsSimpleAgent, aiPruning);
        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.25 vs Basic");
        game.runGameSimulations(500, aiSoftPruning, aiMctsSimpleAgent);
        game.runGameSimulations(500, aiMctsSimpleAgent, aiSoftPruning);
        Console.WriteLine("");
    }

    public static void runOrderAndChaosDevTest()
    {
        Console.WriteLine("Running Order and Chaos Dev Tests.");
        Model model = new Model("ModelExamples/OrderChaos_Example.model");
        string settings = "Settings/OrderAndChaosSettings.xml";

        RandomAgent aiRandom = new RandomAgent();
        ModelBasedAgent modelBased = new ModelBasedAgent(model);

        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent(settings);
        MCTSWithPruning aiPruning = new MCTSWithPruning(model, settings);
        MCTSWithSoftPruning aiSoftPruning = new MCTSWithSoftPruning(model, settings);
        MCTSWithLearning aiLearnt = new MCTSWithLearning(model, settings);

        Game game = new OrderAndChaos();

        Console.WriteLine("Random vs Model");
        game.runGameSimulations(50, aiRandom, modelBased);
        game.runGameSimulations(50, modelBased, aiRandom);
        Console.WriteLine("");

        Console.WriteLine("Random vs Basic");
        game.runGameSimulations(50, aiRandom, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiRandom);
        Console.WriteLine("");

        Console.WriteLine("Learnt vs Basic");
        game.runGameSimulations(50, aiLearnt, aiMctsSimpleAgent);
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

        Console.WriteLine("Random vs Model");
        game.runGameSimulations(50, aiRandom, modelBased);
        game.runGameSimulations(50, modelBased, aiRandom);
        Console.WriteLine("");

        Console.WriteLine("Random vs Basic");
        game.runGameSimulations(50, aiRandom, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiRandom);
        Console.WriteLine("");

        Console.WriteLine("Learnt vs Basic");
        game.runGameSimulations(50, aiLearnt, aiMctsSimpleAgent);
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