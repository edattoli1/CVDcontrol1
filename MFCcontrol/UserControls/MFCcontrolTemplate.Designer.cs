namespace MFCcontrol
{
    partial class MFCcontrolTemplate
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mfc1PresFlowBox = new System.Windows.Forms.TextBox();
            this.mfc1TextBox = new System.Windows.Forms.NumericUpDown();
            this.mfc1maxLabel = new System.Windows.Forms.Label();
            this.mfc1GasName = new System.Windows.Forms.Label();
            this.mfc1Display = new System.Windows.Forms.Label();
            this.mfc1CheckBox = new System.Windows.Forms.CheckBox();
            this.mfc1PlotCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mfc1TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mfc1PresFlowBox, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.mfc1TextBox, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.mfc1maxLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.mfc1GasName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mfc1Display, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mfc1CheckBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.mfc1PlotCheck, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 31);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // mfc1PresFlowBox
            // 
            this.mfc1PresFlowBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mfc1PresFlowBox.Enabled = false;
            this.mfc1PresFlowBox.Location = new System.Drawing.Point(373, 5);
            this.mfc1PresFlowBox.Margin = new System.Windows.Forms.Padding(5);
            this.mfc1PresFlowBox.Name = "mfc1PresFlowBox";
            this.mfc1PresFlowBox.Size = new System.Drawing.Size(45, 22);
            this.mfc1PresFlowBox.TabIndex = 30;
            // 
            // mfc1TextBox
            // 
            this.mfc1TextBox.DecimalPlaces = 2;
            this.mfc1TextBox.Enabled = false;
            this.mfc1TextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mfc1TextBox.Location = new System.Drawing.Point(296, 5);
            this.mfc1TextBox.Margin = new System.Windows.Forms.Padding(5);
            this.mfc1TextBox.Name = "mfc1TextBox";
            this.mfc1TextBox.Size = new System.Drawing.Size(54, 22);
            this.mfc1TextBox.TabIndex = 16;
            this.mfc1TextBox.ValueChanged += new System.EventHandler(this.mfc1TextBox_ValueChanged);
            // 
            // mfc1maxLabel
            // 
            this.mfc1maxLabel.AutoSize = true;
            this.mfc1maxLabel.Location = new System.Drawing.Point(227, 5);
            this.mfc1maxLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mfc1maxLabel.Name = "mfc1maxLabel";
            this.mfc1maxLabel.Size = new System.Drawing.Size(32, 17);
            this.mfc1maxLabel.TabIndex = 20;
            this.mfc1maxLabel.Text = "100";
            // 
            // mfc1GasName
            // 
            this.mfc1GasName.AutoSize = true;
            this.mfc1GasName.Location = new System.Drawing.Point(50, 5);
            this.mfc1GasName.Margin = new System.Windows.Forms.Padding(5);
            this.mfc1GasName.Name = "mfc1GasName";
            this.mfc1GasName.Size = new System.Drawing.Size(34, 17);
            this.mfc1GasName.TabIndex = 23;
            this.mfc1GasName.Text = "Gas";
            // 
            // mfc1Display
            // 
            this.mfc1Display.AutoSize = true;
            this.mfc1Display.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.mfc1Display.Location = new System.Drawing.Point(5, 5);
            this.mfc1Display.Margin = new System.Windows.Forms.Padding(5);
            this.mfc1Display.Name = "mfc1Display";
            this.mfc1Display.Size = new System.Drawing.Size(16, 17);
            this.mfc1Display.TabIndex = 10;
            this.mfc1Display.Text = "1";
            // 
            // mfc1CheckBox
            // 
            this.mfc1CheckBox.AutoSize = true;
            this.mfc1CheckBox.Location = new System.Drawing.Point(159, 8);
            this.mfc1CheckBox.Margin = new System.Windows.Forms.Padding(8);
            this.mfc1CheckBox.Name = "mfc1CheckBox";
            this.mfc1CheckBox.Size = new System.Drawing.Size(18, 17);
            this.mfc1CheckBox.TabIndex = 15;
            this.mfc1CheckBox.UseVisualStyleBackColor = true;
            this.mfc1CheckBox.CheckedChanged += new System.EventHandler(this.mfc1CheckBox_CheckedChanged);
            // 
            // mfc1PlotCheck
            // 
            this.mfc1PlotCheck.AutoSize = true;
            this.mfc1PlotCheck.Checked = true;
            this.mfc1PlotCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mfc1PlotCheck.Location = new System.Drawing.Point(456, 8);
            this.mfc1PlotCheck.Margin = new System.Windows.Forms.Padding(8);
            this.mfc1PlotCheck.Name = "mfc1PlotCheck";
            this.mfc1PlotCheck.Size = new System.Drawing.Size(18, 17);
            this.mfc1PlotCheck.TabIndex = 27;
            this.mfc1PlotCheck.UseVisualStyleBackColor = true;
            this.mfc1PlotCheck.CheckedChanged += new System.EventHandler(this.mfc1PlotCheck_CheckedChanged);
            // 
            // MFCcontrolTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MFCcontrolTemplate";
            this.Size = new System.Drawing.Size(498, 37);
            this.Load += new System.EventHandler(this.MFCcontrolTemplate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mfc1TextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox mfc1PresFlowBox;
        private System.Windows.Forms.Label mfc1maxLabel;
        private System.Windows.Forms.Label mfc1GasName;
        private System.Windows.Forms.Label mfc1Display;
        private System.Windows.Forms.CheckBox mfc1CheckBox;
        private System.Windows.Forms.CheckBox mfc1PlotCheck;
        internal System.Windows.Forms.NumericUpDown mfc1TextBox;

    }
}
