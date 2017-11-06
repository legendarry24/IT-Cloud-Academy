using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops_and_arrays
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum Number
    {
        Six = 6,
        Seven,
        Eight,
        Nine,
        Ten,     
        Jack,
        Lady,
        King,
        Ace
    }

    struct Card
    {
        public Number Number;
        public Suit Suit;

        public static Card[] Deck = new Card[36];
        public Card(Number number, Suit suit)
        {
            Number = number;
            Suit = suit;
        }
        
        public static Card[] GenerateDeck()
        {
            for (int i = 0; i < Deck.Length;)
            {
                foreach (var suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (var number in Enum.GetValues(typeof(Number)))
                    {
                        Deck[i] = new Card((Number)number, (Suit)suit);
                        i++;
                    }
                }
            }
            return Deck;
        }
        public static void ShuffleDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < Deck.Length; i++)
            {
                int randomIndex = rand.Next(Deck.Length);
                int randomIndex2 = rand.Next(Deck.Length);
                Card temp = Deck[randomIndex];
                Deck[randomIndex] = Deck[randomIndex2];
                Deck[randomIndex2] = temp;
            }            
        }

    } 

}
