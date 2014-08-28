/*
 * These are the tests for the CardManager class, which 
 * is responcible for sorting and shuffling a deck.
 * 
 * Usage: run Tester.run_tests() on a Tester instance.
 */

using System;
using System.Collections.Generic;

namespace Cards {
	public class Tester {
		CardManager cardManager;

		public Tester () {
			cardManager = new CardManager ();
		}

		public void RunTests() {
			Console.WriteLine ("Running tests");
			try{
				List<Card> cards = cardManager.deck;
				if (cards == null)
					throw new Exception();
				cards = TestShuffle (cards);
				if (cards == null)
					throw new Exception();
				cards = TestSort (cards);
				if (cards == null)
					throw new Exception();	
				Console.WriteLine ("All tests succeeded");
			} catch {
				Console.WriteLine ("Error found in last ran test");
			} finally {
				Console.WriteLine ("Finished testing");
			}
		}
		
		public List<Card> TestMakeDeck() {
			try {
				Console.WriteLine ("Testing deck creation");
				List<Card> listOfCards = cardManager.MakeDeck ();
				if (listOfCards.Count < 10)
					throw new Exception();
				return listOfCards;
			} catch {
				Console.WriteLine ("Bad deck creation");
				return null;
			}
		}

		public List<Card> TestShuffle(List<Card> cards) {
			Console.WriteLine ("Testing deck shuffling");
			try {
				return cardManager.Shuffle();
			} catch {
				Console.WriteLine ("Bad deck shuffling");
				return null;
			}
		}

		public List<Card> TestSort(List<Card> cards) {
			try {
				Console.WriteLine ("Testing deck sorting");
				cards = cardManager.Sort();
				if (cards[0].CompareTo(cards[10]) > 0)
					throw new Exception();
				return cards;

			} catch {
				Console.WriteLine ("Bad deck sorting");
				return null;
			}
		}
	}
}

