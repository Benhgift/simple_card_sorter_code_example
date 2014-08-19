using System;
using System.Collections.Generic;

namespace cards {
	public class Tester {
		
		Dictionary<string, int> suite_dict;
		Dictionary<string, int> face_dict;

		public Tester () {
			this.suite_dict = CardManager.make_suite_dict ();
			this.face_dict = CardManager.make_face_dict ();
		}

		public void run_tests() {
			Console.WriteLine ("Running tests");
			try{
				List<Card> cards = this.test_make_deck ();
				if (cards == null)
					throw new Exception();
				cards = this.test_shuffle (cards);
				if (cards == null)
					throw new Exception();
				cards = this.test_sort (cards);
				if (cards == null)
					throw new Exception();	
				Console.WriteLine ("All tests succeeded");
			} catch {
				Console.WriteLine ("Error found in last ran test");
			} finally {
				Console.WriteLine ("Finished testing");
			}
		}
		
		public List<Card> test_make_deck() {
			try {
				Console.WriteLine ("Testing deck creation");
				Dictionary<string, int> suite_dict = CardManager.make_suite_dict ();
				Dictionary<string, int> face_dict = CardManager.make_face_dict ();
				List<Card> list_of_cards = CardManager.make_deck (suite_dict, face_dict);
				if (list_of_cards.Count < 10)
					throw new Exception();
				return list_of_cards;
			} catch {
				Console.WriteLine ("Bad deck creation");
				return null;
			}
		}

		public List<Card> test_shuffle(List<Card> cards) {
			Console.WriteLine ("Testing deck shuffling");
			try {
				return CardManager.shuffle(cards);
			} catch {
				Console.WriteLine ("Bad deck shuffling");
				return null;
			}
		}

		public List<Card> test_sort(List<Card> cards) {
			try {
				Console.WriteLine ("Testing deck sorting");
				cards = CardManager.sort(cards, this.suite_dict, this.face_dict);
				if (cards[0].compare_to(cards[10], this.suite_dict, this.face_dict) > 0)
					throw new Exception();
				return cards;

			} catch {
				Console.WriteLine ("Bad deck sorting");
				return null;
			}
		}
	}
}

