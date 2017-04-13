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
        //runTrials(new TicTacToe(), new Model("TicTacToe_Example.model"), "Settings/TicTacToeSettings.xml");
        //runTrials(new OrderAndChaos(), new Model("OrderAndChaos_Example.model"), "Settings/OrderAndChaosSettings.xml");
        Console.WriteLine("Done");
    }
    public static void runTrials(Game game, Model model, string settings)
    {
        Console.WriteLine("Running Trials.");
        RandomAgent random = new RandomAgent();
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
        MCTSSimpleAgent simple = new MCTSSimpleAgent (settings);
        MCTSWithLearning learnt = new MCTSWithLearning(model, settings);
        MCTSWithPruning pruned = new MCTSWithPruning(model, settings);
        MCTSWithSoftPruning softPruned = new MCTSWithSoftPruning(model, settings);
        Console.WriteLine("");

        Console.WriteLine("Random vs Model Based");
        game.runGameSimulations(500, random, modelBased);
        game.runGameSimulations(500, modelBased, random);
        Console.WriteLine("");

        Console.WriteLine("Random vs Basic");
        game.runGameSimulations(500, random, simple);
        game.runGameSimulations(500, simple, random);
        Console.WriteLine("");

        Console.WriteLine("Random vs Learnt");
        game.runGameSimulations(500, random, learnt);
        game.runGameSimulations(500, learnt, random);
        Console.WriteLine("");

        Console.WriteLine("Random vs Pruned");
        game.runGameSimulations(500, random, pruned);
        game.runGameSimulations(500, pruned, random);
        Console.WriteLine("");

        Console.WriteLine("Random vs Soft Pruned");
        game.runGameSimulations(500, random, softPruned);
        game.runGameSimulations(500, softPruned, random);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Learnt");
        game.runGameSimulations(500, simple, learnt);
        game.runGameSimulations(500, learnt, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Pruned");
        game.runGameSimulations(500, simple, pruned);
        game.runGameSimulations(500, pruned, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Soft Pruned");
        game.runGameSimulations(500, simple, softPruned);
        game.runGameSimulations(500, softPruned, simple);
        Console.WriteLine("");

    }

    public static void runTicTacToeDevTest()
    {
        int itters = 100;
        double utcConst = 1.4;
        int maxRollout = 9;
        double drawScore = 0.5;

        Console.WriteLine("Running Tic Tac Toe Dev Tests.");
        Model model = new Model("ModelExamples/TicTacToe_Example.model");

        RandomAgent aiRandom = new RandomAgent();
        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (itters, utcConst, maxRollout, drawScore);
        ModelBasedAgent modelBased = new ModelBasedAgent(model);

        //MCTSWithPruning aiPruning1 = new MCTSWithPruning(itters, utcConst, maxRollout, model, 0.1, drawScore);
        MCTSWithPruning aiPruning2 = new MCTSWithPruning(itters, utcConst, maxRollout, model, 0.25, drawScore);
        //MCTSWithPruning aiPruning3 = new MCTSWithPruning(itters, utcConst, maxRollout, model, 0.5, drawScore);

        MCTSWithSoftPruning aiSoftPruning1 = new MCTSWithSoftPruning(itters, utcConst, maxRollout, model, 0.10, drawScore);
        MCTSWithSoftPruning aiSoftPruning2 = new MCTSWithSoftPruning(itters, utcConst, maxRollout, model, 0.25, drawScore);
        MCTSWithSoftPruning aiSoftPruning3 = new MCTSWithSoftPruning(itters, utcConst, maxRollout, model, 1.0, drawScore);

        MCTSWithLearning aiLearnt = new MCTSWithLearning(itters, utcConst, maxRollout, model, drawScore);

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

//        Console.WriteLine("Learnt vs Basic");
//        game.runGameSimulations(500, aiLearnt, aiMctsSimpleAgent);
//        game.runGameSimulations(500, aiMctsSimpleAgent, aiLearnt);
//        Console.WriteLine("");

//        Console.WriteLine("Hard Pruning 0.225 vs Basic");
//        game.runGameSimulations(5000, aiPruning1, aiMctsSimpleAgent);
//        game.runGameSimulations(5000, aiMctsSimpleAgent, aiPruning1);
//        Console.WriteLine("");

        Console.WriteLine("Hard Pruning 0.25 vs Basic");
        game.runGameSimulations(5000, aiPruning2, aiMctsSimpleAgent);
        game.runGameSimulations(5000, aiMctsSimpleAgent, aiPruning2);
        Console.WriteLine("");

//        Console.WriteLine("Hard Pruning 0.275 vs Basic");
//        game.runGameSimulations(5000, aiPruning3, aiMctsSimpleAgent);
//        game.runGameSimulations(5000, aiMctsSimpleAgent, aiPruning3);
//        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.20 vs Basic");
        game.runGameSimulations(5000, aiSoftPruning1, aiMctsSimpleAgent);
        game.runGameSimulations(5000, aiMctsSimpleAgent, aiSoftPruning1);
        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.25 vs Basic");
        game.runGameSimulations(5000, aiSoftPruning2, aiMctsSimpleAgent);
        game.runGameSimulations(5000, aiMctsSimpleAgent, aiSoftPruning2);
        Console.WriteLine("");
//
        Console.WriteLine("Soft Pruning 0.30 vs Basic");
        game.runGameSimulations(5000, aiSoftPruning3, aiMctsSimpleAgent);
        game.runGameSimulations(5000, aiMctsSimpleAgent, aiSoftPruning3);
        Console.WriteLine("");
    }

    public static void runOrderAndChaosDevTest()
    {
        int itters = 500;
        double utcConst = 1.4;
        int maxRollout = 36;
        double drawScore = 0.5;

        Console.WriteLine("Running Order and Chaos Dev Tests.");
        Model model = new Model("ModelExamples/OrderChaos_Example.model");

        RandomAgent aiRandom = new RandomAgent();
        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (itters, utcConst, maxRollout, drawScore);
        ModelBasedAgent modelBased = new ModelBasedAgent(model);

        MCTSWithPruning aiPruning1 = new MCTSWithPruning(itters, utcConst, maxRollout, model, 0.15, drawScore);
        MCTSWithPruning aiPruning2 = new MCTSWithPruning(itters, utcConst, maxRollout, model, 0.20, drawScore);
        MCTSWithPruning aiPruning3 = new MCTSWithPruning(itters, utcConst, maxRollout, model, 0.25, drawScore);

        MCTSWithSoftPruning aiSoftPruning1 = new MCTSWithSoftPruning(itters, utcConst, maxRollout, model, 0.25, drawScore);
        MCTSWithSoftPruning aiSoftPruning2 = new MCTSWithSoftPruning(itters, utcConst, maxRollout, model, 0.50, drawScore);
        MCTSWithSoftPruning aiSoftPruning3 = new MCTSWithSoftPruning(itters, utcConst, maxRollout, model, 0.75, drawScore);

        MCTSWithLearning aiLearnt = new MCTSWithLearning(itters, utcConst, maxRollout, model, drawScore);

        Game game = new OrderAndChaos();

//        Console.WriteLine("Random vs Model");
//        game.runGameSimulations(500, aiRandom, modelBased);
//        game.runGameSimulations(500, modelBased, aiRandom);
//        Console.WriteLine("");

        Console.WriteLine("Random vs Basic");
        game.runGameSimulations(50, aiRandom, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiRandom);
        Console.WriteLine("");

        Console.WriteLine("Hard Pruning 0.15 vs Basic");
        game.runGameSimulations(50, aiPruning1, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiPruning1);
        Console.WriteLine("");

        Console.WriteLine("Hard Pruning 0.20 vs Basic");
        game.runGameSimulations(50, aiPruning2, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiPruning2);
        Console.WriteLine("");

        Console.WriteLine("Hard Pruning 0.25 vs Basic");
        game.runGameSimulations(50, aiPruning3, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiPruning3);
        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.25 vs Basic");
        game.runGameSimulations(50, aiSoftPruning1, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiSoftPruning1);
        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.50 vs Basic");
        game.runGameSimulations(50, aiSoftPruning2, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiSoftPruning2);
        Console.WriteLine("");

        Console.WriteLine("Soft Pruning 0.75 vs Basic");
        game.runGameSimulations(50, aiSoftPruning3, aiMctsSimpleAgent);
        game.runGameSimulations(50, aiMctsSimpleAgent, aiSoftPruning3);
        Console.WriteLine("");

//        Console.WriteLine("Learnt vs Basic");
//        game.runGameSimulations(20, aiLearnt, aiMctsSimpleAgent);
//        game.runGameSimulations(20, aiMctsSimpleAgent, aiLearnt);
//        Console.WriteLine("");


//        Console.WriteLine("Random vs Pruning");
//        game.runGameSimulations(20, aiRandom, aiPruning);
//        game.runGameSimulations(20, aiPruning, aiRandom);
//        Console.WriteLine("");
    }

    public static void runHexDevTest()
    {
        Console.WriteLine("Running Hex Dev Tests.");
        Model model = new Model("ModelExamples/Hex_Example.model");

        RandomAgent aiRandom = new RandomAgent();
        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (500, 1.4, 81, 0);
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
//        MCTSWithPruning aiPruning = new MCTSWithPruning(2000, 1.4, 36, model, 0.33, 0.5);
//        MCTSWithLearning aiLearnt = new MCTSWithLearning(2000, 1.4, 36, model, 0.5);

        Game game = new Hex();

//        Console.WriteLine("Random vs Random");
//        game.runGameSimulations(500, aiRandom, aiRandom);
//        Console.WriteLine("");
//
        Console.WriteLine("Random vs Model");
        game.runGameSimulations(50, aiRandom, modelBased);
        game.runGameSimulations(50, modelBased, aiRandom);
        Console.WriteLine("");
//
//        Console.WriteLine("Random vs Basic");
//        game.runGameSimulations(10, aiRandom, aiMctsSimpleAgent);
//        game.runGameSimulations(10, aiMctsSimpleAgent, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Learnt vs Basic");
//        game.runGameSimulations(20, aiLearnt, aiMctsSimpleAgent);
//        game.runGameSimulations(20, aiMctsSimpleAgent, aiLearnt);
//        Console.WriteLine("");

//        Console.WriteLine("Basic vs Basic");
//        game.runGameSimulations(100, aiMctsSimpleAgent, aiMctsSimpleAgent);
//        game.runGameSimulations(100, aiMctsSimpleAgent, aiMctsSimpleAgent);
//        Console.WriteLine("");

//        Console.WriteLine("Pruning vs Basic");
//        game.runGameSimulations(50, aiPruning, aiMctsSimpleAgent);
//        game.runGameSimulations(50, aiMctsSimpleAgent, aiPruning);
//        Console.WriteLine("");

//        Console.WriteLine("Random vs Pruning");
//        game.runGameSimulations(20, aiRandom, aiPruning);
//        game.runGameSimulations(20, aiPruning, aiRandom);
//        Console.WriteLine("");
    }
}