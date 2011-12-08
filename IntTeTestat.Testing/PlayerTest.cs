using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntTeTestat.Web.Domain;

namespace IntTeTestat.Testing
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerConstructorTest()
        {
            string name = "Testspieler";
            Player player = new Player(name,null);
            Assert.AreEqual(name, player.Name);
        }
    }
}
