namespace Demo
{
    partial class OdeSpectral
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
            this.components = new System.ComponentModel.Container();
            this.nupIterCount = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nupOrder = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nupNodesCount = new System.Windows.Forms.NumericUpDown();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupIterCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNodesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Controls.Add(this.nupNodesCount);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Controls.Add(this.nupOrder);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.nupIterCount);
            this.panelBottom.Controls.SetChildIndex(this.seriesListBox, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupIterCount, 0);
            this.panelBottom.Controls.SetChildIndex(this.label1, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupOrder, 0);
            this.panelBottom.Controls.SetChildIndex(this.label2, 0);
            this.panelBottom.Controls.SetChildIndex(this.nupNodesCount, 0);
            this.panelBottom.Controls.SetChildIndex(this.label3, 0);
            // 
            // nupIterCount
            // 
            this.nupIterCount.Location = new System.Drawing.Point(410, 26);
            this.nupIterCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupIterCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupIterCount.Name = "nupIterCount";
            this.nupIterCount.Size = new System.Drawing.Size(120, 20);
            this.nupIterCount.TabIndex = 2;
            this.nupIterCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupIterCount.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iterations count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Partial sums order";
            // 
            // nupOrder
            // 
            this.nupOrder.Location = new System.Drawing.Point(410, 68);
            this.nupOrder.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupOrder.Name = "nupOrder";
            this.nupOrder.Size = new System.Drawing.Size(120, 20);
            this.nupOrder.TabIndex = 4;
            this.nupOrder.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupOrder.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(549, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nodes count";
            // 
            // nupNodesCount
            // 
            this.nupNodesCount.Location = new System.Drawing.Point(548, 26);
            this.nupNodesCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupNodesCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupNodesCount.Name = "nupNodesCount";
            this.nupNodesCount.Size = new System.Drawing.Size(120, 20);
            this.nupNodesCount.TabIndex = 6;
            this.nupNodesCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupNodesCount.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // OdeSpectral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 534);
            this.Name = "OdeSpectral";
            this.Text = "OdeSpectral";
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupIterCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNodesCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nupIterCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupNodesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupOrder;
    }
}