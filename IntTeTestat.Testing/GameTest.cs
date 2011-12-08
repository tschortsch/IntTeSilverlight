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
            IList<Player> list = generatePlayerList(3);
            Game game = new Game(list);
            Assert.AreEqual(list, game.Players);
        }
    }
}
