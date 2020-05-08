namespace IFS.View
{
    partial class NumbersControlPanelView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._xTranslationTb = new System.Windows.Forms.TextBox();
            this._yTranslationTb = new System.Windows.Forms.TextBox();
            this._zoomTb = new System.Windows.Forms.TextBox();
            this._applyBt = new System.Windows.Forms.Button();
            this._rotationTb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._zoomYTb = new System.Windows.Forms.TextBox();
            this._zoomXTb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._rotationYTb = new System.Windows.Forms.TextBox();
            this._rotationXTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y Translation";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "X Translation";
            // 
            // _xTranslationTb
            // 
            this._xTranslationTb.Location = new System.Drawing.Point(119, 19);
            this._xTranslationTb.Name = "_xTranslationTb";
            this._xTranslationTb.Size = new System.Drawing.Size(100, 22);
            this._xTranslationTb.TabIndex = 9;
            this._xTranslationTb.Tag = "translationx";
            this._xTranslationTb.Text = "0";
            this._xTranslationTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._xTranslationTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _yTranslationTb
            // 
            this._yTranslationTb.Location = new System.Drawing.Point(119, 50);
            this._yTranslationTb.Name = "_yTranslationTb";
            this._yTranslationTb.Size = new System.Drawing.Size(100, 22);
            this._yTranslationTb.TabIndex = 10;
            this._yTranslationTb.Tag = "translationy";
            this._yTranslationTb.Text = "0";
            this._yTranslationTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._yTranslationTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _zoomTb
            // 
            this._zoomTb.Location = new System.Drawing.Point(57, 37);
            this._zoomTb.Name = "_zoomTb";
            this._zoomTb.Size = new System.Drawing.Size(100, 22);
            this._zoomTb.TabIndex = 11;
            this._zoomTb.Tag = "zoomvalue";
            this._zoomTb.Text = "1";
            this._zoomTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._zoomTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _applyBt
            // 
            this._applyBt.Location = new System.Drawing.Point(11, 275);
            this._applyBt.Name = "_applyBt";
            this._applyBt.Size = new System.Drawing.Size(100, 28);
            this._applyBt.TabIndex = 12;
            this._applyBt.Text = "Apply";
            this._applyBt.UseVisualStyleBackColor = true;
            this._applyBt.Click += new System.EventHandler(this._applyBt_Click);
            // 
            // _rotationTb
            // 
            this._rotationTb.Location = new System.Drawing.Point(60, 34);
            this._rotationTb.Name = "_rotationTb";
            this._rotationTb.Size = new System.Drawing.Size(100, 22);
            this._rotationTb.TabIndex = 14;
            this._rotationTb.Tag = "rotationvalue";
            this._rotationTb.Text = "0";
            this._rotationTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._rotationTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._zoomYTb);
            this.groupBox1.Controls.Add(this._zoomXTb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._zoomTb);
            this.groupBox1.Location = new System.Drawing.Point(13, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 87);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zoom";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(173, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(173, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "X";
            // 
            // _zoomYTb
            // 
            this._zoomYTb.Location = new System.Drawing.Point(201, 55);
            this._zoomYTb.Name = "_zoomYTb";
            this._zoomYTb.Size = new System.Drawing.Size(99, 22);
            this._zoomYTb.TabIndex = 13;
            this._zoomYTb.Tag = "zoomy";
            this._zoomYTb.Text = "0";
            this._zoomYTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._zoomYTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _zoomXTb
            // 
            this._zoomXTb.Location = new System.Drawing.Point(201, 27);
            this._zoomXTb.Name = "_zoomXTb";
            this._zoomXTb.Size = new System.Drawing.Size(99, 22);
            this._zoomXTb.TabIndex = 12;
            this._zoomXTb.Tag = "zoomx";
            this._zoomXTb.Text = "0";
            this._zoomXTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._zoomXTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this._rotationTb);
            this.groupBox2.Controls.Add(this._rotationYTb);
            this.groupBox2.Controls.Add(this._rotationXTb);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(13, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 87);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotation";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(173, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 22);
            this.label7.TabIndex = 15;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(173, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "X";
            // 
            // _rotationYTb
            // 
            this._rotationYTb.Location = new System.Drawing.Point(201, 48);
            this._rotationYTb.Name = "_rotationYTb";
            this._rotationYTb.Size = new System.Drawing.Size(99, 22);
            this._rotationYTb.TabIndex = 13;
            this._rotationYTb.Tag = "rotationy";
            this._rotationYTb.Text = "0";
            this._rotationYTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._rotationYTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // _rotationXTb
            // 
            this._rotationXTb.Location = new System.Drawing.Point(201, 20);
            this._rotationXTb.Name = "_rotationXTb";
            this._rotationXTb.Size = new System.Drawing.Size(99, 22);
            this._rotationXTb.TabIndex = 12;
            this._rotationXTb.Tag = "rotationx";
            this._rotationXTb.Text = "0";
            this._rotationXTb.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingFieldHandler);
            this._rotationXTb.Validated += new System.EventHandler(this.ValidatedFieldHandler);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Value";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this._xTranslationTb);
            this.groupBox3.Controls.Add(this._yTranslationTb);
            this.groupBox3.Location = new System.Drawing.Point(13, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 83);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Translation";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // NumbersControlPanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._applyBt);
            this.Name = "NumbersControlPanelView";
            this.Size = new System.Drawing.Size(333, 314);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _xTranslationTb;
        private System.Windows.Forms.TextBox _yTranslationTb;
        private System.Windows.Forms.TextBox _zoomTb;
        private System.Windows.Forms.Button _applyBt;
        private System.Windows.Forms.TextBox _rotationTb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _zoomYTb;
        private System.Windows.Forms.TextBox _zoomXTb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _rotationYTb;
        private System.Windows.Forms.TextBox _rotationXTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
