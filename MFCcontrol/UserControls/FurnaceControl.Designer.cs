namespace MFCcontrol
{
    partial class FurnaceControl
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.presTempBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setTempUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.offButton = new System.Windows.Forms.Button();
            this.onButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setTempUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.presTempBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.setTempUpDown1);
            this.panel3.Controls.Add(this.offButton);
            this.panel3.Controls.Add(this.onButton);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 109);
            this.panel3.TabIndex = 43;
            // 
            // presTempBox
            // 
            this.presTempBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.presTempBox.Enabled = false;
            this.presTempBox.Location = new System.Drawing.Point(204, 71);
            this.presTempBox.Name = "presTempBox";
            this.presTempBox.Size = new System.Drawing.Size(87, 22);
            this.presTempBox.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "Pres. Temp.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Set Temp.";
            // 
            // setTempUpDown1
            // 
            this.setTempUpDown1.Location = new System.Drawing.Point(205, 40);
            this.setTempUpDown1.Maximum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.setTempUpDown1.Name = "setTempUpDown1";
            this.setTempUpDown1.Size = new System.Drawing.Size(86, 22);
            this.setTempUpDown1.TabIndex = 44;
            this.setTempUpDown1.ValueChanged += new System.EventHandler(this.setTempUpDown1_ValueChanged);
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(16, 71);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(75, 23);
            this.offButton.TabIndex = 45;
            this.offButton.Text = "OFF";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(16, 37);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(75, 23);
            this.onButton.TabIndex = 44;
            this.onButton.Text = "ON";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "FURNACE CONTROL";
            // 
            // FurnaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "FurnaceControl";
            this.Size = new System.Drawing.Size(317, 116);
            this.Load += new System.EventHandler(this.FurnaceControl_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setTempUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.NumericUpDown setTempUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox presTempBox;
    }
}
