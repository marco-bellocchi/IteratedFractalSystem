namespace IFS.View
{
    partial class FractalEditorView
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._listView = new System.Windows.Forms.ListView();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._applyBt = new System.Windows.Forms.Button();
            this._autoApplyCb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._autoApplyCb);
            this.splitContainer1.Panel2.Controls.Add(this._applyBt);
            this.splitContainer1.Size = new System.Drawing.Size(318, 432);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._listView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._propertyGrid);
            this.splitContainer2.Size = new System.Drawing.Size(318, 403);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 0;
            // 
            // _listView
            // 
            this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listView.Location = new System.Drawing.Point(0, 0);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(83, 403);
            this._listView.TabIndex = 0;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.List;
            this._listView.SelectedIndexChanged += new System.EventHandler(this._listView_SelectedIndexChanged);
            // 
            // _propertyGrid
            // 
            this._propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertyGrid.Location = new System.Drawing.Point(0, 0);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.Size = new System.Drawing.Size(231, 403);
            this._propertyGrid.TabIndex = 0;
            // 
            // _applyBt
            // 
            this._applyBt.Dock = System.Windows.Forms.DockStyle.Right;
            this._applyBt.Location = new System.Drawing.Point(215, 0);
            this._applyBt.Name = "_applyBt";
            this._applyBt.Size = new System.Drawing.Size(103, 25);
            this._applyBt.TabIndex = 0;
            this._applyBt.Text = "Apply";
            this._applyBt.UseVisualStyleBackColor = true;
            this._applyBt.Click += new System.EventHandler(this._applyBt_Click);
            // 
            // _autoApplyCb
            // 
            this._autoApplyCb.AutoSize = true;
            this._autoApplyCb.Dock = System.Windows.Forms.DockStyle.Right;
            this._autoApplyCb.Location = new System.Drawing.Point(72, 0);
            this._autoApplyCb.Name = "_autoApplyCb";
            this._autoApplyCb.Size = new System.Drawing.Size(143, 25);
            this._autoApplyCb.TabIndex = 1;
            this._autoApplyCb.Text = "Apply Immediately";
            this._autoApplyCb.UseVisualStyleBackColor = true;
            // 
            // FractalEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FractalEditorView";
            this.Size = new System.Drawing.Size(318, 432);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button _applyBt;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.CheckBox _autoApplyCb;
    }
}
