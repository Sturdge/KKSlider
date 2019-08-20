using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Media;

namespace KKSlider.Utility
{
    /// <summary>
    /// Timer Handler Class
    /// </summary>
    public class TimerHandler
    {
        #region Fields
        /// <summary>
        /// Timer object
        /// </summary>
        private readonly Timer timer = new Timer();
        /// <summary>
        /// GameHandler object
        /// </summary>
        private GameHandler game;
        /// <summary>
        /// AudioHandler object
        /// </summary>
        private AudioHandler audio;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialisation method
        /// </summary>
        public void InitTimer(GameHandler g, AudioHandler a)
        {

            game = g;
            audio = a;
            timer.Interval = TimeAdjust() * 60 * 1000;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += OnTimedEvent;

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method to Adjust the Timer Interval based on the current minute
        /// </summary>
        /// <returns><see cref="TimeAdjust"/></returns>
        private int TimeAdjust()
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
        private void OnTimedEvent(Object source, ElapsedEventArgs e) => audio.LoadCurrentTimeSong(game.CurrentGame);
        #endregion

    }
}
