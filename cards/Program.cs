/*
 * This file contains all the functionality for shuffling and sorting a deck
 * of cards.
 * 
 * A deck is defined as a List of Card objects, and can be generated with the 
 * CardManager.make_deck method.
 * A deck can be passed into the CardManager.shuffle method alone, but 
 * to sort it you need to also pass in the suite_dict and the face dict
 * so that it knows which cards are higher value than others. These
 * Dictionaries can be generated with Cardmanager.make_suite_dict and 
 * make_face_dict methods.
 * 
 * Use CardManager.display method to view a deck.
 */

using System;
using System.Collections.Generic;

namespace Cards {
	class MainClass {
		public static void Main (string[] args) {
			Dictionary<string, int> suiteDict = CardManager.MakeSuiteDict ();
			Dictionary<string, int> faceDict = CardManager.MakeFaceDict ();
			List<Card> ListOfCards = CardManager.MakeDeck (suiteDict, faceDict);

			ListOfCards = CardManager.Shuffle (ListOfCards);

			Console.WriteLine ("Shuffled deck");
			CardManager.Display (ListOfCards);

			ListOfCards = CardManager.Sort (ListOfCards, suiteDict, faceDict);

			Console.WriteLine ("Sorted deck");
			CardManager.Display (ListOfCards);

			Tester tester = new Tester ();
			tester.RunTests ();
		}
	}

	public class CardManager {
		public static Dictionary<string, int> MakeSuiteDict () {
			Dictionary<string, int> suiteDict = new Dictionary<string, int>();
			suiteDict.Add ("heart", 1);
			suiteDict.Add ("diamond", 2);
			suiteDict.Add ("spade", 3);
			suiteDict.Add ("club", 4);
			return suiteDict;
		}

		public static Dictionary<string, int> MakeFaceDict () {
			Dictionary<string, int> faceDict = new Dictionary<string, int>();
			faceDict.Add ("ace", 1);
			faceDict.Add ("2", 2);
			faceDict.Add ("3", 3);
			faceDict.Add ("4", 4);
			faceDict.Add ("5", 5);
			faceDict.Add ("6", 6);
			faceDict.Add ("7", 7);
			faceDict.Add ("8", 8);
			faceDict.Add ("9", 9);
			faceDict.Add ("10", 10);
			faceDict.Add ("Jack", 11);
			faceDict.Add ("Queen", 12);
			faceDict.Add ("King", 13);
			return faceDict;
		}

		public static List<Card> MakeDeck (Dictionary<string,int> suiteDict, Dictionary<string, int> faceDict) {
			List<Card> list_of_cards = new List<Card> ();
			foreach (KeyValuePair<string, int> suite in suiteDict) {
				foreach (KeyValuePair<string, int> face in faceDict) {
					list_of_cards.Add (new Card(suite.Key, face.Key));
				}
			}
			return list_of_cards;
		}

		public static void Display (List<Card> cards) {
			foreach (Card card in cards) {
				Console.WriteLine ("Card -- suite: " + card.suite + ", face: " + card.face);
			}
		}

		public static List<Card> Sort (List<Card> cards, Dictionary<string,int> suiteDict, Dictionary<string, int> faceDict) {
			cards.Sort(delegate(Card x, Card y) {
				return x.CompareTo(y, suiteDict, faceDict);
			});
			return cards;
		}

		public static List<Card> Shuffle (List<Card> cards) {
			return CardManager.Shuffler (cards);
		}

		static List<T> Shuffler<T>(List<T> list) {  
			Random rng = new Random();  
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = rng.Next(n + 1);  
				T value = list[k];  
				list[k] = list[n];  
				list[n] = value;  
			}  
			return list;
		}
	}

	public class Card {
		public string suite { get; set; }
		public string face { get; set; }

		public Card(string pSuite, string pFace) {
			suite = pSuite;
			face = pFace;
		}

		public int CompareTo(Card otherCard, Dictionary<string,int> suiteDict, Dictionary<string, int> faceDict) {
			int ourSuite = suiteDict [this.suite];
			int theirSuite = suiteDict [otherCard.suite];
			int theirFace = faceDict [this.face];
			int ourFace = faceDict [otherCard.face];

			if (theirSuite > ourSuite)
				return -1;
			else if (theirSuite < ourSuite)
				return 1;
			else {
				if (theirFace > ourFace)
					return 1;
				else if (theirFace < ourFace)
					return -1;
				else
					return 0;
			}
		}
	}
}
