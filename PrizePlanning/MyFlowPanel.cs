using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrizePlanning
{
    class MyFlowPanel : System.Windows.Forms.FlowLayoutPanel
    {
        public MyFlowPanel()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }
    }
}
