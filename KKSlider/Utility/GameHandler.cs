using KKSlider.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKSlider.Utility
{
    public class GameHandler
    {

        /// <summary>
        /// Backing field for the CurrentGame Property
        /// </summary>
        private Game _currentGame;
        /// <summary>
        /// Gets the value of <see cref=_currentGame"/>
        /// </summary>
        public Game CurrentGame
        {

            get { return _currentGame; }
            private set
            {
                _currentGame = value;
            }

        }

        /// <summary>
        /// Method for switching the selected game
        /// </summary>
        public void SwitchGame(string selectedGame, ObservableCollection<String> gameList, AudioHandler audio)
        {

            if (selectedGame == gameList[0])
                CurrentGame = Game.AnimalCrossing;
            else if (selectedGame == gameList[1])
                CurrentGame = Game.WildWorld;
            else if (selectedGame == gameList[2])
                CurrentGame = Game.NewLeaf;

            audio.LoadCurrentTimeSong(CurrentGame);

        }

    }
}
