using System;
using System.Collections.Generic;

namespace cards {
	class MainClass {
		public static void Main (string[] args) {
			Dictionary<string, int> suite_dict = CardManager.make_suite_dict ();
			Dictionary<string, int> face_dict = CardManager.make_face_dict ();
			List<Card> list_of_cards = CardManager.make_deck (suite_dict, face_dict);

			list_of_cards = CardManager.shuffle (list_of_cards);

			Console.WriteLine ("Shuffled deck");
			CardManager.display (list_of_cards);

			list_of_cards = CardManager.sort (list_of_cards, suite_dict, face_dict);

			Console.WriteLine ("Sorted deck");
			CardManager.display (list_of_cards);

			Tester tester = new Tester ();
			tester.run_tests ();
		}
	}

	public class CardManager {
		public static Dictionary<string, int> make_suite_dict () {
			Dictionary<string, int> suite_dict = new Dictionary<string, int>();
			suite_dict.Add ("heart", 1);
			suite_dict.Add ("diamond", 2);
			suite_dict.Add ("spade", 3);
			suite_dict.Add ("club", 4);
			return suite_dict;
		}

		public static Dictionary<string, int> make_face_dict () {
			Dictionary<string, int> face_dict = new Dictionary<string, int>();
			face_dict.Add ("ace", 1);
			face_dict.Add ("2", 2);
			face_dict.Add ("3", 3);
			face_dict.Add ("4", 4);
			face_dict.Add ("5", 5);
			face_dict.Add ("6", 6);
			face_dict.Add ("7", 7);
			face_dict.Add ("8", 8);
			face_dict.Add ("9", 9);
			face_dict.Add ("10", 10);
			face_dict.Add ("Jack", 11);
			face_dict.Add ("Queen", 12);
			face_dict.Add ("King", 13);
			return face_dict;
		}

		public static List<Card> make_deck (Dictionary<string,int> suite_dict, Dictionary<string, int> face_dict) {
			List<Card> list_of_cards = new List<Card> ();
			foreach (KeyValuePair<string, int> suite in suite_dict) {
				foreach (KeyValuePair<string, int> face in face_dict) {
					list_of_cards.Add (new Card(suite.Key, face.Key));
				}
			}
			return list_of_cards;
		}

		public static void display (List<Card> cards) {
			foreach (Card card in cards) {
				Console.WriteLine ("Card -- suite: " + card.suite + ", face: " + card.face);
			}
		}

		public static List<Card> sort (List<Card> cards, Dictionary<string,int> suite_dict, Dictionary<string, int> face_dict) {
			cards.Sort(delegate(Card x, Card y) {
				return x.compare_to(y, suite_dict, face_dict);
			});
			return cards;
		}

		public static List<Card> shuffle (List<Card> cards) {
			return CardManager.shuffler (cards);
		}

		static List<T> shuffler<T>(List<T> list) {  
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

		public Card(string suite, string face) {
			this.suite = suite;
			this.face = face;
		}

		public int compare_to(Card other_card, Dictionary<string,int> suite_dict, Dictionary<string, int> face_dict) {
			int our_suite = suite_dict [this.suite];
			int their_suite = suite_dict [other_card.suite];
			int their_face = face_dict [this.face];
			int our_face = face_dict [other_card.face];

			if (their_suite > our_suite)
				return -1;
			else if (their_suite < our_suite)
				return 1;
			else {
				if (their_face > our_face)
					return 1;
				else if (their_face < our_face)
					return -1;
				else
					return 0;
			}
		}
	}
}
