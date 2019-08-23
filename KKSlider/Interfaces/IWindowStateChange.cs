using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKSlider.Interfaces
{
    /// <summary>
    /// Interface for implementing <see cref="ChangeWindowState"/> so NotifyHandler can call it
    /// </summary>
    public interface IWindowStateChange
    {

        /// <summary>
        /// Method for changing the window state
        /// </summary>
        void ChangeWindowState();

    }
}
