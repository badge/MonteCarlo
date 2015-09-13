using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonteCarlo.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace MonteCarlo
{
    public class Presenter
    {
        private Simulator _simulator;
        private View _view;

        public View View { get { return this._view; } }

        // Constructor
        public Presenter(Simulator Simulator, View View)
        {
            // Set up the simulator and view
            this._simulator = Simulator;
            this._view = View;

            // Link events to appropriate methods
            this._view.RunSimulation += this.RunSimulation;
            this._simulator.SimulationComplete += SetCharts;
        }

        // Run the simulation
        private void RunSimulation()
        {
            SimulatedPrice.DiscretizationScheme = this._view.CurrentDiscretizationScheme;
            SimulatedPrice.Drift = this._view.Mu;
            SimulatedPrice.Volatility = this._view.Sigma;
            SimulatedPrice.SpotPrice = this._view.StockPrice;
            SimulatedPrice.StrikePrice = this._view.StrikePrice;
            SimulatedPrice.Steps = this._view.DaysToExpiry;
            this._simulator.nSims = this._view.SimCount;
            this._simulator.RunSimulation();
        }

        // Reset the charts after a simulation
        private void SetCharts()
        {
            // Clear the existing series from the charts
            this._view.SimChart.Series.Clear();
            this._view.Histogram.Series.Clear();

            // Create the series for the simulation chart (just the top 200)
            foreach (SimulatedPrice p in _simulator.PriceSimList.Take(200))
            {
                Series s = new Series()
                {
                    XAxisType = AxisType.Primary,
                    YAxisType = AxisType.Primary,
                    ChartType = SeriesChartType.FastLine
                };

                for (int i = 0; i < p.SimulatedPriceArray.Length; i++)
                {
                    s.Points.Add(new DataPoint(i, p.SimulatedPriceArray[i]));
                }

                this._view.SimChart.Series.Add(s);
            }

            // Recalculate the scale
            this._view.SimChart.ChartAreas[0].RecalculateAxesScale();

            // Set up the histogram
            Series histSeries = new Series()
            {
                XAxisType = AxisType.Primary,
                YAxisType = AxisType.Primary,
                ChartType = SeriesChartType.Bar
            };

            int binCount = 50;

            double[] finalPrices = _simulator.PriceSimList.Select(p => p.SimulatedPriceArray.Last()).ToArray();
            double min = finalPrices.Min();

            double binWidth = (finalPrices.Max() - min) / (binCount - 1);

            double[,] histArray = new double[binCount, 2];

            // Create the x values for the histogram,
            for (int i = 0; i < binCount; i++)
                histArray[i, 0] = min + (i * binWidth);

            // The count of prices,
            for (int i = 0; i < finalPrices.Length; i++)
                histArray[(int)((finalPrices[i] - min) / binWidth), 1]++;

            // And the points for the chart
            for (int i = 0; i < binCount; i++)
                histSeries.Points.Add(new DataPoint(histArray[i, 0], histArray[i, 1]));

            this._view.Histogram.Series.Add(histSeries);
            this._view.Histogram.ChartAreas[0].RecalculateAxesScale();
            //this._view.Histogram.ChartAreas[0].AxisY.Minimum = this._view.SimChart.ChartAreas[0].AxisY.Minimum;
            //this._view.Histogram.ChartAreas[0].AxisX.Minimum = this._view.SimChart.ChartAreas[0].AxisX.Minimum;

            MessageBox.Show("Call premium is " + this._simulator.CallValue().ToString("C"));
        }
    }
}
