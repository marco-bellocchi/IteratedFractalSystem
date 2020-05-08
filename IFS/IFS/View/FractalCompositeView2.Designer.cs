/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 13/09/2014
 * Time: 18:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace IFS.View
{
	partial class FractalCompositeView2
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this._fractalCalculatorView = new IFS.View.FractalCalculatorView();
			this._fractalViewPlaceholder = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// _fractalCalculatorView
			// 
			this._fractalCalculatorView.Dock = System.Windows.Forms.DockStyle.Top;
			this._fractalCalculatorView.EnableCalculateDimension = true;
			this._fractalCalculatorView.EnableCalculatePoints = true;
			this._fractalCalculatorView.Location = new System.Drawing.Point(0, 0);
			this._fractalCalculatorView.Name = "_fractalCalculatorView";
			this._fractalCalculatorView.Size = new System.Drawing.Size(912, 41);
			this._fractalCalculatorView.TabIndex = 0;
			// 
			// _fractalViewPlaceholder
			// 
			this._fractalViewPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
			this._fractalViewPlaceholder.Location = new System.Drawing.Point(0, 41);
			this._fractalViewPlaceholder.Name = "_fractalViewPlaceholder";
			this._fractalViewPlaceholder.Size = new System.Drawing.Size(912, 334);
			this._fractalViewPlaceholder.TabIndex = 1;
			// 
			// FractalCompositeView2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 375);
			this.Controls.Add(this._fractalViewPlaceholder);
			this.Controls.Add(this._fractalCalculatorView);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FractalCompositeView2";
			this.Text = "FractalCompositeView2";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Panel _fractalViewPlaceholder;
		private IFS.View.FractalCalculatorView _fractalCalculatorView;
	}
}
