
using System;

namespace MonteTestHarness
{
    internal class TestHarness
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "")
            {
                Console.WriteLine("Error: Please enter a argument, either \"Test\" or \"Train\".");
                return;
            }
            if(args[0].Equals("Test")) Test.TestMain();
            else if (args[0].Equals("Train"))  Train.TrainMain();
        }
    }
}