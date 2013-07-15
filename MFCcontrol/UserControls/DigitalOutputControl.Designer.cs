namespace MFCcontrol
{
    partial class DigitalOutputControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewDigitalOutStateButton = new System.Windows.Forms.Button();
            this.configureDigitalOutButton = new System.Windows.Forms.Button();
            this.enableDigitalOutCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewDigitalOutStateButton);
            this.panel1.Controls.Add(this.configureDigitalOutButton);
            this.panel1.Controls.Add(this.enableDigitalOutCheckBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 138);
            this.panel1.TabIndex = 0;
            // 
            // viewDigitalOutStateButton
            // 
            this.viewDigitalOutStateButton.Enabled = false;
            this.viewDigitalOutStateButton.Location = new System.Drawing.Point(114, 73);
            this.viewDigitalOutStateButton.Name = "viewDigitalOutStateButton";
            this.viewDigitalOutStateButton.Size = new System.Drawing.Size(93, 45);
            this.viewDigitalOutStateButton.TabIndex = 25;
            this.viewDigitalOutStateButton.Text = "View, Edit States";
            this.viewDigitalOutStateButton.UseVisualStyleBackColor = true;
            this.viewDigitalOutStateButton.Click += new System.EventHandler(this.viewDigitalOutStateButton_Click);
            // 
            // configureDigitalOutButton
            // 
            this.configureDigitalOutButton.Location = new System.Drawing.Point(14, 81);
            this.configureDigitalOutButton.Name = "configureDigitalOutButton";
            this.configureDigitalOutButton.Size = new System.Drawing.Size(85, 29);
            this.configureDigitalOutButton.TabIndex = 24;
            this.configureDigitalOutButton.Text = "Configure";
            this.configureDigitalOutButton.UseVisualStyleBackColor = true;
            this.configureDigitalOutButton.Click += new System.EventHandler(this.configureDigitalOutButton_Click);
            // 
            // enableDigitalOutCheckBox
            // 
            this.enableDigitalOutCheckBox.AutoSize = true;
            this.enableDigitalOutCheckBox.Location = new System.Drawing.Point(19, 42);
            this.enableDigitalOutCheckBox.Name = "enableDigitalOutCheckBox";
            this.enableDigitalOutCheckBox.Size = new System.Drawing.Size(125, 21);
            this.enableDigitalOutCheckBox.TabIndex = 23;
            this.enableDigitalOutCheckBox.Text = "Enable Outputs";
            this.enableDigitalOutCheckBox.UseVisualStyleBackColor = true;
            this.enableDigitalOutCheckBox.CheckedChanged += new System.EventHandler(this.enableDigitalOutCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "DIGITAL OUTPUT";
            // 
            // DigitalOutputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DigitalOutputControl";
            this.Size = new System.Drawing.Size(237, 143);
            this.Load += new System.EventHandler(this.DigitalOutputControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.CheckBox enableDigitalOutCheckBox;
        internal System.Windows.Forms.Button configureDigitalOutButton;
        internal System.Windows.Forms.Button viewDigitalOutStateButton;
    }
}
