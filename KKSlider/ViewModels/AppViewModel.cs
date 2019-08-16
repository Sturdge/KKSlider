using KKSlider.Models;
using KKSlider.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KKSlider.ViewModels
{
    /// <summary>
    /// The View Model for the application
    /// </summary>
    public class AppViewModel : ObservableObject
    {

        #region Commands
        /// <summary>
        /// Stop Audio Command
        /// </summary>
        public ICommand StopAudioCommand { get; }
        /// <summary>
        /// Play Audio Command
        /// </summary>
        public ICommand PlayAudioCommand { get; }
        #endregion

        #region Properties
        /// <summary>
        /// Backing field for Volume Property
        /// </summary>
        private int _volume = 100;
        /// <summary>
        /// Gets the value of <see cref="_volume"/> and calls the <see cref="AudioHandler.SetVolume(int)"/> method
        /// </summary>
        public int Volume
        {
            get { return _volume; }
            set
            {

                _volume = value;
                OnPropertyChanged(nameof(Volume));
                AudioHandler.SetVolume(value);

            }
        }

        /// <summary>
        /// Backing field for the IsPlaying Property
        /// </summary>
        private bool _isPlaying = true;
        /// <summary>
        /// Gets the value of <see cref="_isPlaying"/>
        /// </summary>
        public bool IsPlaying
        {

            get { return _isPlaying; }
            private set
            {

                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));

            }

        }

        /// <summary>
        /// Observable collection to fill Combobox
        /// </summary>
        public ObservableCollection<string> GameList { get; private set; } = new ObservableCollection<string>();

        /// <summary>
        /// Backing field for the SelectedGame Property
        /// </summary>
        private string _selectedGame;
        /// <summary>
        /// Gets the value of <see cref="_selectedGame"/> and calls the <see cref="SwitchGame()"/> method
        /// </summary>
        public string SelectedGame
        {

            get { return _selectedGame; }
            set
            {

                _selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
                SwitchGame();

            }

        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the application
        /// </summary>
        public AppViewModel()
        {

            AudioHandler.Init(Game.WildWorld);
            TimerHandler.InitTimer();

            PopulateComboBox();
            SelectedGame = GameList[1];

            PlayAudioCommand = new RelayCommand(PlayAudio);
            StopAudioCommand = new RelayCommand(StopAudio);

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Populate the Combobox with Strings
        /// </summary>
        private void PopulateComboBox()
        {

            GameList.Add("Animal Crossing");
            GameList.Add("Animal Crossing: Wild World/City Folk");
            GameList.Add("Animal Crossing: New Leaf");

        }

        /// <summary>
        /// Method for Play Audio Command
        /// </summary>
        private void PlayAudio()
        {

            IsPlaying = true;
            AudioHandler.LoadCurrentTimeSong();

        }

        /// <summary>
        /// Method for Stop Audio Command
        /// </summary>
        private void StopAudio()
        {

            IsPlaying = false;
            AudioHandler.StopAudio();

        }

        /// <summary>
        /// Method for switching the selected game
        /// </summary>
        private void SwitchGame()
        {

            if (SelectedGame == GameList[0])
                AudioHandler.Init(Game.AnimalCrossing);
            else if (SelectedGame == GameList[1])
                AudioHandler.Init(Game.WildWorld);
            else if (SelectedGame == GameList[2])
                AudioHandler.Init(Game.NewLeaf);

            IsPlaying = true;

        }
        #endregion

    }
}
