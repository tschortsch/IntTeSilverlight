﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntTeTestat.Web.Util;

namespace IntTeTestat.Web.Domain
{
    public class Game
    {
        public const int MAX_PLAYER_PER_GAME = 1;
        public const int MIN_VALUE = 1;
        public const int MAX_VALUE = 10;
        private int randomInt;

        public Game(IList<Player> players)
        {
            Players = players;
            randomInt = GenerateRandomInt();
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

        private int GenerateRandomInt()
        {
            Random randomGR = new Random();
            return randomGR.Next(Game.MIN_VALUE, Game.MAX_VALUE);
        }

        public bool IsGuessCorrect(Guess g)
        {
            return GetGuessTipp(g).Equals(GuessTipp.Correct);
        }

        public GuessTipp GetGuessTipp(Guess g)
        {
            if (g.Value.CompareTo(randomInt) == 0)
            {
                return GuessTipp.Correct;
            }
            else if (g.Value.CompareTo(randomInt) > 0)
            {
                return GuessTipp.ToHeight;
            }
            else
            {
                return GuessTipp.ToLow;
            }
        }
    }
}