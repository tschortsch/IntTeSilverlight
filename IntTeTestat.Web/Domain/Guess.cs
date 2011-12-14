using System;
using System.Runtime.Serialization;
using IntTeTestat.Web.Domain;

namespace IntTeTestat.Web.Domain
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
        public Guess(int guess, string playerName)
        {
            Value = guess;
            PlayerName = playerName;
        }

        public override string ToString()
        {
            return PlayerAndGuess;
        }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public string PlayerName { get; set; }

        [DataMember]
        public string PlayerAndGuess
        {
            get { return PlayerName + ": " + Convert.ToString(Value);}
            set { throw new NotImplementedException(); }
        }

        [DataMember]
        public GuessTipp Answer { get; set; }
    };
}