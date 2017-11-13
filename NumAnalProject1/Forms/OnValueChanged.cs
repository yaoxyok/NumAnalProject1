using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumAnalProject1.Forms
{
    /// <summary>
    /// Interface for image refresh
    /// </summary>
    interface OnValueChanged
    {
        /// <summary>
        /// Handler for recalculation and refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Refresh(object sender, EventArgs e);
    }
}
