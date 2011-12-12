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
            if (waitingPlayers.Count >= Game.MAX_PLAYER_PER_GAME)
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
            }
        }

        private void CreateGame()
        {
            this.game = new Game(waitingPlayers.GetRange(0, Game.MAX_PLAYER_PER_GAME));
            waitingPlayers.RemoveRange(0, Game.MAX_PLAYER_PER_GAME);
            GuessService.games.Add(this.game);
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Guess(Int32 value)
        {
            _client.PlayerGuess(new Guess(value));
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void QuitConnect()
        {
            //_client.ConnectCanceled();
        }
    }

    [ServiceContract]
    public interface IGuessService
    {
        [OperationContract(IsOneWay = true)]
        void StartGame(List<string> players, string playerName);

        [OperationContract(IsOneWay = true)]
        void GameOver(bool victory, List<Guess> playedValues);

        [OperationContract(IsOneWay = true)]
        void ConnectCanceled();

        [OperationContract(IsOneWay = true)]
        void PlayerGuess(Guess guess);

    }
}
