namespace MFCcontrol
{
    partial class ScanDeviceCurrentsForm
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
            this.scanCurrentsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // scanCurrentsButton
            // 
            this.scanCurrentsButton.Location = new System.Drawing.Point(12, 432);
            this.scanCurrentsButton.Name = "scanCurrentsButton";
            this.scanCurrentsButton.Size = new System.Drawing.Size(85, 48);
            this.scanCurrentsButton.TabIndex = 0;
            this.scanCurrentsButton.Text = "Scan Currents";
            this.scanCurrentsButton.UseVisualStyleBackColor = true;
            this.scanCurrentsButton.Click += new System.EventHandler(this.scanCurrentsButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1448, 392);
            this.panel1.TabIndex = 1;
            // 
            // ScanDeviceCurrentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.scanCurrentsButton);
            this.Name = "ScanDeviceCurrentsForm";
            this.Text = "ScanDeviceCurrentsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanDeviceCurrentsForm_FormClosing);
            this.Load += new System.EventHandler(this.ScanDeviceCurrentsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scanCurrentsButton;
        private System.Windows.Forms.Panel panel1;
    }
}