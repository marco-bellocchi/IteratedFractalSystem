/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 29/07/2014
 * Time: 22:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace IFS
{
	partial class MainForm2
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._fractalsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this._newFractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this._predefinedFractalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._trackBarsControlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._numbersControlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this._fractalEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.fractalDataGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._renderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._gdiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openGLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._3dSierpinskiCarpetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._3dJuliaSetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutIFS10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._fractalsToolStripMenuItem1,
            this.viewToolStripMenuItem,
            this._optionToolStripMenuItem,
            this._extraToolStripMenuItem,
            this._aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1065, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newDocumentToolStripMenuItem,
            this._openDocumentToolStripMenuItem,
            this._saveDocumentToolStripMenuItem,
            this._saveAsDocumentToolStripMenuItem,
            this.toolStripMenuItem1,
            this._exitToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _newDocumentToolStripMenuItem
            // 
            this._newDocumentToolStripMenuItem.Name = "_newDocumentToolStripMenuItem";
            this._newDocumentToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this._newDocumentToolStripMenuItem.Text = "New";
            this._newDocumentToolStripMenuItem.Click += new System.EventHandler(this._newDocumentToolStripMenuItem_Click);
            // 
            // _openDocumentToolStripMenuItem
            // 
            this._openDocumentToolStripMenuItem.Name = "_openDocumentToolStripMenuItem";
            this._openDocumentToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this._openDocumentToolStripMenuItem.Text = "Open";
            this._openDocumentToolStripMenuItem.Click += new System.EventHandler(this._openDocumentToolStripMenuItem_Click);
            // 
            // _saveDocumentToolStripMenuItem
            // 
            this._saveDocumentToolStripMenuItem.Name = "_saveDocumentToolStripMenuItem";
            this._saveDocumentToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this._saveDocumentToolStripMenuItem.Text = "Save";
            this._saveDocumentToolStripMenuItem.Click += new System.EventHandler(this._saveDocumentToolStripMenuItem_Click);
            // 
            // _saveAsDocumentToolStripMenuItem
            // 
            this._saveAsDocumentToolStripMenuItem.Name = "_saveAsDocumentToolStripMenuItem";
            this._saveAsDocumentToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this._saveAsDocumentToolStripMenuItem.Text = "Save As";
            this._saveAsDocumentToolStripMenuItem.Click += new System.EventHandler(this._saveAsDocumentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this._exitToolStripMenuItem.Text = "Exit";
            this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
            // 
            // _fractalsToolStripMenuItem1
            // 
            this._fractalsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newFractalToolStripMenuItem,
            this._openFractalToolStripMenuItem,
            this.toolStripMenuItem2,
            this._predefinedFractalsToolStripMenuItem});
            this._fractalsToolStripMenuItem1.Name = "_fractalsToolStripMenuItem1";
            this._fractalsToolStripMenuItem1.Size = new System.Drawing.Size(71, 24);
            this._fractalsToolStripMenuItem1.Text = "Fractals";
            // 
            // _newFractalToolStripMenuItem
            // 
            this._newFractalToolStripMenuItem.Name = "_newFractalToolStripMenuItem";
            this._newFractalToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this._newFractalToolStripMenuItem.Text = "New";
            this._newFractalToolStripMenuItem.Click += new System.EventHandler(this._newFractalToolStripMenuItem_Click);
            // 
            // _openFractalToolStripMenuItem
            // 
            this._openFractalToolStripMenuItem.Name = "_openFractalToolStripMenuItem";
            this._openFractalToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this._openFractalToolStripMenuItem.Text = "Open";
            this._openFractalToolStripMenuItem.Click += new System.EventHandler(this._openFractalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // _predefinedFractalsToolStripMenuItem
            // 
            this._predefinedFractalsToolStripMenuItem.Name = "_predefinedFractalsToolStripMenuItem";
            this._predefinedFractalsToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this._predefinedFractalsToolStripMenuItem.Text = "Predefined";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._trackBarsControlPanelToolStripMenuItem,
            this._numbersControlPanelToolStripMenuItem,
            this.toolStripMenuItem3,
            this._fractalEditorToolStripMenuItem,
            this.toolStripMenuItem4,
            this.fractalDataGridToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // _trackBarsControlPanelToolStripMenuItem
            // 
            this._trackBarsControlPanelToolStripMenuItem.Name = "_trackBarsControlPanelToolStripMenuItem";
            this._trackBarsControlPanelToolStripMenuItem.Size = new System.Drawing.Size(277, 24);
            this._trackBarsControlPanelToolStripMenuItem.Text = "TrackBars Control Panel";
            this._trackBarsControlPanelToolStripMenuItem.Click += new System.EventHandler(this._trackBarsControlPanelToolStripMenuItemClick);
            // 
            // _numbersControlPanelToolStripMenuItem
            // 
            this._numbersControlPanelToolStripMenuItem.Name = "_numbersControlPanelToolStripMenuItem";
            this._numbersControlPanelToolStripMenuItem.Size = new System.Drawing.Size(277, 24);
            this._numbersControlPanelToolStripMenuItem.Text = "Numbers Control Panel";
            this._numbersControlPanelToolStripMenuItem.Click += new System.EventHandler(this._numbersControlPanelToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(274, 6);
            // 
            // _fractalEditorToolStripMenuItem
            // 
            this._fractalEditorToolStripMenuItem.Name = "_fractalEditorToolStripMenuItem";
            this._fractalEditorToolStripMenuItem.Size = new System.Drawing.Size(277, 24);
            this._fractalEditorToolStripMenuItem.Text = "Fractal Transformations Editor";
            this._fractalEditorToolStripMenuItem.Click += new System.EventHandler(this._fractalEditorToolStripMenuItemClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(274, 6);
            // 
            // fractalDataGridToolStripMenuItem
            // 
            this.fractalDataGridToolStripMenuItem.Name = "fractalDataGridToolStripMenuItem";
            this.fractalDataGridToolStripMenuItem.Size = new System.Drawing.Size(277, 24);
            this.fractalDataGridToolStripMenuItem.Text = "Fractal Data Grid";
            this.fractalDataGridToolStripMenuItem.Click += new System.EventHandler(this.fractalDataGridToolStripMenuItem_Click);
            // 
            // _optionToolStripMenuItem
            // 
            this._optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._renderingToolStripMenuItem});
            this._optionToolStripMenuItem.Name = "_optionToolStripMenuItem";
            this._optionToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this._optionToolStripMenuItem.Text = "Tools";
            // 
            // _renderingToolStripMenuItem
            // 
            this._renderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._gdiToolStripMenuItem,
            this._openGLToolStripMenuItem});
            this._renderingToolStripMenuItem.Name = "_renderingToolStripMenuItem";
            this._renderingToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this._renderingToolStripMenuItem.Text = "Rendering";
            // 
            // _gdiToolStripMenuItem
            // 
            this._gdiToolStripMenuItem.Name = "_gdiToolStripMenuItem";
            this._gdiToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this._gdiToolStripMenuItem.Text = "GDI";
            this._gdiToolStripMenuItem.Click += new System.EventHandler(this._gdiToolStripMenuItem_Click);
            // 
            // _openGLToolStripMenuItem
            // 
            this._openGLToolStripMenuItem.Name = "_openGLToolStripMenuItem";
            this._openGLToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this._openGLToolStripMenuItem.Text = "OpenGL";
            this._openGLToolStripMenuItem.Click += new System.EventHandler(this._openGLToolStripMenuItem_Click);
            // 
            // _extraToolStripMenuItem
            // 
            this._extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._3dSierpinskiCarpetToolStripMenuItem,
            this._3dJuliaSetoolStripMenuItem});
            this._extraToolStripMenuItem.Name = "_extraToolStripMenuItem";
            this._extraToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this._extraToolStripMenuItem.Text = "Extra";
            // 
            // _3dSierpinskiCarpetToolStripMenuItem
            // 
            this._3dSierpinskiCarpetToolStripMenuItem.Name = "_3dSierpinskiCarpetToolStripMenuItem";
            this._3dSierpinskiCarpetToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this._3dSierpinskiCarpetToolStripMenuItem.Text = "3D Sierpinski Carpet";
            this._3dSierpinskiCarpetToolStripMenuItem.Click += new System.EventHandler(this.dSierpinskiCarpetToolStripMenuItem_Click);
            // 
            // _3dJuliaSetoolStripMenuItem
            // 
            this._3dJuliaSetoolStripMenuItem.Name = "_3dJuliaSetoolStripMenuItem";
            this._3dJuliaSetoolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this._3dJuliaSetoolStripMenuItem.Text = "3D Julia Set";
            this._3dJuliaSetoolStripMenuItem.Click += new System.EventHandler(this.dJULIASToolStripMenuItem_Click);
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutIFS10ToolStripMenuItem});
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this._aboutToolStripMenuItem.Text = "Help";
            // 
            // _aboutIFS10ToolStripMenuItem
            // 
            this._aboutIFS10ToolStripMenuItem.Name = "_aboutIFS10ToolStripMenuItem";
            this._aboutIFS10ToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this._aboutIFS10ToolStripMenuItem.Text = "About IFS 1.0";
            this._aboutIFS10ToolStripMenuItem.Click += new System.EventHandler(this._aboutIFS10ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1065, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _dockPanel
            // 
            this._dockPanel.ActiveAutoHideContent = null;
            this._dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dockPanel.DockBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._dockPanel.Location = new System.Drawing.Point(0, 28);
            this._dockPanel.Name = "_dockPanel";
            this._dockPanel.Size = new System.Drawing.Size(1065, 441);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this._dockPanel.Skin = dockPanelSkin1;
            this._dockPanel.TabIndex = 3;
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 491);
            this.Controls.Add(this._dockPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IFS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem fractalDataGridToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _trackBarsControlPanelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _numbersControlPanelToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem _fractalEditorToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private WeifenLuo.WinFormsUI.Docking.DockPanel _dockPanel;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _renderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _gdiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openGLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _3dSierpinskiCarpetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _3dJuliaSetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutIFS10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _fractalsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _newFractalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openFractalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem _predefinedFractalsToolStripMenuItem;// 
      
	}
}
