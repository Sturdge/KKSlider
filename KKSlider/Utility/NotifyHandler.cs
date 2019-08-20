using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using KKSlider.ViewModels;

namespace KKSlider.Utility
{
    /// <summary>
    /// NotifyIcon Handler Class
    /// </summary>
    public class NotifyHandler
    {

        // TODO - Implement this better

        #region Fields
        private readonly NotifyIcon notify = new NotifyIcon();

        private AppViewModel main;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialisation Method
        /// </summary>
        /// <param name="avm"></param>
        public void Init(AppViewModel avm)
        {

            notify.Icon = new Icon(@"Resources\Images\icon.ico");
            notify.Click += new EventHandler(ChangeWindowState);
            notify.Visible = true;

            main = avm;

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method to set the Window State of the form back to "Normal" when the click event is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeWindowState(Object sender, EventArgs e)
        {

            main.WindowState = "Normal";            

        }
        #endregion

    }
}
