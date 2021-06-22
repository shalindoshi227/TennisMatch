using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatch
{
    public class ScoreKeeper
    {
        public Dictionary<Player,int> GameScore { get; set; }
        public Dictionary<Player, int> SetScore { get; set; }
        public Dictionary<Player, int>  MatchScore { get; set; }

        public ScoreKeeper() {
            GameScore = new Dictionary<Player, int>();
            SetScore = new Dictionary<Player, int>();
            MatchScore = new Dictionary<Player, int>();
        }
        public ScoreKeeper(Player playerOne, Player playerTwo)
        {
            GameScore = new Dictionary<Player, int>();
            GameScore.Add(playerOne, 0);
            GameScore.Add(playerTwo, 0);
            SetScore = new Dictionary<Player, int>();
            SetScore.Add(playerOne, 0);
            SetScore.Add(playerTwo, 0);
            MatchScore = new Dictionary<Player, int>();
            MatchScore.Add(playerOne, 0);
            MatchScore.Add(playerTwo, 0);
        }
    }
}
