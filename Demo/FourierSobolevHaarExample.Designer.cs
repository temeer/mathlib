namespace Demo
{
    partial class FourierSobolevHaarExample
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
            this.labelP = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.numP = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.numericUpDown2);
            this.panelBottom.Controls.Add(this.numP);
            this.panelBottom.Controls.Add(this.labelX);
            this.panelBottom.Controls.Add(this.labelP);
            this.panelBottom.Location = new System.Drawing.Point(0, 440);
            this.panelBottom.Size = new System.Drawing.Size(868, 100);
            this.panelBottom.Controls.SetChildIndex(this.seriesListBox, 0);
            this.panelBottom.Controls.SetChildIndex(this.labelP, 0);
            this.panelBottom.Controls.SetChildIndex(this.labelX, 0);
            this.panelBottom.Controls.SetChildIndex(this.numP, 0);
            this.panelBottom.Controls.SetChildIndex(this.numericUpDown2, 0);
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Location = new System.Drawing.Point(409, 8);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(49, 13);
            this.labelP.TabIndex = 2;
            this.labelP.Text = "p.Length";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(409, 34);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(48, 13);
            this.labelX.TabIndex = 3;
            this.labelX.Text = "x.Length";
            // 
            // numP
            // 
            this.numP.Location = new System.Drawing.Point(463, 6);
            this.numP.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numP.Name = "numP";
            this.numP.Size = new System.Drawing.Size(120, 20);
            this.numP.TabIndex = 4;
            this.numP.ThousandsSeparator = true;
            this.numP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numP.ValueChanged += new System.EventHandler(this.numP_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(463, 32);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.ThousandsSeparator = true;
            this.numericUpDown2.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // FourierSobolevHaarExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 540);
            this.Name = "FourierSobolevHaarExample";
            this.Text = "FourierSobolevHaar";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelP;
        public System.Windows.Forms.NumericUpDown numP;
    }
}