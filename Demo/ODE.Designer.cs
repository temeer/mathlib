namespace Demo
{
    partial class ODE
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
            this.buttonSolve = new System.Windows.Forms.Button();
            this.cbShowPoints = new System.Windows.Forms.CheckBox();
            this.nupPointsCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupPointsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(575, 354);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(75, 23);
            this.buttonSolve.TabIndex = 0;
            this.buttonSolve.Text = "button1";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // cbShowPoints
            // 
            this.cbShowPoints.AutoSize = true;
            this.cbShowPoints.Location = new System.Drawing.Point(12, 12);
            this.cbShowPoints.Name = "cbShowPoints";
            this.cbShowPoints.Size = new System.Drawing.Size(120, 17);
            this.cbShowPoints.TabIndex = 1;
            this.cbShowPoints.Text = "Показывать точки";
            this.cbShowPoints.UseVisualStyleBackColor = true;
            this.cbShowPoints.CheckedChanged += new System.EventHandler(this.cbShowPoints_CheckedChanged);
            // 
            // nupPointsCount
            // 
            this.nupPointsCount.Location = new System.Drawing.Point(12, 44);
            this.nupPointsCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupPointsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupPointsCount.Name = "nupPointsCount";
            this.nupPointsCount.Size = new System.Drawing.Size(120, 20);
            this.nupPointsCount.TabIndex = 2;
            this.nupPointsCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nupPointsCount.ValueChanged += new System.EventHandler(this.nupPointsCount_ValueChanged);
            // 
            // ODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 391);
            this.Controls.Add(this.nupPointsCount);
            this.Controls.Add(this.cbShowPoints);
            this.Controls.Add(this.buttonSolve);
            this.Name = "ODE";
            this.Text = "ODE";
            ((System.ComponentModel.ISupportInitialize)(this.nupPointsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.CheckBox cbShowPoints;
        private System.Windows.Forms.NumericUpDown nupPointsCount;
    }
}