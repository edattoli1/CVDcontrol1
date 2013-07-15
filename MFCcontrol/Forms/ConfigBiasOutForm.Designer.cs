namespace MFCcontrol
{
    partial class ConfigBiasOutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveConfigBiasForm = new System.Windows.Forms.Button();
            this.cancelConfigBiasForm = new System.Windows.Forms.Button();
            this.vdsAoChanComboBox = new System.Windows.Forms.ComboBox();
            this.vgsAoChanComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.daqAoMaxRangeUpDown = new System.Windows.Forms.NumericUpDown();
            this.daqAoMinRangeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.daqAoMaxRangeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daqAoMinRangeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vds DAQ AO Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vgs DAQ AO Address";
            // 
            // saveConfigBiasForm
            // 
            this.saveConfigBiasForm.Location = new System.Drawing.Point(124, 314);
            this.saveConfigBiasForm.Name = "saveConfigBiasForm";
            this.saveConfigBiasForm.Size = new System.Drawing.Size(130, 43);
            this.saveConfigBiasForm.TabIndex = 4;
            this.saveConfigBiasForm.Text = "Save and Apply Changes";
            this.saveConfigBiasForm.UseVisualStyleBackColor = true;
            this.saveConfigBiasForm.Click += new System.EventHandler(this.saveConfigBiasForm_Click);
            // 
            // cancelConfigBiasForm
            // 
            this.cancelConfigBiasForm.Location = new System.Drawing.Point(304, 324);
            this.cancelConfigBiasForm.Name = "cancelConfigBiasForm";
            this.cancelConfigBiasForm.Size = new System.Drawing.Size(75, 23);
            this.cancelConfigBiasForm.TabIndex = 5;
            this.cancelConfigBiasForm.Text = "Cancel";
            this.cancelConfigBiasForm.UseVisualStyleBackColor = true;
            this.cancelConfigBiasForm.Click += new System.EventHandler(this.cancelConfigBiasForm_Click);
            // 
            // vdsAoChanComboBox
            // 
            this.vdsAoChanComboBox.FormattingEnabled = true;
            this.vdsAoChanComboBox.Location = new System.Drawing.Point(237, 66);
            this.vdsAoChanComboBox.Name = "vdsAoChanComboBox";
            this.vdsAoChanComboBox.Size = new System.Drawing.Size(184, 24);
            this.vdsAoChanComboBox.TabIndex = 6;
            // 
            // vgsAoChanComboBox
            // 
            this.vgsAoChanComboBox.FormattingEnabled = true;
            this.vgsAoChanComboBox.Location = new System.Drawing.Point(237, 114);
            this.vgsAoChanComboBox.Name = "vgsAoChanComboBox";
            this.vgsAoChanComboBox.Size = new System.Drawing.Size(184, 24);
            this.vgsAoChanComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "DAQ AO Max Voltage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "DAQ AO Min Voltage";
            // 
            // daqAoMaxRangeUpDown
            // 
            this.daqAoMaxRangeUpDown.Location = new System.Drawing.Point(259, 199);
            this.daqAoMaxRangeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.daqAoMaxRangeUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.daqAoMaxRangeUpDown.Name = "daqAoMaxRangeUpDown";
            this.daqAoMaxRangeUpDown.Size = new System.Drawing.Size(120, 22);
            this.daqAoMaxRangeUpDown.TabIndex = 10;
            // 
            // daqAoMinRangeUpDown
            // 
            this.daqAoMinRangeUpDown.Location = new System.Drawing.Point(259, 249);
            this.daqAoMinRangeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.daqAoMinRangeUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.daqAoMinRangeUpDown.Name = "daqAoMinRangeUpDown";
            this.daqAoMinRangeUpDown.Size = new System.Drawing.Size(120, 22);
            this.daqAoMinRangeUpDown.TabIndex = 11;
            // 
            // ConfigBiasOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 404);
            this.Controls.Add(this.daqAoMinRangeUpDown);
            this.Controls.Add(this.daqAoMaxRangeUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vgsAoChanComboBox);
            this.Controls.Add(this.vdsAoChanComboBox);
            this.Controls.Add(this.cancelConfigBiasForm);
            this.Controls.Add(this.saveConfigBiasForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConfigBiasOutForm";
            this.Text = "ConfigBiasOutForm";
            this.Load += new System.EventHandler(this.ConfigBiasOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.daqAoMaxRangeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daqAoMinRangeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveConfigBiasForm;
        private System.Windows.Forms.Button cancelConfigBiasForm;
        private System.Windows.Forms.ComboBox vdsAoChanComboBox;
        private System.Windows.Forms.ComboBox vgsAoChanComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown daqAoMaxRangeUpDown;
        private System.Windows.Forms.NumericUpDown daqAoMinRangeUpDown;
    }
}