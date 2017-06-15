using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    public class Card
    {
        public string Suite { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        
        public Card(string value)
        {
            Value = value;
        }
    }
   
    class Program
    {
       
        static void Main(string[] args)
        {
            var Deck = OrderedDeck();
            Console.WriteLine("Get a free Deck of Cards! 1: Type 1 for ordered Deck. 2: Type 2 for shuffled deck");
            string deckChoice = Console.ReadLine();
            if(deckChoice == "1")
            {
                Deck.Select(x => x.Name).ToList().ForEach(Console.WriteLine);
             
            } else if(deckChoice == "2")
            {
                Console.WriteLine("Shuffled Deck it is!");
            } else
            {
                Console.WriteLine("You only get a deck if you follow instructions...");
            }
            Console.ReadLine();
        }
        static List<Card> OrderedDeck()
        {
            var suites = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
            var suiteNumbers = new List<string> { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var suiteCards = new List<Card> { };
            var thisDeck = new List<Card> { };
            for (var i = 0; i < 13; i++)
            {
                var thisCard = new Card(suiteNumbers[i]);
                suiteCards.Add(thisCard);
                Console.WriteLine(suiteNumbers[i]);
            }
            for (var i = 0; i < 4; i++)
            {
                List<Card> thisSuite = suiteCards.Select(x => { x.Suite = suites[i]; x.Name = x.Value + " of " + x.Suite; return x; }).ToList();
                Debug.WriteLine(thisSuite);
                thisDeck.AddRange(thisSuite);
            }
            return thisDeck;

        }
    }
}