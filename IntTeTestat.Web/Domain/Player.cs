using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntTeTestat.Web.Domain
{
    public class Player
    {
        private string name;
        private IGuessService client;

        public Player(string name, IGuessService client)
        {
            this.name = name;
            this.client = client;
        }

        public string Name { get; set; }
        public IGuessService Client { get; set; }

    }
}