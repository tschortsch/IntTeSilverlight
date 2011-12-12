using System;
using System.Runtime.Serialization;

namespace IntTeTestat.Web.Util
{
    public enum GuessTipp
    {
        ToLow,
        ToHeight,
        Correct,
        Others
    }

    [DataContract]
    public class Guess
    {
        public Guess(int guess)
        {
            Value = guess;
        }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }

        [DataMember]
        public int Value { get; set; }
    };
}