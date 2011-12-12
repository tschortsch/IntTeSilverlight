using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntTeTestat.Web.Domain;

namespace IntTeTestat.Testing
{
    [TestClass]
    public class GuessTest
    {
        [TestMethod]
        public void GuessConstructorTest()
        {
            int value = 4;
            string playerName = "Testuser";
            Guess guess = new Guess(value, playerName);
            Assert.AreEqual(value, guess.Value);
            Assert.AreEqual(playerName, guess.PlayerName);
        }

        [TestMethod]
        public void ValueTest()
        {
            Guess guess = new Guess(0, "test");
            int testval = 99;

            guess.Value = testval;
            Assert.AreEqual(testval, guess.Value);
        }

        [TestMethod]
        public void PlayerNameTest()
        {
            Guess guess = new Guess(0, "test");
            string testname = "Some Testuser";

            guess.PlayerName = testname;
            Assert.AreEqual(testname, guess.PlayerName);
        }

        [TestMethod]
        public void PlayerAndGuessTest()
        {
            Guess guess = new Guess(33, "test");
            int testval = 99;
            string testname = "Random String";

            guess.Value = testval;
            guess.PlayerName = testname;
            Assert.AreEqual("Random String: 99", guess.PlayerAndGuess);
        }

        [TestMethod]
        public void PlayerAndGuessSetTest()
        {
            Guess guess = new Guess(33, "test");
            int testval = 99;
            string testname = "Random String";

            try
            {
                guess.PlayerAndGuess = testname + ": " + testval;
                Assert.Fail("Setting PlayerAndGuess should throw an NotImplementedException");
            }
            catch (NotImplementedException)
            {
                Assert.AreEqual("test: 33", guess.PlayerAndGuess);
            }
            catch (Exception e)
            {
                Assert.Fail("Setting PlayerAndGuess should throw an NotImplementedException, but got " + e.GetType().ToString());
            }
        }
    }
}
