// Shane Frantz
// .NET Programming CPSC-23000
// This program demonstrates further OOP principles with classes that model a library

using System;
using System.IO;

namespace HW5 {
    class Program {
        static void Main() {

            Library library = new Library();

            //TODO YOU CAN ADD CODE HERE TO ADD HOLDINGS TO TEST THE CODE ! ! ! 

            // Printing header and description
            string headerLine = "*****************************************";
            Console.WriteLine(headerLine);
            Console.WriteLine("  LIBRARY MANAGEMENT SYSTEM VERSION 1.0");
            Console.WriteLine(headerLine);

            Console.WriteLine("\nThis tool helps you manage a library's collections.");

            // Boolean flag to determine if menu loop should be running
            bool runMenu = true;

            while (runMenu) {
                Console.WriteLine("Please use the menu to choose what you want to do.");

                Console.WriteLine("\nHere are your options:");
                Console.WriteLine("1. List holdings");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Add a periodical");
                Console.WriteLine("4. Reserve a holding");
                Console.WriteLine("5. Return a holding");
                Console.WriteLine("6. See statistics");
                Console.WriteLine("7. Quit");
                Console.Write("Enter the number of your choice: ");

                // Stores the number that the user selects
                int optionSelected = 0;

                // String to prompt for user input
                string userInput = "";

                // Waits for a valid input from the user (any number between 1 and 7)
                while (true) {
                    userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out optionSelected) && optionSelected >= 1 && optionSelected <= 7) {
                        break;
                    } else {
                        Console.Write("Not a valid menu option. Please select option 1-7: ");
                    }
                }

                // Switch case to handle correct menu option 
                switch (optionSelected) {
                    // List holdings
                    case 1:
                        library.ListAll();
                        break;
                    // Add a book
                    case 2:
                        int bookID;
                        string bookTitle;
                        string bookDescription;
                        int bookCopyrightYear;
                        string bookAuthor;

                        // Looping for valid bookID
                        Console.Write("Enter ID Number: ");
                        while (true) {
                            userInput = Console.ReadLine();

                            if (int.TryParse(userInput, out bookID)) {
                                break;
                            } else {
                                Console.Write("Not a valid Book ID. Please enter an integer: ");
                            }
                        }

                        //Prompting for title and description
                        Console.Write("Enter Title: ");
                        bookTitle = Console.ReadLine();

                        Console.Write("Enter Description: ");
                        bookDescription = Console.ReadLine();

                        // Looping for valid bookCopyrightYear
                        Console.Write("Enter Copyright Year: ");
                        while (true) {
                            userInput = Console.ReadLine();

                            if (int.TryParse(userInput, out bookCopyrightYear)) {
                                if (bookCopyrightYear >= 1800 && bookCopyrightYear <= 2024) {
                                    break;
                                }
                            }
                            Console.Write("Not a valid Copyright Year. Please enter an integer (1800-2024): ");
                        }

                        // Prompting for author
                        Console.Write("Enter Author: ");
                        bookAuthor = Console.ReadLine();

                        // Adding Book to library and calling ToString()
                        Book book = new Book(bookID, bookTitle, bookDescription, bookCopyrightYear, bookAuthor);
                        library.AddHolding(book);
                        Console.WriteLine(book.ToString());
                        break;
                    // Add a periodical
                    case 3: 
                        int periodicalID;
                        string periodicalTitle;
                        string periodicalDescription;
                        string periodicalDate;

                        // Looping for valid periodicalID
                        Console.Write("Enter ID Number: ");
                        while (true) {
                            userInput = Console.ReadLine();

                            if (int.TryParse(userInput, out periodicalID)) {
                                break;
                            } else {
                                Console.Write("Not a valid Periodical ID. Please enter an integer: ");
                            }
                        }
                        // Prompting for title, description, and publication date
                        Console.Write("Enter Title: ");
                        periodicalTitle = Console.ReadLine();

                        Console.Write("Enter Description: ");
                        periodicalDescription = Console.ReadLine();

                        Console.Write("Enter Date: ");
                        periodicalDate = Console.ReadLine();

                        Periodical periodical = new Periodical(periodicalID, periodicalTitle, periodicalDescription, periodicalDate);
                        library.AddHolding(periodical);
                        Console.WriteLine(periodical.ToString());
                        break;
                    // Reserve a holding
                    case 4:
                        int checkOutID;

                        // Prompting for valid ID number
                        Console.Write("Enter the ID number of the holding to reserve: ");
                        while (true) {
                            userInput = Console.ReadLine();

                            if (int.TryParse(userInput, out checkOutID)) {
                                library.CheckOut(checkOutID);
                                break;
                            } else {
                                Console.Write("Not a valid Holding ID. Please enter an integer: ");
                            }
                        }
                        break;
                    // Return a holding
                    case 5:
                        int checkInID;

                        // Prompting for valid ID number
                        Console.Write("Enter the ID number of the holding to check in: ");
                        while (true) {
                            userInput = Console.ReadLine();

                            if (int.TryParse(userInput, out checkInID)) {
                                library.CheckIn(checkInID);
                                break;
                            } else {
                                Console.Write("Not a valid Holding ID. Please enter an integer: ");
                            }
                        }
                        break;
                    // See statistics
                    case 6:
                        library.GetStats();
                        break;
                    // Quit
                    case 7:
                        Console.WriteLine("\nThank you for using this program");
                        runMenu = false;
                        break;
                    default:
                        Console.WriteLine("I don't know how this happened if we already validated the input!");
                        break;
                }
            }
        }
    }
}