using System;
using System.Collections.Generic;

namespace HW5 {
    class Library {
        private List<Holding> holdings;

        public Library() {
            holdings = new List<Holding>();
        }

        // Function to add a new holding to the library 
        public void AddHolding(Holding holding) {
            holdings.Add(holding);
        }

        // Function to check a holding out
        public bool CheckOut(int holdingId) {
            foreach (Holding holding in holdings) {
                if (holding.ID == holdingId && !holding.CheckedOut) {
                    holding.CheckOut();
                    Console.WriteLine("You have checked it out");
                    return true;
                }
            }
            Console.WriteLine("There was a problem with your request");
            return false;
        }

        // Function to check a holding in
        public bool CheckIn(int holdingId) {
            foreach (Holding holding in holdings) {
                if (holding.ID == holdingId && holding.CheckedOut) {
                    holding.CheckIn();
                    Console.WriteLine("You have checked it in");
                    return true;
                }
            }
            Console.WriteLine("There was a problem with your request");
            return false;
        }

        // Function that sorts holdings into two lists (one of checked out holdings and one of checked in holdings)
        public (List<Holding>, List<Holding>) SortHoldingsByCheckOutStatus() {
            List<Holding> checkedOutHoldings = new List<Holding>();
            List<Holding> checkedInHoldings = new List<Holding>();

            foreach(Holding holding in holdings) {
                if (holding.CheckedOut) {
                    checkedOutHoldings.Add(holding);
                } else {
                    checkedInHoldings.Add(holding);
                }
            }
            return (checkedOutHoldings, checkedInHoldings);
        }

        // Formats data found in SortHoldingsByCheckOutStatus
        public void ListAll() {
            var (checkedOutHoldings, checkedInHoldings) = SortHoldingsByCheckOutStatus();
            Console.WriteLine("These holdings are checked out:");
            foreach (Holding holding in checkedOutHoldings) {
                Console.WriteLine($"{holding.ID}");
            }
            Console.WriteLine("\nThese holdings are available:");
            foreach (Holding holding in checkedInHoldings) {
                Console.WriteLine($"{holding.ID}");
            }
        }

        // Prints stats of how many books are checked in and out
        public void GetStats() {
            var (checkedOutHoldings, checkedInHoldings) = SortHoldingsByCheckOutStatus();

            Console.WriteLine("Here are the library's availability stats:");
            Console.WriteLine($"Available:   {checkedInHoldings.Count}");
            Console.WriteLine($"Checked out: {checkedOutHoldings.Count}");
        }
    }
}