namespace MFCcontrol
{
    partial class SwitchStateForm
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
            this.refreshListCheckBox = new System.Windows.Forms.CheckBox();
            this.refreshRateUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.row2CloseAllButton = new System.Windows.Forms.Button();
            this.openAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshListCheckBox
            // 
            this.refreshListCheckBox.AutoSize = true;
            this.refreshListCheckBox.Location = new System.Drawing.Point(29, 429);
            this.refreshListCheckBox.Name = "refreshListCheckBox";
            this.refreshListCheckBox.Size = new System.Drawing.Size(103, 21);
            this.refreshListCheckBox.TabIndex = 0;
            this.refreshListCheckBox.Text = "Refresh List";
            this.refreshListCheckBox.UseVisualStyleBackColor = true;
            this.refreshListCheckBox.CheckedChanged += new System.EventHandler(this.refreshListCheckBox_CheckedChanged);
            // 
            // refreshRateUpDown
            // 
            this.refreshRateUpDown.Location = new System.Drawing.Point(143, 463);
            this.refreshRateUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.refreshRateUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.refreshRateUpDown.Name = "refreshRateUpDown";
            this.refreshRateUpDown.Size = new System.Drawing.Size(65, 22);
            this.refreshRateUpDown.TabIndex = 1;
            this.refreshRateUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.refreshRateUpDown.ValueChanged += new System.EventHandler(this.refreshRateUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Refresh Rate:";
            // 
            // row2CloseAllButton
            // 
            this.row2CloseAllButton.Location = new System.Drawing.Point(293, 434);
            this.row2CloseAllButton.Name = "row2CloseAllButton";
            this.row2CloseAllButton.Size = new System.Drawing.Size(102, 48);
            this.row2CloseAllButton.TabIndex = 4;
            this.row2CloseAllButton.Text = "Close All on Row 2";
            this.row2CloseAllButton.UseVisualStyleBackColor = true;
            this.row2CloseAllButton.Click += new System.EventHandler(this.row2CloseAllButton_click);
            // 
            // openAllButton
            // 
            this.openAllButton.Location = new System.Drawing.Point(434, 447);
            this.openAllButton.Name = "openAllButton";
            this.openAllButton.Size = new System.Drawing.Size(75, 23);
            this.openAllButton.TabIndex = 5;
            this.openAllButton.Text = "Open All";
            this.openAllButton.UseVisualStyleBackColor = true;
            this.openAllButton.Click += new System.EventHandler(this.openAllButton_Click);
            // 
            // SwitchStateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 512);
            this.Controls.Add(this.openAllButton);
            this.Controls.Add(this.row2CloseAllButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshRateUpDown);
            this.Controls.Add(this.refreshListCheckBox);
            this.Name = "SwitchStateForm";
            this.Text = "SwitchStateForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SwitchStateForm_FormClosing);
            this.Load += new System.EventHandler(this.SwitchStateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox refreshListCheckBox;
        private System.Windows.Forms.NumericUpDown refreshRateUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button row2CloseAllButton;
        private System.Windows.Forms.Button openAllButton;

    }
}