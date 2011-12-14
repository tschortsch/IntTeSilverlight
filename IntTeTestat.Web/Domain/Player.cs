using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntTeTestat.Web.Domain
{
    public class Player
    {
        public Player(string name, IGuessService client)
        {
            Name = name;
            Client = client;
        }

        public string Name { get; set; }
        public IGuessService Client { get; set; }
        public Game Game { get; set; }

    }
}