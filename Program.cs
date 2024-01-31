// Shane Frantz
// .NET Programming CPSC-23000
// This program is used to calculate how many gallons of paint and primer is needed to paint a house
// Given certain dimensions of the house and parameters about the paint/primer

using System;

namespace HW2 {
    class Program {
        static void Main() {
            // Amount of square feet a gallon of paint and primer will cover per gallon
            const int paintPerGallon = 400;
            const int primerPerGallon = 250;

            // Running total of required area to be painted and primed
            double paintArea = 0;
            double primeArea = 0;

            // Printing header
            Console.WriteLine("********************************************************************\n\t\t\tHOUSE PAINTER V1.0\n********************************************************************");
            
            // Using try block to handle bad user inputs
            try {
            // Inputting number of rooms
            Console.Write("\nHow many rooms do you plan to paint? ");
            int numberOfRooms = int.Parse(Console.ReadLine());
                // Ask for dimensions of each room
                for (int i = 1; i <= numberOfRooms; i++) {
                    Console.WriteLine($"For Room #{i} ...");

                    // Getting length
                    Console.Write("\tEnter length: ");
                    double length = double.Parse(Console.ReadLine());

                    // Getting width
                    Console.Write("\tEnter width: ");
                    double width = double.Parse(Console.ReadLine());

                    // Getting height
                    Console.Write("\tEnter height: ");
                    double height = double.Parse(Console.ReadLine());

                    // Boolean args for painting ceiling and using primer
                    Console.Write("\tPaint the ceiling? ");
                    string userInput = Console.ReadLine().Trim().ToLower();

                    // while loop to validate user input
                    while (userInput != "y" && userInput != "n" && userInput != "yes" && userInput != "no") {
                        Console.WriteLine("Please enter \"yes\", \"no\", \"y\", or \"n\"");
                        userInput = Console.ReadLine().Trim().ToLower();
                    }

                    // Sets paintCeiloing after userInput has been validated
                    bool paintCeiling = userInput == "yes" || userInput == "y";

                    Console.Write("\tUse primer? ");
                    userInput = Console.ReadLine().Trim().ToLower();
                    // while loop to validate user input
                    while (userInput != "y" && userInput != "n" && userInput != "yes" && userInput != "no") {
                        Console.WriteLine("Please enter \"yes\", \"no\", \"y\", or \"n\"");
                        userInput = Console.ReadLine().Trim().ToLower();
                    }

                    // Sets usePrimer after userInput has been validated
                    bool usePrimer = userInput == "yes" || userInput == "y";

                    // Calculating total area that needs to be painted/primed all four walls of the room
                    double areaOfWalls = (length + width) * height * 2;
                    double areaOfCeiling = length * width;

                    // Add area of the room to the running totals of paint and primer
                    if (paintCeiling) {
                        paintArea += (areaOfWalls + areaOfCeiling);
                    } else {
                        paintArea += areaOfWalls;
                    }

                    if (usePrimer) {
                        if (paintCeiling) {
                            primeArea += (areaOfWalls + areaOfCeiling);
                        } else {
                            primeArea += areaOfWalls;
                        }
                    }
                }

                // Calculating number of gallons of paint and primer needed
                double paintGallons = paintArea / paintPerGallon;
                double primerGallons = primeArea / primerPerGallon;

                // Printing results
                Console.WriteLine($"\nTo paint {paintArea:F2} square feet,\n\tyou need {paintGallons:F2} gallons of paint.");
                Console.WriteLine($"To prime {primeArea:F2} square feet,\n\tyou need {primerGallons:F2} gallons of primer.");
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            } finally {
                // Prints goodbye message even if user generated an error (to make them feel better)
                Console.WriteLine("\nThank you for using this program.");
            }
        }
    }
}