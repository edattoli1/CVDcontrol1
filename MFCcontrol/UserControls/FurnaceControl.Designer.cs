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
            this.heaterStateBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.furnaceControlCheckBox = new System.Windows.Forms.CheckBox();
            this.presTempBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.offButton = new System.Windows.Forms.Button();
            this.onButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.manualFurnaceControlButton = new System.Windows.Forms.Button();
            this.uploadFurnaceTempProfileButton = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.uploadFurnaceTempProfileButton);
            this.panel3.Controls.Add(this.manualFurnaceControlButton);
            this.panel3.Controls.Add(this.heaterStateBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.furnaceControlCheckBox);
            this.panel3.Controls.Add(this.presTempBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.offButton);
            this.panel3.Controls.Add(this.onButton);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 143);
            this.panel3.TabIndex = 43;
            // 
            // heaterStateBox
            // 
            this.heaterStateBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.heaterStateBox.Location = new System.Drawing.Point(62, 110);
            this.heaterStateBox.Name = "heaterStateBox";
            this.heaterStateBox.ReadOnly = true;
            this.heaterStateBox.Size = new System.Drawing.Size(40, 22);
            this.heaterStateBox.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 51;
            this.label5.Text = "STATE:";
            // 
            // furnaceControlCheckBox
            // 
            this.furnaceControlCheckBox.AutoSize = true;
            this.furnaceControlCheckBox.Location = new System.Drawing.Point(181, 8);
            this.furnaceControlCheckBox.Name = "furnaceControlCheckBox";
            this.furnaceControlCheckBox.Size = new System.Drawing.Size(123, 21);
            this.furnaceControlCheckBox.TabIndex = 44;
            this.furnaceControlCheckBox.Text = "Enable Control";
            this.furnaceControlCheckBox.UseVisualStyleBackColor = true;
            this.furnaceControlCheckBox.CheckedChanged += new System.EventHandler(this.furnaceControlCheckBox_CheckedChanged);
            // 
            // presTempBox
            // 
            this.presTempBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.presTempBox.Location = new System.Drawing.Point(204, 108);
            this.presTempBox.Name = "presTempBox";
            this.presTempBox.ReadOnly = true;
            this.presTempBox.Size = new System.Drawing.Size(87, 22);
            this.presTempBox.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "Pres. Temp.";
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(6, 71);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(75, 23);
            this.offButton.TabIndex = 45;
            this.offButton.Text = "OFF";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(8, 37);
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
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "OVEN CONTROL";
            // 
            // manualFurnaceControlButton
            // 
            this.manualFurnaceControlButton.Location = new System.Drawing.Point(124, 73);
            this.manualFurnaceControlButton.Name = "manualFurnaceControlButton";
            this.manualFurnaceControlButton.Size = new System.Drawing.Size(75, 23);
            this.manualFurnaceControlButton.TabIndex = 44;
            this.manualFurnaceControlButton.Text = "Manual";
            this.manualFurnaceControlButton.UseVisualStyleBackColor = true;
            this.manualFurnaceControlButton.Click += new System.EventHandler(this.manualFurnaceControlButton_Click);
            // 
            // uploadFurnaceTempProfileButton
            // 
            this.uploadFurnaceTempProfileButton.Enabled = false;
            this.uploadFurnaceTempProfileButton.Location = new System.Drawing.Point(124, 37);
            this.uploadFurnaceTempProfileButton.Name = "uploadFurnaceTempProfileButton";
            this.uploadFurnaceTempProfileButton.Size = new System.Drawing.Size(152, 28);
            this.uploadFurnaceTempProfileButton.TabIndex = 53;
            this.uploadFurnaceTempProfileButton.Text = "Upload Temp Profile";
            this.uploadFurnaceTempProfileButton.UseVisualStyleBackColor = true;
            this.uploadFurnaceTempProfileButton.Click += new System.EventHandler(this.uploadFurnaceTempProfileButton_Click);
            // 
            // FurnaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "FurnaceControl";
            this.Size = new System.Drawing.Size(317, 149);
            this.Load += new System.EventHandler(this.FurnaceControl_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox presTempBox;
        internal System.Windows.Forms.CheckBox furnaceControlCheckBox;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox heaterStateBox;
        private System.Windows.Forms.Button manualFurnaceControlButton;
        internal System.Windows.Forms.Button uploadFurnaceTempProfileButton;
    }
}
