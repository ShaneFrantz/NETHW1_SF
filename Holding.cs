using System;

namespace HW5 {
    public abstract class Holding {
        // Getters and setters
        public int ID {get; protected set;}
        public string Title {get; protected set;}
        public string Description {get; protected set;}
        public bool CheckedOut {get; protected set;}

        // Default constructor
        protected Holding() {
            ID = 0;
            Title = "Default Title";
            Description = "Default Description";
            CheckedOut = false;
        }

        // Non default constructor
        protected Holding(int id, string title, string description, bool checkedOut) {
            ID = id;
            Title = title;
            Description = description;
            CheckedOut = checkedOut;
        }


        // Check in and check out functions
        public void CheckOut() {
            CheckedOut = true;
        }

        public void CheckIn() {
            CheckedOut = false;
        }

        // Abstract function to get holding type
        public abstract string GetHoldingType();

        // ToString method
        public override string ToString() {
            return $"ID: {ID}, Title: {Title}, Description: {Description}, CheckedOut: {CheckedOut}";
        }
    }
}