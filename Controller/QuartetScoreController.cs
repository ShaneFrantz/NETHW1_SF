using System;
using System.Collections.Generic;
using System.Linq;
using OOP.Model;

namespace OOP.Controller
{
    public class QuartetScoreController
    {
        // Contains QuartetScore objects
        private List<QuartetScore> scores;

        public QuartetScoreController() {
            scores = new List<QuartetScore>();
        }

        // Function to add or update QuartetScore based on if a quartet with that name already exists
        public void AddOrUpdateScore(string name, int mus, int per, int sng) {
            var existing = scores.FirstOrDefault(s => s.QuartetName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existing != null) {
                existing.MusScore = mus;
                existing.PerScore = per;
                existing.SngScore = sng;
            } else {
                scores.Add(new QuartetScore(name, mus, per, sng));
            }
        }

        // Returns all QuartetScore objects (scores variable above)
        public List<QuartetScore> GetAllScores() => scores;

        // Returns a single QuartetScore (input the name)
        public QuartetScore GetScoreByName(string name) =>
            scores.FirstOrDefault(s => s.QuartetName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
