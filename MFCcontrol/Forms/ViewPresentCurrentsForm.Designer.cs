namespace MFCcontrol
{
    partial class ViewPresentCurrentsForm
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
            this.refreshTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTimeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshTimeUpDown
            // 
            this.refreshTimeUpDown.Location = new System.Drawing.Point(271, 414);
            this.refreshTimeUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.refreshTimeUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.refreshTimeUpDown.Name = "refreshTimeUpDown";
            this.refreshTimeUpDown.Size = new System.Drawing.Size(56, 22);
            this.refreshTimeUpDown.TabIndex = 0;
            this.refreshTimeUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.refreshTimeUpDown.ValueChanged += new System.EventHandler(this.refreshTimeUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Refresh Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ms";
            // 
            // ViewPresentCurrentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1714, 457);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshTimeUpDown);
            this.Name = "ViewPresentCurrentsForm";
            this.Text = "ViewPresentCurrentsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewPresentCurrentsForm_FormClosing);
            this.Load += new System.EventHandler(this.ViewPresentCurrentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.refreshTimeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown refreshTimeUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}