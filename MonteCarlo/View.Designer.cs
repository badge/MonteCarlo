namespace MonteCarlo
{
    partial class View
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chSimPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRun = new System.Windows.Forms.Button();
            this.chHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSigma = new System.Windows.Forms.Label();
            this.tbSigma = new System.Windows.Forms.TextBox();
            this.tbMu = new System.Windows.Forms.TextBox();
            this.lblMu = new System.Windows.Forms.Label();
            this.tbStockPrice = new System.Windows.Forms.TextBox();
            this.tbStrikePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDaysToExpiry = new System.Windows.Forms.TextBox();
            this.tbSimCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDiscretizationScheme = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chSimPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // chSimPrice
            // 
            this.chSimPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.LabelStyle.Format = "0";
            chartArea1.Name = "ChartArea1";
            this.chSimPrice.ChartAreas.Add(chartArea1);
            this.chSimPrice.Location = new System.Drawing.Point(12, 105);
            this.chSimPrice.Name = "chSimPrice";
            this.chSimPrice.Size = new System.Drawing.Size(740, 371);
            this.chSimPrice.TabIndex = 1;
            this.chSimPrice.Text = "Simulated Price Chart";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(127, 31);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run Simulations";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chHistogram
            // 
            this.chHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea2.AxisX.LabelStyle.Format = "0";
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea2.AxisY.LabelStyle.Format = "0";
            chartArea2.Name = "ChartArea1";
            this.chHistogram.ChartAreas.Add(chartArea2);
            this.chHistogram.Location = new System.Drawing.Point(758, 105);
            this.chHistogram.Name = "chHistogram";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Name = "Series1";
            this.chHistogram.Series.Add(series1);
            this.chHistogram.Size = new System.Drawing.Size(228, 371);
            this.chHistogram.TabIndex = 3;
            this.chHistogram.Text = "chart1";
            // 
            // lblSigma
            // 
            this.lblSigma.AutoSize = true;
            this.lblSigma.Location = new System.Drawing.Point(178, 15);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(14, 13);
            this.lblSigma.TabIndex = 0;
            this.lblSigma.Text = "σ";
            // 
            // tbSigma
            // 
            this.tbSigma.Location = new System.Drawing.Point(197, 12);
            this.tbSigma.Name = "tbSigma";
            this.tbSigma.Size = new System.Drawing.Size(48, 20);
            this.tbSigma.TabIndex = 1;
            this.tbSigma.Text = "0.1";
            this.tbSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSigma.TextChanged += new System.EventHandler(this.tbSigma_TextChanged);
            // 
            // tbMu
            // 
            this.tbMu.Location = new System.Drawing.Point(197, 38);
            this.tbMu.Name = "tbMu";
            this.tbMu.Size = new System.Drawing.Size(48, 20);
            this.tbMu.TabIndex = 1;
            this.tbMu.Text = "0.1";
            this.tbMu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMu.TextChanged += new System.EventHandler(this.tbMu_TextChanged);
            // 
            // lblMu
            // 
            this.lblMu.AutoSize = true;
            this.lblMu.Location = new System.Drawing.Point(178, 41);
            this.lblMu.Name = "lblMu";
            this.lblMu.Size = new System.Drawing.Size(13, 13);
            this.lblMu.TabIndex = 0;
            this.lblMu.Text = "μ";
            // 
            // tbStockPrice
            // 
            this.tbStockPrice.Location = new System.Drawing.Point(331, 11);
            this.tbStockPrice.Name = "tbStockPrice";
            this.tbStockPrice.Size = new System.Drawing.Size(48, 20);
            this.tbStockPrice.TabIndex = 1;
            this.tbStockPrice.Text = "50";
            this.tbStockPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbStockPrice.TextChanged += new System.EventHandler(this.tbStockPrice_TextChanged);
            // 
            // tbStrikePrice
            // 
            this.tbStrikePrice.Location = new System.Drawing.Point(331, 37);
            this.tbStrikePrice.Name = "tbStrikePrice";
            this.tbStrikePrice.Size = new System.Drawing.Size(48, 20);
            this.tbStrikePrice.TabIndex = 1;
            this.tbStrikePrice.Text = "55";
            this.tbStrikePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbStrikePrice.TextChanged += new System.EventHandler(this.tbStrikePrice_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Stock Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Strike Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Days To Expiry";
            // 
            // tbDaysToExpiry
            // 
            this.tbDaysToExpiry.Location = new System.Drawing.Point(504, 8);
            this.tbDaysToExpiry.Name = "tbDaysToExpiry";
            this.tbDaysToExpiry.Size = new System.Drawing.Size(48, 20);
            this.tbDaysToExpiry.TabIndex = 5;
            this.tbDaysToExpiry.Text = "63";
            this.tbDaysToExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDaysToExpiry.TextChanged += new System.EventHandler(this.tbDaysToExpiry_TextChanged);
            // 
            // tbSimCount
            // 
            this.tbSimCount.Location = new System.Drawing.Point(504, 34);
            this.tbSimCount.Name = "tbSimCount";
            this.tbSimCount.Size = new System.Drawing.Size(48, 20);
            this.tbSimCount.TabIndex = 5;
            this.tbSimCount.Text = "10000";
            this.tbSimCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSimCount.TextChanged += new System.EventHandler(this.tbSimCount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Simulation Count";
            // 
            // cbDiscretizationScheme
            // 
            this.cbDiscretizationScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscretizationScheme.FormattingEnabled = true;
            this.cbDiscretizationScheme.Location = new System.Drawing.Point(833, 12);
            this.cbDiscretizationScheme.Name = "cbDiscretizationScheme";
            this.cbDiscretizationScheme.Size = new System.Drawing.Size(153, 21);
            this.cbDiscretizationScheme.TabIndex = 6;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 488);
            this.Controls.Add(this.cbDiscretizationScheme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSimCount);
            this.Controls.Add(this.tbDaysToExpiry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSigma);
            this.Controls.Add(this.tbStrikePrice);
            this.Controls.Add(this.tbStockPrice);
            this.Controls.Add(this.tbMu);
            this.Controls.Add(this.tbSigma);
            this.Controls.Add(this.chHistogram);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chSimPrice);
            this.Name = "View";
            this.Text = "Monte Carlo Option Price Model";
            ((System.ComponentModel.ISupportInitialize)(this.chSimPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chSimPrice;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chHistogram;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.TextBox tbSigma;
        private System.Windows.Forms.TextBox tbMu;
        private System.Windows.Forms.Label lblMu;
        private System.Windows.Forms.TextBox tbStockPrice;
        private System.Windows.Forms.TextBox tbStrikePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDaysToExpiry;
        private System.Windows.Forms.TextBox tbSimCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDiscretizationScheme;
    }
}

