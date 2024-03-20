// Shane Frantz
// .NET Programming CPSC-23000

using System;
using System.Windows.Forms;
using OOP.View; // Make sure this namespace matches where your QuartetScoreForm class is located.

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new QuartetScoreForm()); // Ensure QuartetScoreForm is the name of your form class.
    }
}