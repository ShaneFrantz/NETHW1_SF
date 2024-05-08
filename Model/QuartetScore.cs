using System;
using System.IO;
namespace OOP.Model {
    public class QuartetScore {
        private string quartetName;
        private int musScore; // Musicality score
        private int perScore; // Performance score
        private int sngScore; // Singing score

        // Getters and setters

        public string QuartetName {
            get {return quartetName;}
            set {quartetName = value;}
        }

        public int MusScore {
            get {return musScore;}
            set {musScore = value;}
        }

        public int PerScore {
            get {return perScore;}
            set {perScore = value;}
        }

        public int SngScore {
            get {return sngScore;}
            set {sngScore = value;}
        }

        public QuartetScore() {
            quartetName = "N/A";
            musScore = 0;
            perScore = 0;
            sngScore = 0;
        }

        public QuartetScore(string quartetName, int musScore, int perScore, int sngScore) {
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