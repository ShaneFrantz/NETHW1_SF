using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartetDBAppEFCore
{
    internal class QuartetScore
    {
        // Getters and setters
        public int Id { get; set; }
        public string QuartetName { get; set; }
        public int MusScore { get; set; }
        public int PerScore { get; set; }
        public int SngScore { get; set; }

        public QuartetScore()
        {
            Id = 0;
            QuartetName = string.Empty;
            MusScore = 0;
            PerScore = 0;
            SngScore = 0;
        }

        public QuartetScore(int id, string quartetName, int musScore, int perScore, int sngScore)
        {
            Id = id;
            QuartetName = quartetName;
            MusScore = musScore;
            PerScore = perScore;
            SngScore = sngScore;
        }

        // Returns total average score

        public double TotalScore()
        {
            return (MusScore + PerScore + SngScore) / 3.0;
        }

        public override string ToString()
        {
            return $"{Id}\t{QuartetName}\t{MusScore}\t{PerScore}\t{SngScore}";
        }
    }
}
