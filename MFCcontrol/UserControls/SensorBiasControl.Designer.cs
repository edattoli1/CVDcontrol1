namespace MFCcontrol
{
    partial class SensorBiasControl
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.configBiasOutputButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.VdsUpDown = new System.Windows.Forms.NumericUpDown();
            this.VgsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.vdsLockCheckBox = new System.Windows.Forms.CheckBox();
            this.vgsLockCheckBox = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.vdsPresValTextBox = new System.Windows.Forms.TextBox();
            this.vgsPresValTextBox = new System.Windows.Forms.TextBox();
            this.biasOutsBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VdsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VgsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.configBiasOutputButton);
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Controls.Add(this.biasOutsBox);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(379, 145);
            this.panel4.TabIndex = 25;
            // 
            // configBiasOutputButton
            // 
            this.configBiasOutputButton.Location = new System.Drawing.Point(14, 89);
            this.configBiasOutputButton.Name = "configBiasOutputButton";
            this.configBiasOutputButton.Size = new System.Drawing.Size(93, 30);
            this.configBiasOutputButton.TabIndex = 28;
            this.configBiasOutputButton.Text = "Configure";
            this.configBiasOutputButton.UseVisualStyleBackColor = true;
            this.configBiasOutputButton.Click += new System.EventHandler(this.configBiasOutputButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.09346F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.97196F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.51542F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.02643F));
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.VdsUpDown, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.VgsUpDown, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label20, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.vdsLockCheckBox, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.vgsLockCheckBox, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label24, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.vdsPresValTextBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.vgsPresValTextBox, 2, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(136, 38);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 98);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 69);
            this.label17.Margin = new System.Windows.Forms.Padding(5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 17);
            this.label17.TabIndex = 29;
            this.label17.Text = "Vgs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 37);
            this.label15.Margin = new System.Windows.Forms.Padding(5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "Vds";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(50, 5);
            this.label19.Margin = new System.Windows.Forms.Padding(5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 17);
            this.label19.TabIndex = 30;
            this.label19.Text = "Set V";
            // 
            // VdsUpDown
            // 
            this.VdsUpDown.DecimalPlaces = 2;
            this.VdsUpDown.Enabled = false;
            this.VdsUpDown.Location = new System.Drawing.Point(50, 37);
            this.VdsUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.VdsUpDown.Name = "VdsUpDown";
            this.VdsUpDown.Size = new System.Drawing.Size(52, 22);
            this.VdsUpDown.TabIndex = 34;
            this.VdsUpDown.ValueChanged += new System.EventHandler(this.VdsUpDown_ValueChanged);
            // 
            // VgsUpDown
            // 
            this.VgsUpDown.DecimalPlaces = 2;
            this.VgsUpDown.Enabled = false;
            this.VgsUpDown.Location = new System.Drawing.Point(50, 69);
            this.VgsUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.VgsUpDown.Name = "VgsUpDown";
            this.VgsUpDown.Size = new System.Drawing.Size(52, 22);
            this.VgsUpDown.TabIndex = 35;
            this.VgsUpDown.ValueChanged += new System.EventHandler(this.VgsUpDown_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(181, 5);
            this.label20.Margin = new System.Windows.Forms.Padding(5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 22);
            this.label20.TabIndex = 31;
            this.label20.Text = "Lock?";
            // 
            // vdsLockCheckBox
            // 
            this.vdsLockCheckBox.AutoSize = true;
            this.vdsLockCheckBox.Location = new System.Drawing.Point(179, 35);
            this.vdsLockCheckBox.Name = "vdsLockCheckBox";
            this.vdsLockCheckBox.Padding = new System.Windows.Forms.Padding(8);
            this.vdsLockCheckBox.Size = new System.Drawing.Size(31, 26);
            this.vdsLockCheckBox.TabIndex = 32;
            this.vdsLockCheckBox.UseVisualStyleBackColor = true;
            this.vdsLockCheckBox.CheckedChanged += new System.EventHandler(this.vdsLockCheckBox_CheckedChanged);
            // 
            // vgsLockCheckBox
            // 
            this.vgsLockCheckBox.AutoSize = true;
            this.vgsLockCheckBox.Location = new System.Drawing.Point(179, 67);
            this.vgsLockCheckBox.Name = "vgsLockCheckBox";
            this.vgsLockCheckBox.Padding = new System.Windows.Forms.Padding(8);
            this.vgsLockCheckBox.Size = new System.Drawing.Size(31, 28);
            this.vgsLockCheckBox.TabIndex = 33;
            this.vgsLockCheckBox.UseVisualStyleBackColor = true;
            this.vgsLockCheckBox.CheckedChanged += new System.EventHandler(this.vgsLockCheckBox_CheckedChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(115, 5);
            this.label24.Margin = new System.Windows.Forms.Padding(5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 17);
            this.label24.TabIndex = 36;
            this.label24.Text = "Pres. V";
            // 
            // vdsPresValTextBox
            // 
            this.vdsPresValTextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.vdsPresValTextBox.Location = new System.Drawing.Point(116, 38);
            this.vdsPresValTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.vdsPresValTextBox.Name = "vdsPresValTextBox";
            this.vdsPresValTextBox.Size = new System.Drawing.Size(54, 22);
            this.vdsPresValTextBox.TabIndex = 37;
            // 
            // vgsPresValTextBox
            // 
            this.vgsPresValTextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.vgsPresValTextBox.Location = new System.Drawing.Point(116, 70);
            this.vgsPresValTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.vgsPresValTextBox.Name = "vgsPresValTextBox";
            this.vgsPresValTextBox.Size = new System.Drawing.Size(54, 22);
            this.vgsPresValTextBox.TabIndex = 38;
            // 
            // biasOutsBox
            // 
            this.biasOutsBox.AutoSize = true;
            this.biasOutsBox.Location = new System.Drawing.Point(15, 56);
            this.biasOutsBox.Name = "biasOutsBox";
            this.biasOutsBox.Size = new System.Drawing.Size(117, 21);
            this.biasOutsBox.TabIndex = 26;
            this.biasOutsBox.Text = "Enable Biases";
            this.biasOutsBox.UseVisualStyleBackColor = true;
            this.biasOutsBox.CheckedChanged += new System.EventHandler(this.biasOutsBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "ANALOG DAQ OUTPUT";
            // 
            // SensorBiasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Name = "SensorBiasControl";
            this.Size = new System.Drawing.Size(382, 151);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VdsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VgsUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button configBiasOutputButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown VdsUpDown;
        private System.Windows.Forms.NumericUpDown VgsUpDown;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox vdsLockCheckBox;
        private System.Windows.Forms.CheckBox vgsLockCheckBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox vdsPresValTextBox;
        private System.Windows.Forms.TextBox vgsPresValTextBox;
        private System.Windows.Forms.CheckBox biasOutsBox;
        private System.Windows.Forms.Label label8;
    }
}
