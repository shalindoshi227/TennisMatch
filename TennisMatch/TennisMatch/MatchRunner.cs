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
        private ScoreKeeper _scoreKeeper;
        private List<string> setScores;
        public MatchRunner(Player playerOne, Player playerTwo, ScoreKeeper scoreKeeper) {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _scoreKeeper = scoreKeeper;
            setScores = new List<string>();
        }

        public void Begin() {
            PlayMatch();
            PrintResult();
        }

        private void PrintResult()
        {
            Console.WriteLine("{0,-20} {1,5}\n", "Set Number", "Score");
            for (int x = 0; x < setScores.Count; x++)
                Console.WriteLine("{0,-20} {1,5:N1}", x, setScores[x]);
        }

        public void PlayMatch()
        {
            //Method plays a Match, playing Sets until a player has won 2
            string whoIsMatchWinner = "";
            do
            {
                PlaySet();
                whoIsMatchWinner = checkForMatchWinner();
            }
            while (string.IsNullOrWhiteSpace(whoIsMatchWinner));
                
            //If there is a winner then write out winner
            bool isPlayerOneWinner = _scoreKeeper.MatchScore[_playerOne] > _scoreKeeper.MatchScore[_playerTwo];
            _playerOne.WinStatus = isPlayerOneWinner ? "Wins" : "Loses";
            _playerTwo.WinStatus = !isPlayerOneWinner ? "Wins" : "Loses";
            Console.WriteLine("Match Winner is: " + (isPlayerOneWinner ? _playerOne.DisplayName : _playerTwo.DisplayName));
            
                
        }

        public void PlaySet() {
            //Method plays a Set, playing Games until a set is won
            string whoIsSetWinner = "";
            do
            {
                PlayGame();
                whoIsSetWinner = checkForSetWinner();
            }
            while (string.IsNullOrWhiteSpace(whoIsSetWinner));
                //If there is a winner then write out winner, clear the Game Scores and break
                    
                bool isPlayerOneWinner = _scoreKeeper.SetScore[_playerOne] > _scoreKeeper.SetScore[_playerTwo];
                _ = isPlayerOneWinner ? _scoreKeeper.MatchScore[_playerOne]++ : _scoreKeeper.MatchScore[_playerTwo]++;
                string setWinner = isPlayerOneWinner? "P1 Won " + _scoreKeeper.SetScore[_playerOne] +" - "+ _scoreKeeper.SetScore[_playerTwo]: "P2 Won " + _scoreKeeper.SetScore[_playerOne] + " - " + _scoreKeeper.SetScore[_playerTwo];
                Console.WriteLine(setWinner);
                 setScores.Add(_scoreKeeper.SetScore[_playerOne] + " - " + _scoreKeeper.SetScore[_playerTwo]);
                _scoreKeeper.SetScore[_playerOne] = 0;
                _scoreKeeper.SetScore[_playerTwo] = 0;
                Console.WriteLine("Set Winner is: " + (isPlayerOneWinner ? _playerOne.DisplayName : _playerTwo.DisplayName));
                    
                
       
        }

        public string getGameScore(int score1, int score2)
        {
            if (score1 < 4 && score2 < 4)
            {
                string score1Val = "";
                switch (score1)
                {
                    case 0:
                        score1Val = "Love";
                        break;
                    case 1:
                        score1Val = "Fifteen";
                        break;
                    case 2:
                        score1Val = "Thirty";
                        break;
                    case 3:
                        score1Val = "Forty";
                        break;
                    default:
                        break;

                }
                string score2Val = "";
                switch (score2)
                {
                    case 0:
                        score2Val = "Love";
                        break;
                    case 1:
                        score2Val = "Fifteen";
                        break;
                    case 2:
                        score2Val = "Thirty";
                        break;
                    case 3:
                        score2Val = "Forty";
                        break;
                    default:
                        break;

                }
                return "P1: " + score1Val + " P2: " + score2Val;
            }
            else {
                return score1 > score2 ? "P1 Won on Advantage" :"P2 Won on Advantage";
            }
            
        }

        public void PlayGame() {
            //Method plays a game with two players, playing points until a game is won
            string whoIsGameWinner = "";
            do
            {
                PlayPoint();
                whoIsGameWinner = checkForGameWinner();
            } while (string.IsNullOrWhiteSpace(whoIsGameWinner));
                //If there is a winner then write out winner, clear the Game Scores and break
                bool isPlayerOneWinner = _scoreKeeper.GameScore[_playerOne] > _scoreKeeper.GameScore[_playerTwo];
                _ = isPlayerOneWinner ? _scoreKeeper.SetScore[_playerOne]++ : _scoreKeeper.SetScore[_playerTwo]++;
                _ = isPlayerOneWinner ? _scoreKeeper.GameScore[_playerOne]-- : _scoreKeeper.GameScore[_playerTwo]--;
                string gameScore = getGameScore(_scoreKeeper.GameScore[_playerOne], _scoreKeeper.GameScore[_playerTwo]);
                Console.WriteLine(gameScore);
                _scoreKeeper.GameScore[_playerOne] = 0;
                _scoreKeeper.GameScore[_playerTwo] = 0;
                Console.WriteLine("Game Winner is: " + (isPlayerOneWinner?_playerOne.DisplayName:_playerTwo.DisplayName));      
            
        }

        public void PlayPoint() {
            Random umpire = new Random();
            _ = umpire.Next(0, 2) == 1 ? _scoreKeeper.GameScore[_playerOne]++ : _scoreKeeper.GameScore[_playerTwo]++;
        }

        private string checkForGameWinner() {
            int scoreOne = _scoreKeeper.GameScore[_playerOne];
            int scoreTwo = _scoreKeeper.GameScore[_playerTwo];
            if (scoreOne > 3 && scoreTwo < 3) return "Player One wins";
            else if (scoreTwo > 3 && scoreOne < 3) return "Player Two wins";
            else if (scoreOne > 3 && (scoreOne - scoreTwo) > 1) return "Player One Wins";
            else if (scoreTwo > 3 && (scoreTwo - scoreOne) > 1) return "Player Two Wins";
            else return "";
        }

        private string checkForSetWinner()
        {
            int scoreOne = _scoreKeeper.SetScore[_playerOne];
            int scoreTwo = _scoreKeeper.SetScore[_playerTwo];
            if (scoreOne > 5 && scoreTwo < 5) return "Player One wins";
            else if (scoreTwo > 5 && scoreOne < 5) return "Player Two wins";
            else if (scoreOne > 5 && (scoreOne - scoreTwo) > 1) return "Player One Wins";
            else if (scoreTwo > 5 && (scoreTwo - scoreOne) > 1) return "Player Two Wins";
            else return "";
        }

        private string checkForMatchWinner()
        {
            int scoreOne = _scoreKeeper.MatchScore[_playerOne];
            int scoreTwo = _scoreKeeper.MatchScore[_playerTwo];
            if (scoreOne ==2 ) return "Player One wins";
            else if (scoreTwo == 2) return "Player Two wins";
            else return "";
        }

    }
}
