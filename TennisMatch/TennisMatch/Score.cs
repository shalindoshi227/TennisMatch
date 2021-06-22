using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatch
{
    public class Score
    {
        public int GameScore { get; set; }
        public int SetScore { get; set; }
        public int MatchScore { get; set; }

        public Score() {
            GameScore = 0;
            SetScore = 0;
            MatchScore = 0;
        }
    }
}
