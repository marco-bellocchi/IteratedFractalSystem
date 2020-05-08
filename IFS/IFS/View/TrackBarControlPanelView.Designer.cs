/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 01/08/2014
 * Time: 21:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace IFS.View
{
	partial class TrackBarControlPanelView
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._zoomYTb = new System.Windows.Forms.TextBox();
            this._zoomXTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._rotationYTb = new System.Windows.Forms.TextBox();
            this._rotationXTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._rotationTb = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this._zoomTb = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._yTranslationTb = new System.Windows.Forms.TrackBar();
            this._xTranslationTb = new System.Windows.Forms.TrackBar();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._rotationTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._zoomTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._yTranslationTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._xTranslationTb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this._zoomYTb);
            this.groupBox2.Controls.Add(this._zoomXTb);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this._rotationYTb);
            this.groupBox2.Controls.Add(this._rotationXTb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this._rotationTb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this._zoomTb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._yTranslationTb);
            this.groupBox2.Controls.Add(this._xTranslationTb);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 207);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this.groupBox2.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(328, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 22);
            this.label6.TabIndex = 23;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(280, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "X";
            // 
            // _zoomYTb
            // 
            this._zoomYTb.Location = new System.Drawing.Point(331, 106);
            this._zoomYTb.Name = "_zoomYTb";
            this._zoomYTb.Size = new System.Drawing.Size(40, 22);
            this._zoomYTb.TabIndex = 21;
            this._zoomYTb.Tag = "zoomy";
            this._zoomYTb.Text = "0";
            this._zoomYTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._zoomYTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _zoomXTb
            // 
            this._zoomXTb.Location = new System.Drawing.Point(284, 106);
            this._zoomXTb.Name = "_zoomXTb";
            this._zoomXTb.Size = new System.Drawing.Size(41, 22);
            this._zoomXTb.TabIndex = 20;
            this._zoomXTb.Tag = "zoomx";
            this._zoomXTb.Text = "0";
            this._zoomXTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._zoomXTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(331, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(282, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "X";
            // 
            // _rotationYTb
            // 
            this._rotationYTb.Location = new System.Drawing.Point(331, 154);
            this._rotationYTb.Name = "_rotationYTb";
            this._rotationYTb.Size = new System.Drawing.Size(40, 22);
            this._rotationYTb.TabIndex = 17;
            this._rotationYTb.Tag = "rotationy";
            this._rotationYTb.Text = "0";
            this._rotationYTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._rotationYTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _rotationXTb
            // 
            this._rotationXTb.Location = new System.Drawing.Point(285, 154);
            this._rotationXTb.Name = "_rotationXTb";
            this._rotationXTb.Size = new System.Drawing.Size(40, 22);
            this._rotationXTb.TabIndex = 16;
            this._rotationXTb.Tag = "rotationx";
            this._rotationXTb.Text = "0";
            this._rotationXTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._rotationXTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(33, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rotation";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _rotationTb
            // 
            this._rotationTb.Location = new System.Drawing.Point(110, 147);
            this._rotationTb.Maximum = 360;
            this._rotationTb.Minimum = -360;
            this._rotationTb.Name = "_rotationTb";
            this._rotationTb.Size = new System.Drawing.Size(168, 56);
            this._rotationTb.SmallChange = 5;
            this._rotationTb.TabIndex = 6;
            this._rotationTb.Tag = "rotationvalue";
            this._rotationTb.Value = 1;
            this._rotationTb.Scroll += new System.EventHandler(this._rotationTb_Scroll);
            this._rotationTb.MouseDown += new System.Windows.Forms.MouseEventHandler(this._rotationTb_MouseDown);
            this._rotationTb.MouseUp += new System.Windows.Forms.MouseEventHandler(this._rotationTb_MouseUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(56, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zoom";
            // 
            // _zoomTb
            // 
            this._zoomTb.LargeChange = 1;
            this._zoomTb.Location = new System.Drawing.Point(109, 102);
            this._zoomTb.Maximum = 100000;
            this._zoomTb.Minimum = 1;
            this._zoomTb.Name = "_zoomTb";
            this._zoomTb.Size = new System.Drawing.Size(169, 56);
            this._zoomTb.TabIndex = 4;
            this._zoomTb.Tag = "zoomvalue";
            this._zoomTb.Value = 1;
            this._zoomTb.Scroll += new System.EventHandler(this._zoomTb_Scroll);
            this._zoomTb.MouseDown += new System.Windows.Forms.MouseEventHandler(this._zoomTb_MouseDown);
            this._zoomTb.MouseUp += new System.Windows.Forms.MouseEventHandler(this._zoomTb_MouseUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y Translation";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "X Translation";
            // 
            // _yTranslationTb
            // 
            this._yTranslationTb.LargeChange = 1;
            this._yTranslationTb.Location = new System.Drawing.Point(109, 59);
            this._yTranslationTb.Maximum = 10000;
            this._yTranslationTb.Minimum = -10000;
            this._yTranslationTb.Name = "_yTranslationTb";
            this._yTranslationTb.Size = new System.Drawing.Size(169, 56);
            this._yTranslationTb.TabIndex = 3;
            this._yTranslationTb.Tag = "translationy";
            this._yTranslationTb.Value = 1;
            this._yTranslationTb.Scroll += new System.EventHandler(this._yTranslationTb_Scroll);
            this._yTranslationTb.MouseDown += new System.Windows.Forms.MouseEventHandler(this._yTranslationTb_MouseDown);
            this._yTranslationTb.MouseUp += new System.Windows.Forms.MouseEventHandler(this._yTranslationTb_MouseUp);
            // 
            // _xTranslationTb
            // 
            this._xTranslationTb.LargeChange = 1;
            this._xTranslationTb.Location = new System.Drawing.Point(108, 14);
            this._xTranslationTb.Maximum = 10000;
            this._xTranslationTb.Minimum = -10000;
            this._xTranslationTb.Name = "_xTranslationTb";
            this._xTranslationTb.Size = new System.Drawing.Size(170, 56);
            this._xTranslationTb.TabIndex = 2;
            this._xTranslationTb.Tag = "translationx";
            this._xTranslationTb.Value = 1;
            this._xTranslationTb.Scroll += new System.EventHandler(this._xTranslationTb_Scroll);
            this._xTranslationTb.MouseDown += new System.Windows.Forms.MouseEventHandler(this._xTranslationTb_MouseDown);
            this._xTranslationTb.MouseUp += new System.Windows.Forms.MouseEventHandler(this._xTranslationTb_MouseUp);
            // 
            // TrackBarControlPanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "TrackBarControlPanelView";
            this.Size = new System.Drawing.Size(384, 207);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._rotationTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._zoomTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._yTranslationTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._xTranslationTb)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar _zoomTb;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar _yTranslationTb;
		private System.Windows.Forms.TrackBar _xTranslationTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar _rotationTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _rotationYTb;
        private System.Windows.Forms.TextBox _rotationXTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _zoomYTb;
        private System.Windows.Forms.TextBox _zoomXTb;
	}
}
