using NUnit.Framework;
using TennisMatch;

namespace TennisMatchTest
{
    public class MatchRunnerTests
    {
        private MatchRunner _matchRunner;
        private Player playerOne;
        private Player playerTwo;
        private ScoreKeeper scoreKeeper;
        [SetUp]
        public void Setup()
        {
            //Setup the Players playing a game of tennis
            playerOne = new Player("Nadal");
            playerTwo = new Player("Djokovic");
            scoreKeeper = new ScoreKeeper(playerOne, playerTwo);
            _matchRunner = new MatchRunner(playerOne,playerTwo, scoreKeeper);            
        }

        [Test]
        public void can_play_game()
        {
            _matchRunner.PlayGame();
            Assert.IsTrue((scoreKeeper.SetScore[playerOne]>0)||(scoreKeeper.SetScore[playerTwo]>0));
        }

        [Test]
        public void can_play_set()
        {
            _matchRunner.PlaySet();
            Assert.IsTrue((scoreKeeper.MatchScore[playerOne] > 0) || (scoreKeeper.MatchScore[playerTwo] > 0));
        }

        [Test]
        public void can_play_match() 
        {
            _matchRunner.Begin();
            Assert.IsTrue(playerOne.WinStatus == "Wins" || playerTwo.WinStatus == "Wins");
        }
        [Test]
        public void can_return_correct_points() {
            Assert.AreEqual(_matchRunner.getGameScore(3, 0), "P1: Forty P2: Love");
        }
    }
}