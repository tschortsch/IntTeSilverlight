using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using IntTeTestat.ViewModel;
using System.Windows.Data;

namespace IntTeTestat
{
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();
            WebContext.Current.GuessServiceClient.PlayerGuessReceived +=new EventHandler<GuessServiceReference.PlayerGuessReceivedEventArgs>(GuessServiceClient_PlayerGuessReceived);
        }

        void GuessServiceClient_PlayerGuessReceived(object sender, GuessServiceReference.PlayerGuessReceivedEventArgs e)
        {
            lastGuessLabel.Content = e.guess.GuessValuek__BackingField;
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void checkGuessButton_Click(object sender, RoutedEventArgs e)
        {
            WebContext.Current.GuessServiceClient.GuessAsync(int.Parse(guessTextBox.Text));
        }
    }
}
