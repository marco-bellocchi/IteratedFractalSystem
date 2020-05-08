namespace IFS.View
{
    partial class FractalCalculatorView
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
            this._calculateBt = new System.Windows.Forms.Button();
            this._pointsToCalulateTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._resetBt = new System.Windows.Forms.Button();
            this._calcDimBt = new System.Windows.Forms.Button();
            this._clearPointsBt = new System.Windows.Forms.Button();
            this._calculatingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _calculateBt
            // 
            this._calculateBt.Location = new System.Drawing.Point(307, 2);
            this._calculateBt.Name = "_calculateBt";
            this._calculateBt.Size = new System.Drawing.Size(155, 27);
            this._calculateBt.TabIndex = 0;
            this._calculateBt.Text = "Iterate and Add Points";
            this._calculateBt.UseVisualStyleBackColor = true;
            this._calculateBt.Click += new System.EventHandler(this._calculateBt_Click);
            // 
            // _pointsToCalulateTb
            // 
            this._pointsToCalulateTb.Location = new System.Drawing.Point(119, 4);
            this._pointsToCalulateTb.Name = "_pointsToCalulateTb";
            this._pointsToCalulateTb.Size = new System.Drawing.Size(182, 22);
            this._pointsToCalulateTb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Num Of Points:";
            // 
            // _resetBt
            // 
            this._resetBt.Location = new System.Drawing.Point(468, 2);
            this._resetBt.Name = "_resetBt";
            this._resetBt.Size = new System.Drawing.Size(161, 27);
            this._resetBt.TabIndex = 3;
            this._resetBt.Text = "Reset Transformations";
            this._resetBt.UseVisualStyleBackColor = true;
            this._resetBt.Click += new System.EventHandler(this._resetBt_Click);
            // 
            // _calcDimBt
            // 
            this._calcDimBt.Location = new System.Drawing.Point(635, 3);
            this._calcDimBt.Name = "_calcDimBt";
            this._calcDimBt.Size = new System.Drawing.Size(139, 27);
            this._calcDimBt.TabIndex = 4;
            this._calcDimBt.Text = "Calc Dimension";
            this._calcDimBt.UseVisualStyleBackColor = true;
            this._calcDimBt.Click += new System.EventHandler(this._calcDimBt_Click);
            // 
            // _clearPointsBt
            // 
            this._clearPointsBt.Location = new System.Drawing.Point(780, 2);
            this._clearPointsBt.Name = "_clearPointsBt";
            this._clearPointsBt.Size = new System.Drawing.Size(99, 27);
            this._clearPointsBt.TabIndex = 5;
            this._clearPointsBt.Text = "Clear points";
            this._clearPointsBt.UseVisualStyleBackColor = true;
            this._clearPointsBt.Click += new System.EventHandler(this._clearPointsBt_Click);
            // 
            // _calculatingLabel
            // 
            this._calculatingLabel.AutoSize = true;
            this._calculatingLabel.Font = new System.Drawing.Font("Verdana", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._calculatingLabel.Location = new System.Drawing.Point(123, 29);
            this._calculatingLabel.Name = "_calculatingLabel";
            this._calculatingLabel.Size = new System.Drawing.Size(0, 12);
            this._calculatingLabel.TabIndex = 6;
            // 
            // FractalCalculatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._calculatingLabel);
            this.Controls.Add(this._clearPointsBt);
            this.Controls.Add(this._calcDimBt);
            this.Controls.Add(this._resetBt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._pointsToCalulateTb);
            this.Controls.Add(this._calculateBt);
            this.Name = "FractalCalculatorView";
            this.Size = new System.Drawing.Size(946, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _calculateBt;
        private System.Windows.Forms.TextBox _pointsToCalulateTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _resetBt;
        private System.Windows.Forms.Button _calcDimBt;
        private System.Windows.Forms.Button _clearPointsBt;
        private System.Windows.Forms.Label _calculatingLabel;
    }
}
