namespace ArtifactLocatorVisualisationUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.visualisationPictureBox = new System.Windows.Forms.PictureBox();
            this.runButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.visualisationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // visualisationPictureBox
            // 
            this.visualisationPictureBox.Location = new System.Drawing.Point(12, 12);
            this.visualisationPictureBox.Name = "visualisationPictureBox";
            this.visualisationPictureBox.Size = new System.Drawing.Size(500, 500);
            this.visualisationPictureBox.TabIndex = 0;
            this.visualisationPictureBox.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(168, 518);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(170, 40);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run algorithm";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(447, 532);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(65, 26);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 570);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.visualisationPictureBox);
            this.Name = "Form1";
            this.Text = "VisualisationUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.visualisationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox visualisationPictureBox;
        private Button runButton;
        private Button refreshButton;
    }
}