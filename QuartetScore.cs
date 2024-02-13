using System;
using System.IO;
namespace OOP {
    public class QuartetScore {
        private string quartetName;
        private double musScore; // Musicality score
        private double perScore; // Performance score
        private double sngScore; // Singing score

        public string QuartetName {
            get {return quartetName;}
            set {quartetName = value;}
        }

        public double MusScore {
            get {return musScore;}
            set {musScore = value;}
        }

        public double PerScore {
            get {return perScore;}
            set {perScore = value;}
        }

        public double SngScore {
            get {return sngScore;}
            set {sngScore = value;}
        }

        public QuartetScore() {
            quartetName = "N/A";
            musScore = 0;
            perScore = 0;
            sngScore = 0;
        }

        public QuartetScore(string quartetName, double musScore, double perScore, double sngScore) {
            this.quartetName = quartetName;
            this.musScore = musScore;
            this.perScore = perScore;
            this.sngScore = sngScore;
        }

        // Returns total average score

        public double TotalScore() {
            return (MusScore + PerScore + SngScore) / 3.0;
        }      

        public override string ToString() {
            return($"Quartet Name: {quartetName}, MUS Score: {musScore}, PER Score: {perScore}, SNG Score: {sngScore}");
        }
    }
}