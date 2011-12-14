using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Activation;
using IntTeTestat.Web.Util;
using IntTeTestat.Web.Domain;

namespace IntTeTestat.Web
{
    [ServiceContract(Namespace = "", CallbackContract = typeof(IGuessService))]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GuessService
    {
        private IGuessService _client;
        private static List<Player> waitingPlayers = new List<Player>();
        private static List<Game> games = new List<Game>();
        private Player player;
        private Game game;
        
        [OperationContract(IsOneWay = true)]
        public void Conntect()
        {
            _client = OperationContext.Current.GetCallbackChannel<IGuessService>();
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddName(string name)
        {
            this.player = new Player(name, _client);
            waitingPlayers.Add(this.player);
            if (waitingPlayers.Count >= Game.PLAYER_PER_GAME)
            {
                this.StartGame();
            }
        }

        public void StartGame()
        {
            CreateGame();
            foreach (Player p in this.game.Players)
            {
                p.Client.StartGame(this.game.PlayerNames, p.Name);
                p.Game = this.game;
            }
        }

        private void CreateGame()
        {
            List<Player> currentPlayers = waitingPlayers.GetRange(0, Game.PLAYER_PER_GAME);
            game = new Game(currentPlayers);
            waitingPlayers.RemoveRange(0, Game.PLAYER_PER_GAME);
            GuessService.games.Add(this.game);
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Guess(Int32 value, string name)
        {
            Guess guess = new Guess(value, name);
            SendGuess(guess);

            if (player.Game.IsGuessCorrect(value))
            {
                SendGameOver();
            } else {
                SendHint(guess);
            }
        }

        private void SendGuess(Guess g)
        {
            foreach (Player p in player.Game.Players)
            {
                p.Client.PlayerGuess(g);
            }
        }

        private void SendHint(Guess g)
        {
            player.Client.Hint(player.Game.GetGuessTipp(g));
        }

        private void SendGameOver()
        {
            player.Client.GameOver(true);
            foreach (Player p in player.Game.Players)
            {
                if (!p.Equals(player))
                {
                    p.Client.GameOver(false);
                }
            }
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void QuitConnect()
        {
            player.Game.Players.Remove(player);
            _client.ConnectCanceled();
        }
    }

    [ServiceContract]
    public interface IGuessService
    {
        [OperationContract(IsOneWay = true)]
        void StartGame(List<string> players, string playerName);

        [OperationContract(IsOneWay = true)]
        void GameOver(bool victory);

        [OperationContract(IsOneWay = true)]
        void ConnectCanceled();

        [OperationContract(IsOneWay = true)]
        void PlayerGuess(Guess guess);

        [OperationContract(IsOneWay = true)]
        void Hint(GuessTipp guessHint);
    }
}
