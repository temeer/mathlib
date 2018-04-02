namespace Demo
{
    partial class SobolevWalsh
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
            this.nupNum = new System.Windows.Forms.NumericUpDown();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNum)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.nupNum);
            this.panelBottom.Location = new System.Drawing.Point(0, 544);
            this.panelBottom.Size = new System.Drawing.Size(1097, 123);
            this.panelBottom.Controls.SetChildIndex(this.seriesListBox, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupNum, 0);
            // 
            // seriesListBox
            // 
            this.seriesListBox.Size = new System.Drawing.Size(532, 124);
            // 
            // nupNum
            // 
            this.nupNum.Location = new System.Drawing.Point(552, 30);
            this.nupNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupNum.Name = "nupNum";
            this.nupNum.Size = new System.Drawing.Size(120, 22);
            this.nupNum.TabIndex = 2;
            this.nupNum.ValueChanged += new System.EventHandler(this.nupNum_ValueChanged);
            // 
            // SobolevWalsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 667);
            this.Name = "SobolevWalsh";
            this.Text = "SobolevWalsh";
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nupNum;
    }
}