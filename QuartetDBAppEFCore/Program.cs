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

        static async Task Main(string[] args)
        {
            QuartetScoreDBContext context = new QuartetScoreDBContext();
            QuartetScore quartet;
            List<QuartetScore> quartetList;

            string headerLine = "***********************************";
            string headerText = "QUARTET DATABASE";

            int choiceNumber;

            // Printing header
            Console.WriteLine(headerLine);
            Console.WriteLine("\t" + headerText);
            Console.WriteLine(headerLine);
 
            while (true)
            {
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
                    case 2: // Listing quartets
                        quartetList = context.QuartetScores.ToList<QuartetScore>();
                        ListQuartetScores(quartetList);
                        break;
                    case 3: // Updating quartet
                        int quartetID;
                        QuartetScore quartetToUpdate = null;
                        quartetList = context.QuartetScores.ToList<QuartetScore>();
                        Console.Write("Enter the id of the quartet you want to update: ");
                        while (true)
                        {
                            try
                            {
                                quartetID = Convert.ToInt32(Console.ReadLine());
                                quartetToUpdate = await context.QuartetScores.FindAsync(quartetID);

                                if (quartetToUpdate != null)
                                {
                                    Console.Write("Enter name of quartet: ");
                                    quartetName = Console.ReadLine();
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
                                        quartetToUpdate.QuartetName = quartetName;
                                        quartetToUpdate.MusScore = musScore;
                                        quartetToUpdate.PerScore = perScore;
                                        quartetToUpdate.SngScore = sngScore;
                                        context.SaveChanges();
                                        Console.WriteLine("Quartet successfully updated.");
                                        break;

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("There was an error updating the quartet in the database: " + ex.Message);
                                    }

                                    break;
                                } 
                                else
                                {
                                    Console.WriteLine("That quartet does not exist.");
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                                Console.Write("Please enter a valid integer: ");
                            }
                        }
                        break;
                    case 4: // Removing quartet
                        Console.Write("Enter the id of the quartet you want to remove: ");
                        int removeQuartetID;
                        while (true) {
                            try
                            {
                                removeQuartetID = Convert.ToInt32(Console.ReadLine());
                                QuartetScore quartetToRemove = await context.QuartetScores.FindAsync(removeQuartetID);
                                if (quartetToRemove != null)
                                {
                                    context.QuartetScores.Remove(quartetToRemove);
                                    context.SaveChanges();
                                    Console.WriteLine("Quartet succesfully removed.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("That quartet does not exist.");
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                                Console.Write("Please enter a valid integer: ");
                            }
                        }
                        break;
                    case 5: // Removing all quartets
                        try 
                        {
                            context.QuartetScores.RemoveRange(context.QuartetScores.ToList<QuartetScore>());
                            context.SaveChanges();
                            Console.WriteLine("Database successfully cleared.");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }

                        break;
                    case 6: // Exiting program
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
