using System;

namespace HW5 {
    public class Periodical : Holding {
        // Getter and setter
        public string PublicationDate {get; protected set;}

        // Default Constructor
        public Periodical() : base() {
            PublicationDate = "01-01-1800";
        }

        // Non default constructor
        public Periodical(int id, string title, string description, int copyrightYear, string publicationDate) : base(id, title, description, false) {
            PublicationDate = publicationDate;
        }

        // Abstract method from Holding class
        public override string GetHoldingType() {
            return "Periodical";
        }

        public override string ToString() {
            return base.ToString() + $", Publication Date: {PublicationDate}";
        }
    }
}