using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntTeTestat.Web.Domain
{
    public class Game
    {
        public Game(IList<Player> players)
        {
            Players = players;
        }

        public List<string> PlayerNames
        {
            get
            {
                List<string> names =  new List<string>();
                foreach(Player p in Players) {
                    names.Add(p.Name);
                }
                return names;
            }
        }

        public IList<Player> Players { get; set; }
    }
}