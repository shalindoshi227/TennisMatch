using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatch
{
    public class MatchRunner
    {
        private Player _playerOne;
        private Player _playerTwo;
        public MatchRunner(Player playerOne, Player playerTwo) {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
        }

        public void Begin() { 
            //Starts a Match which starts a Set which starts a Game
        }

        public void PlayGame() {
            //Method plays a game with two players
            while (true) {
                Console.WriteLine("Player One has: " + _playerOne.Score.GameScore);
                bool isThereAWinner = true;
                if (isThereAWinner) {
                    //If there is a winner then write out winner and break
                    Console.WriteLine("Winner is: ");
                    break;
                }
            }
        }
    }
}
