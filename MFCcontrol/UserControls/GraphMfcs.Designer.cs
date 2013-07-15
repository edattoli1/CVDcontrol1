namespace MFCcontrol
{
    partial class GraphMfcs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pointsToPlotUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label18 = new System.Windows.Forms.Label();
            this.samplesToResetUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.AinGraphUpdateBox = new System.Windows.Forms.CheckBox();
            this.graphUpdateUDbox = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.resetGraphButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeElapsedBox = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsToPlotUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesToResetUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphUpdateUDbox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pointsToPlotUpDown);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.samplesToResetUpDown);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.AinGraphUpdateBox);
            this.panel3.Controls.Add(this.graphUpdateUDbox);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.resetGraphButton);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.timeElapsedBox);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(913, 319);
            this.panel3.TabIndex = 20;
            // 
            // pointsToPlotUpDown
            // 
            this.pointsToPlotUpDown.Location = new System.Drawing.Point(822, 161);
            this.pointsToPlotUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pointsToPlotUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.pointsToPlotUpDown.Name = "pointsToPlotUpDown";
            this.pointsToPlotUpDown.Size = new System.Drawing.Size(71, 22);
            this.pointsToPlotUpDown.TabIndex = 28;
            this.pointsToPlotUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pointsToPlotUpDown.ValueChanged += new System.EventHandler(this.pointsToPlotUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(688, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Points to Graph:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 7);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.BorderWidth = 4;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.BorderWidth = 4;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series6.BorderWidth = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series6";
            series7.BorderWidth = 4;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series7";
            series8.BorderWidth = 4;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Series8";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(667, 300);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(676, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(169, 20);
            this.label18.TabIndex = 25;
            this.label18.Text = "GRAPH CONTROL";
            // 
            // samplesToResetUpDown
            // 
            this.samplesToResetUpDown.Location = new System.Drawing.Point(822, 201);
            this.samplesToResetUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.samplesToResetUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.samplesToResetUpDown.Name = "samplesToResetUpDown";
            this.samplesToResetUpDown.Size = new System.Drawing.Size(73, 22);
            this.samplesToResetUpDown.TabIndex = 24;
            this.samplesToResetUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.samplesToResetUpDown.ValueChanged += new System.EventHandler(this.samplesToResetUpDown_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(676, 201);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "Samples until Reset:";
            // 
            // AinGraphUpdateBox
            // 
            this.AinGraphUpdateBox.AutoSize = true;
            this.AinGraphUpdateBox.Checked = true;
            this.AinGraphUpdateBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AinGraphUpdateBox.Location = new System.Drawing.Point(679, 115);
            this.AinGraphUpdateBox.Name = "AinGraphUpdateBox";
            this.AinGraphUpdateBox.Size = new System.Drawing.Size(120, 21);
            this.AinGraphUpdateBox.TabIndex = 22;
            this.AinGraphUpdateBox.Text = "Update Graph";
            this.AinGraphUpdateBox.UseVisualStyleBackColor = true;
            this.AinGraphUpdateBox.CheckedChanged += new System.EventHandler(this.AinGraphUpdateBox_CheckedChanged);
            // 
            // graphUpdateUDbox
            // 
            this.graphUpdateUDbox.DecimalPlaces = 1;
            this.graphUpdateUDbox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.graphUpdateUDbox.Location = new System.Drawing.Point(807, 236);
            this.graphUpdateUDbox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.graphUpdateUDbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.graphUpdateUDbox.Name = "graphUpdateUDbox";
            this.graphUpdateUDbox.Size = new System.Drawing.Size(79, 22);
            this.graphUpdateUDbox.TabIndex = 20;
            this.graphUpdateUDbox.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.graphUpdateUDbox.ValueChanged += new System.EventHandler(this.graphUpdateUD_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(682, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "Update Time (s)";
            // 
            // resetGraphButton
            // 
            this.resetGraphButton.Location = new System.Drawing.Point(680, 53);
            this.resetGraphButton.Name = "resetGraphButton";
            this.resetGraphButton.Size = new System.Drawing.Size(75, 44);
            this.resetGraphButton.TabIndex = 18;
            this.resetGraphButton.Text = "Reset Graph";
            this.resetGraphButton.UseVisualStyleBackColor = true;
            this.resetGraphButton.Click += new System.EventHandler(this.resetGraphButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(682, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time Elapsed (min):";
            // 
            // timeElapsedBox
            // 
            this.timeElapsedBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.timeElapsedBox.Enabled = false;
            this.timeElapsedBox.Location = new System.Drawing.Point(820, 271);
            this.timeElapsedBox.Name = "timeElapsedBox";
            this.timeElapsedBox.ReadOnly = true;
            this.timeElapsedBox.Size = new System.Drawing.Size(66, 22);
            this.timeElapsedBox.TabIndex = 1;
            // 
            // GraphMfcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "GraphMfcs";
            this.Size = new System.Drawing.Size(919, 325);
            this.Load += new System.EventHandler(this.GraphMfcs_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsToPlotUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samplesToResetUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphUpdateUDbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox AinGraphUpdateBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button resetGraphButton;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown samplesToResetUpDown;
        internal System.Windows.Forms.NumericUpDown graphUpdateUDbox;
        internal System.Windows.Forms.TextBox timeElapsedBox;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown pointsToPlotUpDown;
    }
}
