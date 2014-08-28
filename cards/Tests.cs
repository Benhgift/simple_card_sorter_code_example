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
		
		Dictionary<string, int> suiteDict;
		Dictionary<string, int> faceDict;

		public Tester () {
			suiteDict = CardManager.MakeSuiteDict ();
			faceDict = CardManager.MakeFaceDict ();
		}

		public void RunTests() {
			Console.WriteLine ("Running tests");
			try{
				List<Card> cards = TestMakeDeck ();
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
				Dictionary<string, int> suiteDict = CardManager.MakeSuiteDict ();
				Dictionary<string, int> faceDict = CardManager.MakeFaceDict ();
				List<Card> listOfCards = CardManager.MakeDeck (suiteDict, faceDict);
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
				return CardManager.Shuffle(cards);
			} catch {
				Console.WriteLine ("Bad deck shuffling");
				return null;
			}
		}

		public List<Card> TestSort(List<Card> cards) {
			try {
				Console.WriteLine ("Testing deck sorting");
				cards = CardManager.Sort(cards, suiteDict, faceDict);
				if (cards[0].CompareTo(cards[10], suiteDict, faceDict) > 0)
					throw new Exception();
				return cards;

			} catch {
				Console.WriteLine ("Bad deck sorting");
				return null;
			}
		}
	}
}

