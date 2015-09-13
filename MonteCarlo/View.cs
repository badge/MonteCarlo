using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MonteCarlo
{
    public partial class View : Form
    {
        public double Mu { get; private set; }
        public double Sigma { get; private set; }
        public double StockPrice { get; private set; }
        public double StrikePrice { get; private set; }
        public uint DaysToExpiry { get; private set; }
        public UInt32 SimCount { get; private set; }

        public View()
        {
            InitializeComponent();

            // Set initial values
            this.StockPrice = Convert.ToDouble(tbStockPrice.Text);
            this.StrikePrice = Convert.ToDouble(tbStrikePrice.Text);
            this.Mu = Convert.ToDouble(tbMu.Text);
            this.Sigma = Convert.ToDouble(tbSigma.Text);
            this.DaysToExpiry = Convert.ToUInt16(tbDaysToExpiry.Text);
            this.SimCount = Convert.ToUInt32(tbSimCount.Text);
        }

        public event Action RunSimulation;

        public Chart SimChart { get { return this.chSimPrice; } }

        public Chart Histogram { get { return this.chHistogram; } }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (RunSimulation != null)
                RunSimulation();
        }

        private void tbSigma_TextChanged(object sender, EventArgs e)
        {
            CheckSetEntry((TextBox)sender, "Sigma", true);
        }

        private void tbMu_TextChanged(object sender, EventArgs e)
        {
            CheckSetEntry((TextBox)sender, "Mu", true, true);
        }

        private void tbStockPrice_TextChanged(object sender, EventArgs e)
        {
            CheckSetEntry((TextBox)sender, "StockPrice", false);
        }

        private void tbStrikePrice_TextChanged(object sender, EventArgs e)
        {
            CheckSetEntry((TextBox)sender, "StrikePrice", false);
        }

        // Check the setting of a given double property
        private void CheckSetEntry(TextBox tb, string PropertyName, bool CanBeZero, bool CanBeNegative = false)
        {
            double value = 0;
            try
            {
                value = Convert.ToDouble(tb.Text);
            }
            catch (FormatException except)
            {
                MessageBox.Show(except.Message);
            }

            if ((value > 0 || CanBeNegative) || (value == 0 && CanBeZero))
            {
                Type t = this.GetType();
                t.GetProperty(PropertyName).SetValue(this, value, null);
            }
            else
            {
                MessageBox.Show("Not a valid entry");
            }

        }

        private void tbDaysToExpiry_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.DaysToExpiry = Convert.ToUInt16(tbDaysToExpiry.Text);
            }
            catch (FormatException except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void tbSimCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.SimCount = Convert.ToUInt32(tbSimCount.Text);
            }
            catch (FormatException except)
            {
                MessageBox.Show(except.Message);
            }
        }
    }
}
