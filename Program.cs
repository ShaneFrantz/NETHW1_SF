// Shane Frantz
// .NET Programming CPSC-23000
// This program is used to demonstrate basic OOP principles in C#
// Object keeps track of barbershop quartet contest score (quartet name, song name, score for each category)

using System;
using System.IO;

namespace OOP {
    class Program {
        static void Main() {

            // Creating header
            string headerLine = "*******************************";
            Console.WriteLine(headerLine);
            Console.WriteLine("   Quartet OOP Demonstration");
            Console.WriteLine(headerLine);

            // Reading info

            string userInput = "";

            while (true) {

                Console.Write("\nEnter quartet name: ");
                userInput = Console.ReadLine();
                if (userInput == "quit") break;
                string quartetName = userInput;

                Console.Write("\nEnter MUS score: ");
                userInput = Console.ReadLine();
                if (userInput == "quit") break;
                double musScore = double.Parse(userInput);

                Console.Write("\nEnter PER score: ");
                userInput = Console.ReadLine();
                if (userInput == "quit") break;
                double perScore = double.Parse(userInput);

                Console.Write("\nEnter SNG score: ");
                userInput = Console.ReadLine();
                if (userInput == "quit") break;
                double sngScore = double.Parse(userInput);

                // Making object and printing data

                QuartetScore quartetScore = new QuartetScore(quartetName, musScore, perScore, sngScore);
                Console.WriteLine(quartetScore.ToString());
                Console.WriteLine($"Quartet Total Score: {quartetScore.TotalScore():F1}");
            }
        }
    }
}