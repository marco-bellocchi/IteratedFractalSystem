using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IFS.Presenter;

namespace IFS.View
{
    public partial class FractalEditorView : UserControl, IFractalEditorView
    {
        public event EventHandler Apply;

        public FractalEditorView()
        {
            InitializeComponent();
        }

        public void ClearTransformations()
        {
            _listView.Clear();
            _propertyGrid.SelectedObject = null;
        }

        public void AddTransformation(string name, object transformation)
        {
            var itemAdded = _listView.Items.Add(new ListViewItem(name));
            itemAdded.Tag = transformation;
        }

        public bool IsAppliedImmediatelyChecked
        {
            get
            {
                return _autoApplyCb.Checked;
            }
        }

        public UserControl UserControl { get { return this; } }

        public void ShowErrorMessage(string error)
        {
            MessageBox.Show(error, "Error");
        }

        private void _applyBt_Click(object sender, EventArgs e)
        {
            OnApply();
        }

        private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listView.SelectedItems.Count > 0)
            {
                _propertyGrid.SelectedObject = _listView.SelectedItems[0].Tag;
            }
        }

        protected virtual void OnApply()
        {
            if (Apply != null)
                Apply(this, EventArgs.Empty);
        }
    }
}
