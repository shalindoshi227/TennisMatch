using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatch
{
    public class Player
    {
        public string DisplayName { get; set; }

        public Score Score { get; set; }

        public Player(string displayName) {
            if (string.IsNullOrWhiteSpace(displayName)) {
                throw new ArgumentNullException("Player Names must have a value");
            }
            this.DisplayName= displayName;
        }
    }
}
