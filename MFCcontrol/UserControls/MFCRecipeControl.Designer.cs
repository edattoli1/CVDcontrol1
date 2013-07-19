namespace MFCcontrol
{
    partial class MfcRecipeControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewPresentCurrentsButton = new System.Windows.Forms.Button();
            this.nextRecipeTimeEventBox = new System.Windows.Forms.TextBox();
            this.lastRecipeTimeEventBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.recipePauseCheckbox = new System.Windows.Forms.CheckBox();
            this.exitRecipeButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.viewFlowRecipe = new System.Windows.Forms.Button();
            this.loadFlowsButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.viewPresentCurrentsButton);
            this.panel2.Controls.Add(this.nextRecipeTimeEventBox);
            this.panel2.Controls.Add(this.lastRecipeTimeEventBox);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.recipePauseCheckbox);
            this.panel2.Controls.Add(this.exitRecipeButton);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.startButton);
            this.panel2.Controls.Add(this.viewFlowRecipe);
            this.panel2.Controls.Add(this.loadFlowsButton);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 230);
            this.panel2.TabIndex = 18;
            // 
            // viewPresentCurrentsButton
            // 
            this.viewPresentCurrentsButton.Enabled = false;
            this.viewPresentCurrentsButton.Location = new System.Drawing.Point(156, 196);
            this.viewPresentCurrentsButton.Name = "viewPresentCurrentsButton";
            this.viewPresentCurrentsButton.Size = new System.Drawing.Size(96, 49);
            this.viewPresentCurrentsButton.TabIndex = 24;
            this.viewPresentCurrentsButton.Text = "View Currents";
            this.viewPresentCurrentsButton.UseVisualStyleBackColor = true;
            this.viewPresentCurrentsButton.Visible = false;
            this.viewPresentCurrentsButton.Click += new System.EventHandler(this.viewPresentCurrentsButton_Click);
            // 
            // nextRecipeTimeEventBox
            // 
            this.nextRecipeTimeEventBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.nextRecipeTimeEventBox.Enabled = false;
            this.nextRecipeTimeEventBox.Location = new System.Drawing.Point(164, 75);
            this.nextRecipeTimeEventBox.Name = "nextRecipeTimeEventBox";
            this.nextRecipeTimeEventBox.ReadOnly = true;
            this.nextRecipeTimeEventBox.Size = new System.Drawing.Size(88, 22);
            this.nextRecipeTimeEventBox.TabIndex = 23;
            // 
            // lastRecipeTimeEventBox
            // 
            this.lastRecipeTimeEventBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lastRecipeTimeEventBox.Enabled = false;
            this.lastRecipeTimeEventBox.Location = new System.Drawing.Point(164, 45);
            this.lastRecipeTimeEventBox.Name = "lastRecipeTimeEventBox";
            this.lastRecipeTimeEventBox.ReadOnly = true;
            this.lastRecipeTimeEventBox.Size = new System.Drawing.Size(88, 22);
            this.lastRecipeTimeEventBox.TabIndex = 22;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(116, 17);
            this.label23.TabIndex = 21;
            this.label23.Text = "Next Event (min):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(115, 17);
            this.label22.TabIndex = 20;
            this.label22.Text = "Last Event (min):";
            // 
            // recipePauseCheckbox
            // 
            this.recipePauseCheckbox.AutoSize = true;
            this.recipePauseCheckbox.Enabled = false;
            this.recipePauseCheckbox.Location = new System.Drawing.Point(16, 148);
            this.recipePauseCheckbox.Name = "recipePauseCheckbox";
            this.recipePauseCheckbox.Size = new System.Drawing.Size(106, 38);
            this.recipePauseCheckbox.TabIndex = 19;
            this.recipePauseCheckbox.Text = "Pause Flow \r\nChanges";
            this.recipePauseCheckbox.UseVisualStyleBackColor = true;
            this.recipePauseCheckbox.Click += new System.EventHandler(this.recipePauseCheckbox_CheckedChanged);
            // 
            // exitRecipeButton
            // 
            this.exitRecipeButton.Enabled = false;
            this.exitRecipeButton.Location = new System.Drawing.Point(11, 191);
            this.exitRecipeButton.Name = "exitRecipeButton";
            this.exitRecipeButton.Size = new System.Drawing.Size(134, 29);
            this.exitRecipeButton.TabIndex = 17;
            this.exitRecipeButton.Text = "Exit Recipe";
            this.exitRecipeButton.UseVisualStyleBackColor = true;
            this.exitRecipeButton.Click += new System.EventHandler(this.exitRecipe_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(279, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "MFC&&OVEN RECIPE CONTROL";
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(16, 109);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // viewFlowRecipe
            // 
            this.viewFlowRecipe.Enabled = false;
            this.viewFlowRecipe.Location = new System.Drawing.Point(137, 149);
            this.viewFlowRecipe.Name = "viewFlowRecipe";
            this.viewFlowRecipe.Size = new System.Drawing.Size(143, 23);
            this.viewFlowRecipe.TabIndex = 7;
            this.viewFlowRecipe.Text = "View Flow Recipe";
            this.viewFlowRecipe.UseVisualStyleBackColor = true;
            this.viewFlowRecipe.Click += new System.EventHandler(this.viewFlowRecipe_Click);
            // 
            // loadFlowsButton
            // 
            this.loadFlowsButton.Location = new System.Drawing.Point(137, 114);
            this.loadFlowsButton.Name = "loadFlowsButton";
            this.loadFlowsButton.Size = new System.Drawing.Size(143, 23);
            this.loadFlowsButton.TabIndex = 6;
            this.loadFlowsButton.Text = "Load Flow Recipe";
            this.loadFlowsButton.UseVisualStyleBackColor = true;
            this.loadFlowsButton.Click += new System.EventHandler(this.loadFlowsButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel2007+|*.xlsx";
            // 
            // MfcRecipeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "MfcRecipeControl";
            this.Size = new System.Drawing.Size(331, 236);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox recipePauseCheckbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.TextBox nextRecipeTimeEventBox;
        internal System.Windows.Forms.TextBox lastRecipeTimeEventBox;
        internal System.Windows.Forms.Button exitRecipeButton;
        internal System.Windows.Forms.Button startButton;
        internal System.Windows.Forms.Button viewFlowRecipe;
        internal System.Windows.Forms.Button loadFlowsButton;
        internal System.Windows.Forms.Button viewPresentCurrentsButton;
    }
}
