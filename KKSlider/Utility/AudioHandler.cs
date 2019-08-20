using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using KKSlider.Models;

namespace KKSlider.Utility
{
    /// <summary>
    ///  Audio Handler Class
    /// </summary>
    public class AudioHandler
    {

        #region Properties
        /// <summary>
        /// Property to determine if the audio is playing
        /// </summary>
        public bool IsPlaying { get; private set; }
        #endregion

        #region Fields
        /// <summary>
        /// MediaPlayer object
        /// </summary>
        private readonly MediaPlayer media = new MediaPlayer();
        #endregion

        #region Public Methods
        /// <summary>
        /// Constructor
        /// <example><code>Init(Game.WildWorld)</code></example>
        /// </summary>
        /// <param name="game">Game enumeration</param>
        public void Init(Game game)
        {

            media.MediaEnded += new EventHandler(Media_Ended);
            LoadCurrentTimeSong(game);
            media.Volume = 1;

        }

        /// <summary>
        /// Method to load song based on current hour
        /// </summary>
        public void LoadCurrentTimeSong(Game game)
        {

            IsPlaying = true;

            string hour = DateTime.Now.Hour < 10 ? $"0{DateTime.Now.Hour.ToString()}00" : $"{DateTime.Now.Hour.ToString()}00";
            string path = $"Resources\\Music\\{game.ToString("D")}\\{hour}.mp3";

            System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {

                media.Open(new Uri(path, UriKind.Relative));
                media.Play();

            }));

        }

        /// <summary>
        /// Method to set the audio volume
        /// </summary>
        /// <param name="v">The value of the volume</param>
        public void SetVolume(int v) => media.Volume = v / 100.0f;

        /// <summary>
        /// Method to stop audio
        /// </summary>
        public void StopAudio()
        {

            media.Stop();

            IsPlaying = false;

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// EventHandler for MediaEnded. Sets the <see cref="media"/> position back to the start and plays again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {

            media.Position = TimeSpan.Zero;
            media.Play();

        }
        #endregion

    }
}
