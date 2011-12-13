using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntTeTestat.Web.Domain;

namespace IntTeTestat.Testing
{
    [TestClass()]
    public class GameTest
    {
        public Player generatePlayer()
        {
            return new Player("Testplayer",null);
        }

        public IList<Player> generatePlayerList(int count)
        {
            IList<Player> playerList = new List<Player>();
            for (int i = 0; i < count; i++)
            {
                playerList.Add(generatePlayer());
            }
            return playerList;
        }

        [TestMethod]
        public void GameConstructorTest()
        {
            IList<Player> list = generatePlayerList(Game.PLAYER_PER_GAME);
            Game game = new Game(list);
            Assert.AreEqual(list, game.Players);
        }

        [TestMethod]
        public void PlayerNamesTest()
        {
            IList<Player> playerList = new List<Player>();
            playerList.Add(new Player("Test1", null));
            playerList.Add(new Player("Test2", null));
            playerList.Add(new Player("Test3", null));

            IList<string> nameList = new List<string>();
            nameList.Add("Test1");
            nameList.Add("Test2");
            nameList.Add("Test3");

            Game game = new Game(playerList);

            int i = 0;
            foreach (string name in nameList)
            {
                Assert.AreEqual(name, game.PlayerNames[i++]);
            }
            
        }

        [TestMethod]
        public void IsGuessCorrectTest()
        {
            Game game = new Game(generatePlayerList(1));
            int value = 2;
            game.RandomInt = value;

            Assert.IsTrue(game.IsGuessCorrect(new Guess(value, "test")));
        }

        [TestMethod]
        public void GetGuessTippCorrectTest()
        {
            Game game = new Game(generatePlayerList(1));
            int value = 2;
            game.RandomInt = value;

            Assert.AreEqual(GuessTipp.Correct, game.GetGuessTipp(new Guess(value, "test")));
        }

        [TestMethod]
        public void GetGuessTippTooLowTest()
        {
            Game game = new Game(generatePlayerList(1));
            int value = 2;
            game.RandomInt = value;

            Assert.AreEqual(GuessTipp.ToLow, game.GetGuessTipp(new Guess(value - 1, "test")));
        }

        [TestMethod]
        public void GetGuessTippTooHighTest()
        {
            Game game = new Game(generatePlayerList(1));
            int value = 2;
            game.RandomInt = value;

            Assert.AreEqual(GuessTipp.ToHeight, game.GetGuessTipp(new Guess(value + 1, "test")));
        }
    }
}
