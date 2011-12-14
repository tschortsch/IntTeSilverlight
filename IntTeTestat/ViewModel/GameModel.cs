using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using IntTeTestat.GuessServiceReference;
using System.Collections.Specialized;

namespace IntTeTestat.ViewModel
{
    public class GameModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> players;
        private ObservableCollection<Guess> guesses;
        private GuessTipp hint;

        public GameModel()
        {
            players = new ObservableCollection<string>();
            guesses = new ObservableCollection<Guess>();
            Hint = GuessTipp.Others;
            Players.CollectionChanged += HandlePlayersChange;
            Guesses.CollectionChanged += HandleGuessesChange;
        }

        public ObservableCollection<string> Players {
            get
            {
                return players;
            }
            set
            {
                players = value;
            }
        }
        public ObservableCollection<Guess> Guesses {
            get
            {
                return guesses;
            }
            set
            {
                guesses = value;
                SendPropertyChanged("LastGuess");
            }
        }

        public string Name { get; set; }

        public Guess LastGuess {
            get
            {
                if (Guesses.Count > 0)
                {
                    return Guesses[Guesses.Count - 1];
                }
                return null;
            }
        }

        public string FinishedMessage { get; set; }

        public GuessTipp Hint {
            get
            {
                return hint;
            }
            set
            {
                hint = value;
                SendPropertyChanged("Answer");
            }
        }

        public string Answer
        {
            get
            {
                switch (Hint)
                {
                    case GuessTipp.ToHeight:
                        return "Zu hoch!";

                    case GuessTipp.ToLow:
                        return "Zu tief!";

                    default: return "";
                }
            }
        }
        
        private void HandlePlayersChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            SendPropertyChanged("Players");
        }
  
        private void HandleGuessesChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            SendPropertyChanged("Guesses");
            SendPropertyChanged("LastGuess");
        }


        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sends the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void SendPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
