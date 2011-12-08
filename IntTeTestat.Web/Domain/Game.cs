using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntTeTestat.Web.Domain
{
    public class Game
    {
        IList<Player> players = new List<Player>();

        public Game(IList<Player> players)
        {
            this.players = players;
        }

        public List<string> PlayerNames
        {
            get
            {
                List<string> names =  new List<string>();
                foreach(Player p in players) {
                    names.Add(p.Name);
                }
                return names;
            }
        }

        public IList<Player> Players { get; set; }
    }
}