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
            PlayMatch();

        }

        public void PlayMatch()
        {
            //Method plays a Match, playing Sets until a player has won 2
            while (true)
            {
                Console.WriteLine("Player One has won : " + _playerOne.Score.MatchScore + " Sets");
                Console.WriteLine("Player Two has won : " + _playerTwo.Score.MatchScore + " Sets");
                PlaySet();
                string whoIsMatchWinner = checkForMatchWinner();
                if (!string.IsNullOrWhiteSpace(whoIsMatchWinner))
                {
                    //If there is a winner then write out winner
                    bool isPlayerOneWinner = _playerOne.Score.MatchScore > _playerTwo.Score.MatchScore;
                    _playerOne.WinStatus = isPlayerOneWinner ? "Wins" : "Loses";
                    _playerTwo.WinStatus = !isPlayerOneWinner ? "Wins" : "Loses";
                    Console.WriteLine("Match Score is: P1- " + _playerOne.Score.MatchScore + " ~~~~~  P2- " + _playerTwo.Score.MatchScore);
                    Console.WriteLine("Match Winner is: " + (isPlayerOneWinner ? _playerOne.DisplayName : _playerTwo.DisplayName));
                    break;
                }
            }
        }

        public void PlaySet() {
            //Method plays a Set, playing Games until a set is won
            while (true) {
                Console.WriteLine("Player One has won: " + _playerOne.Score.SetScore + " Games");
                Console.WriteLine("Player Two has won: " + _playerTwo.Score.SetScore + " Games");
                PlayGame();
                string whoIsSetWinner = checkForSetWinner();
                if (!string.IsNullOrWhiteSpace(whoIsSetWinner)) {
                    //Write out winner, clear set scores and break
                    //If there is a winner then write out winner, clear the Game Scores and break
                    bool isPlayerOneWinner = _playerOne.Score.SetScore > _playerTwo.Score.SetScore;
                    _ = isPlayerOneWinner ? _playerOne.Score.MatchScore++ : _playerTwo.Score.MatchScore++;
                    Console.WriteLine("Set Score is: P1- " + _playerOne.Score.SetScore + " ~~~~~  P2- " + _playerTwo.Score.SetScore);
                    Console.WriteLine("Match Score is: P1- " + _playerOne.Score.MatchScore + " ~~~~~  P2- " + _playerTwo.Score.MatchScore);
                    _playerOne.Score.SetScore = 0;
                    _playerTwo.Score.SetScore = 0;
                    Console.WriteLine("Set Winner is: " + (isPlayerOneWinner ? _playerOne.DisplayName : _playerTwo.DisplayName));
                    break;
                }
            }
        }

        

        public void PlayGame() {
            //Method plays a game with two players, playing points until a game is won
            while (true) {
                Console.WriteLine("Player One has: " + _playerOne.Score.GameScore + " Points");
                Console.WriteLine("Player Two has: " + _playerTwo.Score.GameScore + " Points");
                PlayPoint();
                string whoIsGameWinner = checkForGameWinner();
                if (!string.IsNullOrWhiteSpace(whoIsGameWinner)) {
                    //If there is a winner then write out winner, clear the Game Scores and break
                    bool isPlayerOneWinner = _playerOne.Score.GameScore > _playerTwo.Score.GameScore;
                    _ = isPlayerOneWinner ? _playerOne.Score.SetScore++: _playerTwo.Score.SetScore++;
                    Console.WriteLine("Game Score is: P1- "+ _playerOne.Score.GameScore + " ~~~~~  P2- "+_playerTwo.Score.GameScore);
                    Console.WriteLine("Set Score is: P1- " + _playerOne.Score.SetScore + " ~~~~~  P2- " + _playerTwo.Score.SetScore);
                    _playerOne.Score.GameScore = 0;
                    _playerTwo.Score.GameScore = 0;
                    Console.WriteLine("Game Winner is: " + (isPlayerOneWinner?_playerOne.DisplayName:_playerTwo.DisplayName));
                    break;
                }
            }
        }

        public void PlayPoint() {
            Random umpire = new Random();
            _ = umpire.Next(0, 2) == 1 ? _playerOne.Score.GameScore++ : _playerTwo.Score.GameScore++;
        }

        private string checkForGameWinner() {
            int scoreOne = _playerOne.Score.GameScore;
            int scoreTwo = _playerTwo.Score.GameScore;
            if (scoreOne > 3 && scoreTwo < 3) return "Player One wins";
            else if (scoreTwo > 3 && scoreOne < 3) return "Player Two wins";
            else if (scoreOne > 3 && (scoreOne - scoreTwo) > 1) return "Player One Wins";
            else if (scoreTwo > 3 && (scoreTwo - scoreOne) > 1) return "Player Two Wins";
            else return "";
        }

        private string checkForSetWinner()
        {
            int scoreOne = _playerOne.Score.SetScore;
            int scoreTwo = _playerTwo.Score.SetScore;
            if (scoreOne > 5 && scoreTwo < 5) return "Player One wins";
            else if (scoreTwo > 5 && scoreOne < 5) return "Player Two wins";
            else if (scoreOne > 5 && (scoreOne - scoreTwo) > 1) return "Player One Wins";
            else if (scoreTwo > 5 && (scoreTwo - scoreOne) > 1) return "Player Two Wins";
            else return "";
        }

        private string checkForMatchWinner()
        {
            int scoreOne = _playerOne.Score.MatchScore;
            int scoreTwo = _playerTwo.Score.MatchScore;
            if (scoreOne ==2 ) return "Player One wins";
            else if (scoreTwo == 2) return "Player Two wins";
            else return "";
        }

    }
}
