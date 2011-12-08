using System;

namespace IntTeTestat.Web.Util
{
    public enum GuessTipp
    {
        ToLow,
        ToHeight,
        Correct,
        Others
    }


    [Serializable]
    public class Guess
    {
        public Guess(int guess)
        {
            GuessValue = guess;
        }

        public int GuessValue { get; set; }
    };
}