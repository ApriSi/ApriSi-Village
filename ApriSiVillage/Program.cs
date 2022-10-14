using System.Threading;

namespace ApriSiVillage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread simulationThread = new(Simulation.Start);
            simulationThread.Start();
        }
    }
}
