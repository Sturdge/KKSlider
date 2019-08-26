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
        /// Autoprop for the Current Game
        /// </summary>
        public Game CurrentGame { get; private set; }

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
