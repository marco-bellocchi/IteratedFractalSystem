/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 01/08/2014
 * Time: 21:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace OpenGLFractalRenderer.View
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
            this._glControl = new OpenTK.GLControl();
            this._pointsLb = new System.Windows.Forms.Label();
            this._dimLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _glControl
            // 
            this._glControl.BackColor = System.Drawing.Color.Black;
            this._glControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._glControl.Location = new System.Drawing.Point(0, 0);
            this._glControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._glControl.Name = "_glControl";
            this._glControl.Size = new System.Drawing.Size(565, 169);
            this._glControl.TabIndex = 0;
            this._glControl.VSync = false;
            this._glControl.Load += new System.EventHandler(this._glControl_Load);
            this._glControl.DoubleClick += new System.EventHandler(this._rendererPanel_DoubleClick);
            this._glControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this._glControl_MouseDown);
            this._glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this._rendererPanel_MouseMove);
            this._glControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this._rendererPanel_MouseUp);
            // 
            // _pointsLb
            // 
            this._pointsLb.AutoSize = true;
            this._pointsLb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._pointsLb.Location = new System.Drawing.Point(0, 152);
            this._pointsLb.Name = "_pointsLb";
            this._pointsLb.Size = new System.Drawing.Size(16, 17);
            this._pointsLb.TabIndex = 1;
            this._pointsLb.Text = "0";
            // 
            // _dimLb
            // 
            this._dimLb.AutoSize = true;
            this._dimLb.Dock = System.Windows.Forms.DockStyle.Right;
            this._dimLb.Location = new System.Drawing.Point(565, 0);
            this._dimLb.Name = "_dimLb";
            this._dimLb.Size = new System.Drawing.Size(0, 17);
            this._dimLb.TabIndex = 2;
            // 
            // FractalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this._dimLb);
            this.Controls.Add(this._pointsLb);
            this.Controls.Add(this._glControl);
            this.Name = "FractalView";
            this.Size = new System.Drawing.Size(565, 169);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private OpenTK.GLControl _glControl;
        private System.Windows.Forms.Label _pointsLb;
        private System.Windows.Forms.Label _dimLb;
	}
}
