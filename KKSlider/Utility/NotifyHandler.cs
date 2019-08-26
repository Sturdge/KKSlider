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
        public void Init(IWindowStateChange caller, ContextMenu context)
        {

            notify.Icon = new Icon(@"Resources\Images\icon.ico");
            notify.MouseClick += delegate (Object sender, MouseEventArgs e) { IconClicked(sender, e, caller); };
            notify.Visible = true;
            notify.ContextMenu = context;

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to inform the user that the app has minimized to the system tray
        /// </summary>
        public void DisplayNotification()
        {

            notify.ShowBalloonTip(100, "KK Slider is still running in the background.", "To re-open KK Slider, click the tray icon. To close KK Slider, right-click the tray icon.", ToolTipIcon.Info);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to call the ChangeWindowState method on the <see cref="caller"/> object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconClicked(Object sender, MouseEventArgs e, IWindowStateChange caller)
        {

            if (e.Button == MouseButtons.Left)
                caller.ChangeWindowState();

        }

        #endregion

    }
}
