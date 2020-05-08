using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFS.View.Helpers
{
    public static class FileDialogHelper
    {
        public static bool AskForFilePathToOpen(out string filePath)
        {
            filePath = "";
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    filePath = ofd.FileName;
                    return true;
                }
            }
            return false;
        }

        public static bool AskForFilePathToSave(out string filePath)
        {
            filePath = "";
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    filePath = sfd.FileName;
                    return true;
                }
            }
            return false;
        }
    }
}
