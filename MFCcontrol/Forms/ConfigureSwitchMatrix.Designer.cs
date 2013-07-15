namespace MFCcontrol
{
    partial class ConfigureSwitchMatrix
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
            this.resourceNameLabel = new System.Windows.Forms.Label();
            this.resourceNameComboBox = new System.Windows.Forms.ComboBox();
            this.topologyNameLabel = new System.Windows.Forms.Label();
            this.topologyNameComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resourceNameLabel
            // 
            this.resourceNameLabel.AutoSize = true;
            this.resourceNameLabel.Location = new System.Drawing.Point(13, 23);
            this.resourceNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resourceNameLabel.Name = "resourceNameLabel";
            this.resourceNameLabel.Size = new System.Drawing.Size(110, 17);
            this.resourceNameLabel.TabIndex = 6;
            this.resourceNameLabel.Text = "Resource Name";
            // 
            // resourceNameComboBox
            // 
            this.resourceNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceNameComboBox.FormattingEnabled = true;
            this.resourceNameComboBox.Location = new System.Drawing.Point(13, 44);
            this.resourceNameComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.resourceNameComboBox.Name = "resourceNameComboBox";
            this.resourceNameComboBox.Size = new System.Drawing.Size(160, 24);
            this.resourceNameComboBox.TabIndex = 7;
            // 
            // topologyNameLabel
            // 
            this.topologyNameLabel.AutoSize = true;
            this.topologyNameLabel.Location = new System.Drawing.Point(13, 100);
            this.topologyNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topologyNameLabel.Name = "topologyNameLabel";
            this.topologyNameLabel.Size = new System.Drawing.Size(108, 17);
            this.topologyNameLabel.TabIndex = 8;
            this.topologyNameLabel.Text = "Topology Name";
            // 
            // topologyNameComboBox
            // 
            this.topologyNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.topologyNameComboBox.FormattingEnabled = true;
            this.topologyNameComboBox.Location = new System.Drawing.Point(12, 121);
            this.topologyNameComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.topologyNameComboBox.Name = "topologyNameComboBox";
            this.topologyNameComboBox.Size = new System.Drawing.Size(253, 24);
            this.topologyNameComboBox.TabIndex = 9;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 192);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 39);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save and Exit";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(146, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ConfigureSwitchMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 251);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.topologyNameComboBox);
            this.Controls.Add(this.topologyNameLabel);
            this.Controls.Add(this.resourceNameComboBox);
            this.Controls.Add(this.resourceNameLabel);
            this.Name = "ConfigureSwitchMatrix";
            this.Text = "ConfigureSwitchMatrix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resourceNameLabel;
        private System.Windows.Forms.ComboBox resourceNameComboBox;
        private System.Windows.Forms.Label topologyNameLabel;
        private System.Windows.Forms.ComboBox topologyNameComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}