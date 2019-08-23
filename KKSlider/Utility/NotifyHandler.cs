using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using KKSlider.ViewModels;
using KKSlider.Interfaces;

namespace KKSlider.Utility
{
    /// <summary>
    /// NotifyIcon Handler Class
    /// </summary>
    public class NotifyHandler
    {

        #region Fields

        /// <summary>
        /// NotifyIcon object
        /// </summary>
        private readonly NotifyIcon notify = new NotifyIcon();

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialisation Method
        /// </summary>
        /// <param name="avm"></param>
        public void Init(IWindowStateChange caller)
        {

            notify.Icon = new Icon(@"Resources\Images\icon.ico");
            notify.Click += delegate (Object sender, EventArgs e) { ChangeWindowState(sender, e, caller); };
            notify.Visible = true;

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to call the ChangeWindowState method on the <see cref="caller"/> object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeWindowState(Object sender, EventArgs e, IWindowStateChange caller)
        {

            caller.ChangeWindowState();

        }

        #endregion

    }
}
