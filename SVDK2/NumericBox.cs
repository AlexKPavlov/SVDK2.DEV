using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVDK2
{
    class NumericBox : System.Windows.Forms.NumericUpDown
    {
        public NumericBox()
        {
            Controls.Remove(Controls[0]);
        }
    }

}
