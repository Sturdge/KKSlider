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
    /// Static Audio Handler Class
    /// </summary>
    public static class AudioHandler
    {

        #region Fields
        private static readonly MediaPlayer media = new MediaPlayer();

        private static Game currentGame;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initialisation method
        /// <example><code>Init(Game.WildWorld)</code></example>
        /// </summary>
        /// <param name="game">Game enumeration</param>
        public static void Init(Game game)
        {

            currentGame = game;
            media.MediaEnded += new EventHandler(Media_Ended);
            LoadCurrentTimeSong();

        }

        /// <summary>
        /// Method to load song based on current hour
        /// </summary>
        public static void LoadCurrentTimeSong()
        {

            string current = currentGame.ToString("D");
            string hour = DateTime.Now.Hour < 10 ? $"0{DateTime.Now.Hour.ToString()}00" : $"{DateTime.Now.Hour.ToString()}00";
            string path = $"Resources\\Music\\{current}\\{hour}.mp3";

            System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {

                media.Open(new Uri(path, UriKind.Relative));
                PlayAudio();

            }));

        }
        
        /// <summary>
        /// Method to set the audio volume
        /// </summary>
        /// <param name="v">The value of the volume</param>
        public static void SetVolume(int v) => media.Volume = v / 100.0f;

        /// <summary>
        /// Method to stop audio
        /// </summary>
        public static void StopAudio() => media.Stop();

        /// <summary>
        /// Method to play audio
        /// </summary>
        public static void PlayAudio() => media.Play();
        #endregion

        #region Private Methods
        /// <summary>
        /// EventHandler for MediaEnded. Sets the <see cref="media"/> position back to the start and plays again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Media_Ended(object sender, EventArgs e)
        {

            media.Position = TimeSpan.Zero;
            media.Play();

        }
        #endregion

    }
}
