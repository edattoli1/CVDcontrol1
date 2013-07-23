namespace MFCcontrol{
    partial class ManualFurnaceControlForm
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
            this.lastSetTempBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setTempUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.setTempUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lastSetTempBox
            // 
            this.lastSetTempBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lastSetTempBox.Location = new System.Drawing.Point(129, 85);
            this.lastSetTempBox.Name = "lastSetTempBox";
            this.lastSetTempBox.ReadOnly = true;
            this.lastSetTempBox.Size = new System.Drawing.Size(87, 22);
            this.lastSetTempBox.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Last Set Temp.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Set Temp.";
            // 
            // setTempUpDown1
            // 
            this.setTempUpDown1.Location = new System.Drawing.Point(130, 53);
            this.setTempUpDown1.Maximum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.setTempUpDown1.Name = "setTempUpDown1";
            this.setTempUpDown1.Size = new System.Drawing.Size(86, 22);
            this.setTempUpDown1.TabIndex = 51;
            this.setTempUpDown1.ValueChanged += new System.EventHandler(this.setTempUpDown1_ValueChanged);
            // 
            // ManualFurnaceControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 133);
            this.Controls.Add(this.lastSetTempBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setTempUpDown1);
            this.Name = "ManualFurnaceControlForm";
            this.Text = "ManualFurnaceControlForm";
            ((System.ComponentModel.ISupportInitialize)(this.setTempUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox lastSetTempBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown setTempUpDown1;
    }
}