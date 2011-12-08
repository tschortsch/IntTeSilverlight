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
        int guess;

        public Guess(int guess)
        {
            this.guess = guess;
        }
    };
}