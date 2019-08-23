using KKSlider.Interfaces;
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
    public class AppViewModel : ObservableObject, IWindowStateChange
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
                audio.SetVolume(value);

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
        /// Backing field for the SelectedGame Property
        /// </summary>
        private string _selectedGame;
        /// <summary>
        /// Gets the value of <see cref="_selectedGame"/>, calls the <see cref="SwitchGame()"/> method and sets the value of <see cref="IsPlaying"/> to <see cref="AudioHandler"/>'s IsPlaying Property
        /// </summary>
        public string SelectedGame
        {

            get { return _selectedGame; }
            set
            {

                _selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
                game.SwitchGame(SelectedGame, GameList, audio);
                IsPlaying = audio.IsPlaying;

            }

        }

        /// <summary>
        /// Backing field for the ShowInTaskBar Property
        /// </summary>
        private bool _showInTaskbar = true;
        /// <summary>
        /// Gets the value of <see cref="_showInTaskbar"/>
        /// </summary>
        public bool ShowInTaskBar
        {

            get { return _showInTaskbar; }
            set
            {

                _showInTaskbar = value;
                OnPropertyChanged(nameof(ShowInTaskBar));

            }

        }

        /// <summary>
        /// Backing field for the WindowState Property
        /// </summary>
        private string _windowState = "Normal";
        /// <summary>
        /// Gets the value of <see cref="_windowState"/> and calls the <see cref="SetTaskBar"/> Method
        /// </summary>
        public string WindowState
        {

            get { return _windowState; }
            set
            {

                _windowState = value;
                OnPropertyChanged(nameof(WindowState));
                SetTaskBar();

            }

        }

        #endregion

        #region Fields

        /// <summary>
        /// AudioHandler object
        /// </summary>
        private readonly AudioHandler audio = new AudioHandler();
        /// <summary>
        /// GameHandler object
        /// </summary>
        private readonly GameHandler game = new GameHandler();
        /// <summary>
        /// TimerHandler object
        /// </summary>
        private readonly TimerHandler timer = new TimerHandler();
        /// <summary>
        /// NotifyHandler object
        /// </summary>
        private readonly NotifyHandler notify = new NotifyHandler();
        /// <summary>
        /// Observable collection to fill Combobox
        /// </summary>
        public ObservableCollection<string> GameList { get; private set; } = new ObservableCollection<string>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the application
        /// </summary>
        public AppViewModel()
        {

            PopulateComboBox();
            SelectedGame = GameList[(int)game.CurrentGame];

            audio.Init(game.CurrentGame);
            timer.Init(audio, game);
            notify.Init(this);

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

            audio.LoadCurrentTimeSong(game.CurrentGame);
            IsPlaying = audio.IsPlaying;

        }

        /// <summary>
        /// Method for Stop Audio Command
        /// </summary>
        private void StopAudio()
        {
            
            audio.StopAudio();
            IsPlaying = audio.IsPlaying;

        }

        /// <summary>
        /// Method to control if the window is visible in the Task Bar
        /// </summary>
        private void SetTaskBar()
        {

            if (WindowState == "Normal")
                ShowInTaskBar = true;
            else if (WindowState == "Minimized")
                ShowInTaskBar = false;

        }

        /// <summary>
        /// Method for changing the window state. Implemented via <see cref="IWindowStateChange"/>
        /// </summary>
        public void ChangeWindowState()
        {
            WindowState = "Normal";
        }

        #endregion

    }
}
