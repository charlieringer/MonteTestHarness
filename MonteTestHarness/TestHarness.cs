
namespace MonteTestHarness
{
    internal class TestHarness
    {
        public static void Main(string[] args)
        {
            if(args[0].Equals("Test")) Test.TestMain();
            else if (args[0].Equals("Train"))  Train.TrainMain();
        }
    }
}