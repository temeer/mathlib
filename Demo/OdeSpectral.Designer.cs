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
            this.label4 = new System.Windows.Forms.Label();
            this.nupChunksCount = new System.Windows.Forms.NumericUpDown();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupIterCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNodesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupChunksCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.label4);
            this.panelBottom.Controls.Add(this.nupChunksCount);
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
            this.panelBottom.Controls.SetChildIndex(this.nupChunksCount, 0);
            this.panelBottom.Controls.SetChildIndex(this.label4, 0);
            // 
            // seriesListBox
            // 
            this.seriesListBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.seriesListBox.Size = new System.Drawing.Size(532, 148);
            // 
            // nupIterCount
            // 
            this.nupIterCount.Location = new System.Drawing.Point(547, 32);
            this.nupIterCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nupIterCount.Size = new System.Drawing.Size(160, 22);
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
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(548, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iterations count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Partial sums order";
            // 
            // nupOrder
            // 
            this.nupOrder.Location = new System.Drawing.Point(547, 84);
            this.nupOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nupOrder.Size = new System.Drawing.Size(160, 22);
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
            this.label3.Location = new System.Drawing.Point(732, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nodes count";
            // 
            // nupNodesCount
            // 
            this.nupNodesCount.Location = new System.Drawing.Point(731, 32);
            this.nupNodesCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.nupNodesCount.Size = new System.Drawing.Size(160, 22);
            this.nupNodesCount.TabIndex = 6;
            this.nupNodesCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupNodesCount.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chunks count";
            // 
            // nupChunksCount
            // 
            this.nupChunksCount.Location = new System.Drawing.Point(731, 84);
            this.nupChunksCount.Margin = new System.Windows.Forms.Padding(4);
            this.nupChunksCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupChunksCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupChunksCount.Name = "nupChunksCount";
            this.nupChunksCount.Size = new System.Drawing.Size(160, 22);
            this.nupChunksCount.TabIndex = 8;
            this.nupChunksCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupChunksCount.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // OdeSpectral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 657);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "OdeSpectral";
            this.Text = "OdeSpectral";
            this.Controls.SetChildIndex(this.panelBottom, 0);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupIterCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNodesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupChunksCount)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupChunksCount;
    }
}