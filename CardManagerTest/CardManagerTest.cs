/*
 * These are the tests for the basic functionality of 
 * the program. The functionality is in the CardManager
 * class, so that's what we test. 
 */

using System;
using CardManager;
using NUnit.Framework;
using System.Collections.Generic;

namespace CardManagerTest {

	[TestFixture]
	public class CardManagerTest {
		CardManager.CardManager cardManager;
			
		public CardManagerTest () {
			cardManager = new CardManager.CardManager ();
		}

		[Test]
		public void MakeDeckTest() {
			Assert.Greater (cardManager.MakeDeck ().Count, 10, "Should be more than 10 cards");
		}

		[Test]
		public void TestShuffle() {
			Assert.Greater (cardManager.Shuffle ().Count, 10, "This should return a card list");
		}

		[Test]
		public void TestSort() {
			List<Card> cards = cardManager.Sort();
			Assert.Less (cards [0].CompareTo (cards [10]), 0, "Comparison should return less than 0");
		}
	}
}

