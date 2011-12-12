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
        public ObservableCollection<string> Players { get; set; }
        public ObservableCollection<Guess> Guesses { get; set; }
        public string Name { get; set; }
        public Guess LastGuess {
            get
            {
                return Guesses[Guesses.Count - 1];
            }
        }

        
        public GameModel() 
        {
            //Players.CollectionChanged += HandlePlayersChange;
            Guesses.CollectionChanged += HandleGuessesChange;
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
