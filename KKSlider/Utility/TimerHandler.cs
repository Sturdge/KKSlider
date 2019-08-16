using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Media;

namespace KKSlider.Utility
{
    /// <summary>
    /// Static Timer Handler Class
    /// </summary>
    public static class TimerHandler
    {

        #region Fields
        /// <summary>
        /// Timer field
        /// </summary>
        private static readonly Timer timer = new Timer()
        {

            Interval = TimeAdjust() * 60 * 1000,
            AutoReset = true,
            Enabled = true

        };
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialisation method
        /// </summary>
        public static void InitTimer()
        {

            timer.Elapsed += OnTimedEvent;

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method to Adjust the Timer Interval based on the current minute
        /// </summary>
        /// <returns><see cref="TimeAdjust"/></returns>
        private static int TimeAdjust()
        {

            int minute = DateTime.Now.Minute;
            int adjust = 10 - (minute % 10);

            return adjust;

        }

        /// <summary>
        /// EventHandler for the OnTimedEvent event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(Object source, ElapsedEventArgs e) => AudioHandler.LoadCurrentTimeSong();
        #endregion

    }
}
