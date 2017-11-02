using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_and_arrays
{
    public enum Suit { clubs, diamonds, hearts, spades }
    public enum Number
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    struct Card
    {
        public Number Number { get; }
        public Suit Suit { get; }
        public Card(Number number, Suit suit)
        {
            Number = number;
            Suit = suit;
        }
    } 

}
