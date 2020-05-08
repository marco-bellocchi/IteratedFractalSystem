namespace IFS.View
{
    partial class FractalCompilerView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._createBt = new System.Windows.Forms.Button();
            this._saveBt = new System.Windows.Forms.Button();
            this._xmlEditor = new XmlEditor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._xmlEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._createBt);
            this.splitContainer1.Panel2.Controls.Add(this._saveBt);
            this.splitContainer1.Size = new System.Drawing.Size(409, 450);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 0;
            // 
            // _createBt
            // 
            this._createBt.Dock = System.Windows.Forms.DockStyle.Right;
            this._createBt.Location = new System.Drawing.Point(245, 0);
            this._createBt.Name = "_createBt";
            this._createBt.Size = new System.Drawing.Size(89, 25);
            this._createBt.TabIndex = 3;
            this._createBt.Text = "Add Fractal";
            this._createBt.UseVisualStyleBackColor = true;
            this._createBt.Click += new System.EventHandler(this._createBt_Click);
            // 
            // _saveBt
            // 
            this._saveBt.Dock = System.Windows.Forms.DockStyle.Right;
            this._saveBt.Location = new System.Drawing.Point(334, 0);
            this._saveBt.Name = "_saveBt";
            this._saveBt.Size = new System.Drawing.Size(75, 25);
            this._saveBt.TabIndex = 1;
            this._saveBt.Text = "Save As";
            this._saveBt.UseVisualStyleBackColor = true;
            this._saveBt.Click += new System.EventHandler(this._saveBt_Click);
            // 
            // _xmlEditor
            // 
            this._xmlEditor.AllowXmlFormatting = true;
            this._xmlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._xmlEditor.Location = new System.Drawing.Point(0, 0);
            this._xmlEditor.Margin = new System.Windows.Forms.Padding(4);
            this._xmlEditor.Name = "_xmlEditor";
            this._xmlEditor.ReadOnly = false;
            this._xmlEditor.Size = new System.Drawing.Size(409, 421);
            this._xmlEditor.TabIndex = 0;
            // 
            // FractalCompilerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FractalCompilerView";
            this.Text = "Fractal Compiler Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button _createBt;
        private System.Windows.Forms.Button _saveBt;
        private XmlEditor _xmlEditor;
    }
}
