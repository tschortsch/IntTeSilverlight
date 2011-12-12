using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntTeTestat.Web.Util;

namespace IntTeTestat.Testing
{
    [TestClass]
    public class GuessTest
    {
        [TestMethod]
        public void GuessConstructorTest()
        {
            int value = 4;
            Guess guess = new Guess(value);
            Assert.AreEqual(value, guess.Value);
 
        }
    }
}
