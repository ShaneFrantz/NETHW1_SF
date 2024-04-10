using Microsoft.EntityFrameworkCore;
using System;
namespace QuartetDBAppEFCore
{
    internal class Program
    {
        static void ListQuartetScores(List<QuartetScore> quartetScores)
        {
            foreach (QuartetScore quartetScore in quartetScores)
            {
                Console.WriteLine(quartetScore);
            }
        }

        static void Main(string[] args)
        {
            /*
            QuartetScoreDBContext context = new QuartetScoreDBContext();
            context.QuartetScores.RemoveRange(context.QuartetScores.ToList<QuartetScore>());
            QuartetScore q1 = new QuartetScore(0, "Freelance", 72, 71, 68);
            context.Add(q1);
            QuartetScore q2 = new QuartetScore(0, "Three and a Half Men", 95, 93, 94);
            context.Add(q2);
            context.SaveChanges();
            List<QuartetScore> quartetList1 = context.QuartetScores.ToList<QuartetScore>();
            Console.WriteLine("After first read...");
            ListQuartetScores(quartetList1);
            q2.QuartetName = "Quorum";
            context.SaveChanges();
            quartetList1 = context.QuartetScores.ToList<QuartetScore>();
            Console.WriteLine("After changing the second quartet");
            ListQuartetScores(quartetList1);
            List<QuartetScore> goodQuartets = context.QuartetScores.Where<QuartetScore>(q => q.SngScore == 94).ToList<QuartetScore>();
            Console.WriteLine("These are the good quartets");
            ListQuartetScores(goodQuartets);
            context.QuartetScores.RemoveRange(goodQuartets);
            context.SaveChanges();
            List<QuartetScore> quartetList2 = context.QuartetScores.ToList<QuartetScore>();
            Console.WriteLine("After removing the good quartets");
            ListQuartetScores(quartetList2);
            */

            QuartetScoreDBContext context = new QuartetScoreDBContext();
            QuartetScore quartet;
            List<QuartetScore> quartetList;

            string headerLine = "***********************************";
            string headerText = "QUARTET DATABASE";

            int choiceNumber;
            


            // Printing header
            while (true)
            {
                Console.WriteLine(headerLine);
                Console.WriteLine("\t" + headerText);
                Console.WriteLine(headerLine);

                // Printing menu
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a quartet");
                Console.WriteLine("2. List quartets");
                Console.WriteLine("3. Update a quartet");
                Console.WriteLine("4. Remove a quartet");
                Console.WriteLine("5. Remove all quartets");
                Console.WriteLine("6. Exit");
                Console.Write("Enter the number of your choice: ");

                // Prompting user for menu option
                while (true)
                {
                    try
                    {
                        choiceNumber = Convert.ToInt32(Console.ReadLine());
                        if (choiceNumber >= 1 && choiceNumber <= 6) break;
                        else Console.Write("Please enter a number between 1-6: ");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.Write("Please enter a number between 1-6: ");
                    }
                }

                // Handling menu logic
                switch (choiceNumber)
                    {
                    case 1: // Adding quartet
                        Console.Write("Enter name of quartet: ");
                        string? quartetName = Console.ReadLine();
                        int musScore;
                        int perScore;
                        int sngScore;
                        Console.Write("Enter music score: ");
                        while (true)
                        {
                            try
                            {
                                musScore = Convert.ToInt32(Console.ReadLine());
                                if (musScore >= 0 && musScore <= 100) break;
                                else Console.Write("Please enter a number between 0-100: ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                                Console.Write("Please enter a number between 0-100: ");
                            }
                        }
                        Console.Write("Enter performance score: ");
                        while (true)
                        {
                            try
                            {
                                perScore = Convert.ToInt32(Console.ReadLine());
                                if (perScore >= 0 && perScore <= 100) break;
                                else Console.Write("Please enter a number between 0-100: ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                                Console.Write("Please enter a number between 0-100: ");
                            }
                        }
                        Console.Write("Enter singing score: ");
                        while (true)
                        {
                            try
                            {
                                sngScore = Convert.ToInt32(Console.ReadLine());
                                if (sngScore >= 0 && sngScore <= 100) break;
                                else Console.Write("Please enter a number between 0-100: ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                                Console.Write("Please enter a number between 0-100: ");
                            }
                        }

                        try
                        {
                            quartet = new QuartetScore(0, quartetName, musScore, perScore, sngScore);
                            context.Add(quartet);
                            context.SaveChanges();
                            Console.WriteLine("Quartet successfully added to the database.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("There was an error adding the quartet to the database: " + ex.Message);   
                        }

                        break;
                    case 2:
                        quartetList = context.QuartetScores.ToList<QuartetScore>();
                        ListQuartetScores(quartetList);
                        break;
                    case 3:
                        Console.WriteLine("Option 3");
                        break;
                    case 4:
                        Console.WriteLine("Option 4");
                        break;
                    case 5:
                        Console.WriteLine("Option 5");
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using this program!");
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("How did you get here");
                        break;
                }
            }
        }
    }
}
