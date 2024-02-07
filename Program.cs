// Shane Frantz
// .NET Programming CPSC-23000
// This program is used to read a store inventory from a .txt file and allow the user to make purchases 
// The program keeps a running total of the cost and items that they have selected

using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace FrantzStorefront {
    class Program {
        static void Main() {
            // Creating Hashmaps to store the inventory of the store and the user's cart
            // Allows for O(1) lookup as opposed to an array which would be O(N)
            Dictionary<string, decimal> storeInventory = new Dictionary<string, decimal>();
            Dictionary<string, int> cart = new Dictionary<string, int>();

            // Allows us to easily change # of *s in the header evenly on top and bottom
            string headerLine = "************************************************";

            // Printing header
            Console.WriteLine(headerLine);
            Console.WriteLine("\t\tSTOREFRONT V1.0");
            Console.WriteLine(headerLine);

            // Prompting user for file name
            Console.Write("Enter name of file: ");
            string path = Console.ReadLine();

            // Exit program if file path is invalid
            if (!File.Exists(path)) {
                Console.WriteLine("Error: File path not valid");
                return;
            }

            // An array to store all lines of the file
            string[] lines = null;

            // Reading file lines
            try {
                lines = File.ReadAllLines(path);
            } catch (IOException ie) {
                Console.WriteLine($"Error: IOException: {ie.Message}");
                return;
            } catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            GetInventory(lines, storeInventory);

            // Logic for purchasing items
            string userInput = null;
            do {
                DisplayItems(storeInventory);
                Console.Write("Enter your choice: ");
                userInput = Console.ReadLine();

                // Check if user inputs item not in storeInventory
                if (!storeInventory.ContainsKey(userInput) && userInput != "quit") {
                    Console.WriteLine("That item does not exist!");
                } else if (userInput != "quit") {
                    // Prompt user for quantity
                    Console.Write("How many do you want? ");
                    int quantity;
                    string quantityInput = Console.ReadLine();

                    // Validating if user entered a valid integer
                    try {
                        quantity = int.Parse(quantityInput);
                        if (quantity < 0) {
                            Console.WriteLine("Error: Negative quantity entered");
                            continue;
                        }
                    } catch (FormatException) {
                        Console.WriteLine("Error: Not a valid number");
                        continue;
                    } catch (OverflowException) {
                        Console.WriteLine("Error: Number too large");
                        continue;
                    }

                    // Adding valid item to cart
                    if (cart.ContainsKey(userInput)) {
                        cart[userInput] += quantity;
                    } else {
                        cart[userInput] = quantity;
                    }
                } 
            } while (userInput != "quit");

            DisplayTotal(cart, storeInventory);
        }

        // Function that parses the item names and prices out of the array of file lines
        static void GetInventory(string[] lines, Dictionary<string, decimal> storeInventory) {
            foreach (var line in lines) {

                // Gets the index of the last space in the line so that we know when the price starts
                int lastSpaceIndex = line.LastIndexOf(' ');

                // Skips empty lines and lines without spaces
                if (lastSpaceIndex == -1) {
                    Console.WriteLine($"Skipping incorrectly formatted line: {line}");
                    continue;
                }
                
                // Storing item name and price substring
                string itemName = line.Substring(0, lastSpaceIndex);
                string priceSubstring = line.Substring(lastSpaceIndex + 1);

                // Checks if the priceSubstring is formatted correctly
                if (decimal.TryParse(priceSubstring, NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal price)) {
                    // Creating HashMap entry
                    storeInventory[itemName] = price;
                } else {
                    Console.WriteLine($"Skipping incorrectly formatted line: {line}");
                }
            }
        }

        // Function to display the store inventory
        static void DisplayItems(Dictionary<string, decimal> storeInventory) {

            foreach (var item in storeInventory) {
                Console.WriteLine("{0,-20} {1,10:F2}", item.Key, item.Value);
            }
        }

        // Function to display the quantities of what the user bought and the total price
        static void DisplayTotal(Dictionary<string, int> cart, Dictionary<string, decimal> storeInventory) {
            Console.WriteLine("\nHere is what you bought:");
            decimal totalPrice = 0m;
            // Calculating the price of getting each individual item and adding them all up for the grand total
            foreach (var item in cart) {
                decimal itemPrice = item.Value * storeInventory[item.Key];
                totalPrice += itemPrice;
                // Printing each item and quantity purchased
                Console.WriteLine("{0, -20} {1, 10}", item.Key, item.Value);
            }
            // Displaying total price
            Console.WriteLine($"Your total bill is ${totalPrice:F2}");
        }
    }
}