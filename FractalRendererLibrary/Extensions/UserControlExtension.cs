using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FractalRendererLibrary.Extensions
{
    public static class UserControlExtension
    {
        public static void InvokeInUIThread(this UserControl uc, Action action)
        {
            if(uc.InvokeRequired)
                uc.Invoke(action);
            else
                action();
        }
    }
}
