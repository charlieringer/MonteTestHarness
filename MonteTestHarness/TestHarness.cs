
using System;

namespace MonteTestHarness
{
    internal class TestHarness
    {
        public static void Main(string[] args)
        {
            //If no arguments are passed in
            if (args.Length == 0 || args[0] == "")
            {
                //Error
                Console.WriteLine("Error: Please enter a argument, either \"Test\" or \"Train\".");
                return;
            }
            if (args.Length == 1)
            {
                if (args[0].Equals("Test")) Test.TestMain(); //If test is passed in...
                else if (args[0].Equals("Train")) Train.TrainMain(); //If train is passed in
                else
                    Console.WriteLine(
                                     "Error: arguement did not match \"Test\" or \"Train\"."); //If something else then error.
                         }
            else
            {
                //For running tests/training configured from the command line
                if (args[0].Equals("Test")) Test.TestMain(args);
                else if (args[0].Equals("Train")) Train.TrainMain(args);

            }

        }
    }
}