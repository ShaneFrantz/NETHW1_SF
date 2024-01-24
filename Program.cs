using System;

namespace HW1
{
    class Program
    {
        static void Main()
        {
            // Printing header
            Console.WriteLine("********************************************************************\n\t\t\tShape Calculator V1.0\n********************************************************************");

            // Inputting variables for cube volume
            Console.WriteLine("\nFirst, let's deal with a cube.");

            Console.Write("What is the width? ");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.Write("What is the length? ");
            double length = Convert.ToDouble(Console.ReadLine());

            Console.Write("What is the height? ");
            double height = Convert.ToDouble(Console.ReadLine());

            // Calculating and printing cube volume
            double cubeVolume = width * length * height;
            Console.WriteLine($"The cube's volume is {cubeVolume:F3}");

            // Inputting radius for sphere volume
            Console.WriteLine("\nNow let's deal with a sphere.");
            Console.Write("What is the radius? ");
            double radius = Convert.ToDouble(Console.ReadLine());

            // Calculating and printing sphere volume
            double sphereVolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
            Console.WriteLine($"The sphere's volume is {sphereVolume:F3}");

            // Adding cube and sphere volumes
            double totalVolume = cubeVolume + sphereVolume;
            Console.WriteLine($"\nThe total volume of the cube and sphere is {totalVolume:F3}");

            Console.WriteLine("\nThank you for using this program.");
        }
    }
}

