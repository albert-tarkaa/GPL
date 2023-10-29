using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL.Commands
{
    public class ClearCommand
    {
        private Panel panel;

        public ClearCommand(Panel panel)
        {
            this.panel = panel;
        }

        public void Execute()
        {
            panel.Invalidate(); // Clear the drawing surface
        }
    }
}
