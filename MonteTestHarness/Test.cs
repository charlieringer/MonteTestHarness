﻿using System;
using Monte;

public class Test
{
    public static void TestMain()
    {
        Console.WriteLine("Starting Testing");
        //Quick dev tests
        runTicTacToeDevTest();
        //runOrderAndChaosDevTest();

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

        Console.WriteLine("Simple vs Learnt");
        game.runGameSimulations(500, simple, learnt);
        game.runGameSimulations(500, learnt, simple);
        Console.WriteLine("");

        Console.WriteLine("Simple vs Pruned");
        game.runGameSimulations(500, simple, pruned);
        game.runGameSimulations(500, pruned, simple);

        Console.WriteLine("Learnt vs Pruned");
        game.runGameSimulations(500, learnt, pruned);
        game.runGameSimulations(500, pruned, learnt);
        Console.WriteLine("");
    }

    public static void runTicTacToeDevTest()
    {
        Console.WriteLine("Running Tic Tac Toe Dev Tests.");
        Model model = new Model("ModelExamples/TicTacToe_Example.model");

        RandomAgent aiRandom = new RandomAgent();
        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (500, 1.4, 9, 0.5);
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
        MCTSWithPruning aiPruning = new MCTSWithPruning(500, 1.4, 9, model, 0.33, 0.5);
        MCTSWithLearning aiLearnt = new MCTSWithLearning(500, 1.4, 9, model, 0.5);

        Game game = new TicTacToe();
//
//        Console.WriteLine("Random vs Random");
//        game.runGameSimulations(500, aiRandom, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Random vs Model");
//        game.runGameSimulations(500, aiRandom, modelBased);
//        game.runGameSimulations(500, modelBased, aiRandom);
//        Console.WriteLine("");
//

//        Console.WriteLine("Basic vs Basic");
//        game.runGameSimulations(500, aiMctsSimpleAgent, aiMctsSimpleAgent);
//        game.runGameSimulations(500, aiMctsSimpleAgent, aiMctsSimpleAgent);
//        Console.WriteLine("");

        Console.WriteLine("Learnt vs Basic");
        game.runGameSimulations(500, aiLearnt, aiMctsSimpleAgent);
        game.runGameSimulations(500, aiMctsSimpleAgent, aiLearnt);
        Console.WriteLine("");

        Console.WriteLine("Pruning vs Basic");
        game.runGameSimulations(500, aiPruning, aiMctsSimpleAgent);
        game.runGameSimulations(500, aiMctsSimpleAgent, aiPruning);
        Console.WriteLine("");
    }

    public static void runOrderAndChaosDevTest()
    {
        Console.WriteLine("Running Order and Chaos Dev Tests.");
        Model model = new Model("ModelExamples/OrderChaos_Example.model");

        RandomAgent aiRandom = new RandomAgent();
        MCTSSimpleAgent aiMctsSimpleAgent = new MCTSSimpleAgent (1000, 1.4, 36, 0.5);
        ModelBasedAgent modelBased = new ModelBasedAgent(model);
        MCTSWithPruning aiPruning = new MCTSWithPruning(1000, 1.4, 36, model, 0.33, 0.5);
        MCTSWithLearning aiLearnt = new MCTSWithLearning(1000, 1.4, 36, model, 0.5);

        Game game = new OrderAndChaos();

//        Console.WriteLine("Random vs Random");
//        game.runGameSimulations(500, aiRandom, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Random vs Model");
//        game.runGameSimulations(500, aiRandom, modelBased);
//        game.runGameSimulations(500, modelBased, aiRandom);
//        Console.WriteLine("");

//        Console.WriteLine("Random vs Basic");
//        game.runGameSimulations(10, aiRandom, aiMctsSimpleAgent);
//        game.runGameSimulations(10, aiMctsSimpleAgent, aiRandom);
//        Console.WriteLine("");
//
//        Console.WriteLine("Learnt vs Basic");
//        game.runGameSimulations(20, aiLearnt, aiMctsSimpleAgent);
//        game.runGameSimulations(20, aiMctsSimpleAgent, aiLearnt);
//        Console.WriteLine("");

        Console.WriteLine("Basic vs Basic");
        game.runGameSimulations(100, aiMctsSimpleAgent, aiMctsSimpleAgent);
        game.runGameSimulations(100, aiMctsSimpleAgent, aiMctsSimpleAgent);
        Console.WriteLine("");

        Console.WriteLine("Pruning vs Basic");
        game.runGameSimulations(100, aiPruning, aiMctsSimpleAgent);
        game.runGameSimulations(100, aiMctsSimpleAgent, aiPruning);
        Console.WriteLine("");

//        Console.WriteLine("Random vs Pruning");
//        game.runGameSimulations(20, aiRandom, aiPruning);
//        game.runGameSimulations(20, aiPruning, aiRandom);
//        Console.WriteLine("");
    }
}