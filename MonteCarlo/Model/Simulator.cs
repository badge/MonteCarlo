using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonteCarlo.Model
{
    /// <summary>
    /// Interface for our discretization schemes
    /// </summary>
    public interface IDiscretizationScheme
    {
        string Name { get; }

        double Increment(double value);
    }

    /// <summary>
    /// Euler discretization
    /// </summary>
    public class EulerDiscretization : IDiscretizationScheme
    {
        public string Name { get { return "Euler Discretization"; } }

        public double Increment(double value)
        {
            return value                                                                                                            // Original value
                    + (SimulatedPrice.Drift * value * SimulatedPrice.Delta)                                                         // Drift term
                    + (SimulatedPrice.Volatility * value * Math.Sqrt(SimulatedPrice.Delta) * GaussianBoxMuller.NextDouble());       // Wiener process
        }
    }

    /// <summary>
    /// Milstein discretization (Euler discretization with an added correction term)
    /// </summary>
    public class MilsteinDiscretization : IDiscretizationScheme
    {
        public string Name { get { return "Milstein Discretization"; } }

        public double Increment(double value)
        {
            double rand = GaussianBoxMuller.NextDouble();
            return value                                                                                                            // Original value
                    + (SimulatedPrice.Drift * value * SimulatedPrice.Delta)                                                         // Drift term
                    + (SimulatedPrice.Volatility * value * Math.Sqrt(SimulatedPrice.Delta) * rand)                                  // Wiener process
                    + (0.5*Math.Pow(SimulatedPrice.Volatility, 2) * SimulatedPrice.Delta*(Math.Pow(rand, 2) - 1));                  // Correction term
        }
    }

    /// <summary>
    /// SimulatedPrice generates an individual simulated price curve
    /// </summary>
    public class SimulatedPrice
    {
        // Constructor
        public SimulatedPrice()
        {
            // Dimension our array and give it the first value
            this.SimulatedPriceArray = new double[SimulatedPrice.Steps];
            this.SimulatedPriceArray[0] = SimulatedPrice.SpotPrice;
        }

        public static IDiscretizationScheme DiscretizationScheme { get; set; }  // The discretization scheme we want to use
        
        public static double Volatility { get; set; }                           // Volatility (standard deviation) of the instrument
        public static double Drift { get; set; }                                // Drift (risk-free rate) of the instrument
        public static double SpotPrice { get; set; }                            // Starting price for the simulation
        public static double StrikePrice { get; set; }                          // Exercise price of the option

        public static uint Steps { get; set; }                                  // Number of steps in the simulation

        public const double Delta = 1/252.0;                                    // Volatility and interest are annual, so delta = 1/(Trading days in a year)

        public double[] SimulatedPriceArray { get; private set; }               // Simulated prices


        // Return a task that runs the simulation
        public Task RunSim()
        {
            return Task.Run(() => SimulatePrice());
        }

        // Run the simulation
        private void SimulatePrice()
        {
            for (uint i = 1; i < SimulatedPrice.Steps; i++)
            {
                SimulatedPriceArray[i] = DiscretizationScheme.Increment(SimulatedPriceArray[i - 1]);
            }
        }
    }

    /// <summary>
    /// Simulator is the model for the application
    /// </summary>
    public class Simulator
    {
        public event Action SimulationComplete;                             // Simulation Complete event

        public UInt32 nSims { get; set; }                                   // Number of simulations
        public List<SimulatedPrice> PriceSimList { get; private set; }      // List of simulated prices
        
        // Run the simulation
        public void RunSimulation()
        {
            // Create a new list of simulated prices
            PriceSimList = Enumerable.Range(0, (int)this.nSims).Select(i => new SimulatedPrice()).ToList();

            // Wait on them to run
            Task.WaitAll(PriceSimList.Select(c => c.RunSim()).ToArray());

            // Fire the simulation completed event if necessary
            if (SimulationComplete != null)
                SimulationComplete();
        }

        // Calculate the value of a European call option given the result of the simulation
        public double CallValue()
        {
            return Math.Exp(-SimulatedPrice.Drift*SimulatedPrice.Steps*SimulatedPrice.Delta) * this.PriceSimList.Select(p => Math.Max(p.SimulatedPriceArray.Last() - SimulatedPrice.StrikePrice, 0)).Average();
        }
    }

    /// <summary>
    /// The Gaussian Box Muller algorithm to generate a normally-distributed
    /// random number with mean 0 and standard deviation 1.
    /// </summary>
    internal static class GaussianBoxMuller
    {
        public static double NextDouble()
        {
            double x, y, square;

            do
            {
                x = 2 * RandomProvider.GetThreadRandom().NextDouble() - 1;
                y = 2 * RandomProvider.GetThreadRandom().NextDouble() - 1;
                square = Math.Pow(x, 2) + Math.Pow(y, 2);
            } while (square >= 1);

            return x * Math.Sqrt(-2 * Math.Log(square) / square);
        }
    }

    /// <summary>
    /// Provides a threadsafe random number, from Jon Skeet's C# in Depth:
    /// http://csharpindepth.com/Articles/Chapter12/Random.aspx
    /// </summary>
    internal static class RandomProvider
    {
        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        private static int seed = Environment.TickCount;

        public static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }
    }
}
