/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 01/08/2014
 * Time: 21:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace GDIFractalRendererLibrary.View
{
	partial class FractalView
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this._numOfPointsLb = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._rendererPanel = new System.Windows.Forms.Panel();
            this._fractalDimLb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this._rendererPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _numOfPointsLb
            // 
            this._numOfPointsLb.AutoSize = true;
            this._numOfPointsLb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._numOfPointsLb.Location = new System.Drawing.Point(0, 132);
            this._numOfPointsLb.Name = "_numOfPointsLb";
            this._numOfPointsLb.Size = new System.Drawing.Size(46, 17);
            this._numOfPointsLb.TabIndex = 1;
            this._numOfPointsLb.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._rendererPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fractal Graph";
            // 
            // _rendererPanel
            // 
            this._rendererPanel.Controls.Add(this._fractalDimLb);
            this._rendererPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rendererPanel.Location = new System.Drawing.Point(3, 18);
            this._rendererPanel.Name = "_rendererPanel";
            this._rendererPanel.Size = new System.Drawing.Size(562, 111);
            this._rendererPanel.TabIndex = 1;
            this._rendererPanel.DoubleClick += new System.EventHandler(this._rendererPanel_DoubleClick);
            this._rendererPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._rendererPanel_MouseDown);
            this._rendererPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rendererPanel_MouseMove);
            this._rendererPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this._rendererPanel_MouseUp);
            // 
            // _fractalDimLb
            // 
            this._fractalDimLb.AutoSize = true;
            this._fractalDimLb.Dock = System.Windows.Forms.DockStyle.Right;
            this._fractalDimLb.Location = new System.Drawing.Point(562, 0);
            this._fractalDimLb.Name = "_fractalDimLb";
            this._fractalDimLb.Size = new System.Drawing.Size(0, 17);
            this._fractalDimLb.TabIndex = 0;
            // 
            // FractalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._numOfPointsLb);
            this.Name = "FractalView";
            this.Size = new System.Drawing.Size(568, 149);
            this.groupBox1.ResumeLayout(false);
            this._rendererPanel.ResumeLayout(false);
            this._rendererPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label _numOfPointsLb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel _rendererPanel;
        private System.Windows.Forms.Label _fractalDimLb;
	}
}
