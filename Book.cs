using System;

namespace HW5 {
    public class Book : Holding {
        public int CopyrightYear {get; protected set;}
        public string Author {get; protected set;}

        // Default Constructor
        public Book() : base() {
            CopyrightYear = 1800;
            Author = "Default Author";
        }

        // Non default constructor
        public Book(int id, string title, string description, int copyrightYear, string author) : base(id, title, description, false) {
            if (copyrightYear < 1800 || copyrightYear > 2024) {
                throw new ArgumentException("Copyright year must be between 1800 and 2024.");
            }
            CopyrightYear = copyrightYear;
            Author = author;
        }

        // Abstract method from Holding class
        public override string GetHoldingType() {
            return "Book";
        }

        public override string ToString() {
            return base.ToString() + $", Copyright Year: {CopyrightYear}, Author: {Author}";
        }
    }
}