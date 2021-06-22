using NUnit.Framework;
using TennisMatch;

namespace TennisMatchTest
{
    public class MatchRunnerTests
    {
        private MatchRunner _matchRunner;
        private Player playerOne;
        private Player playerTwo;
        [SetUp]
        public void Setup()
        {
            //Setup the Players playing a game of tennis
            playerOne = new Player("Nadal");
            playerTwo = new Player("Djokovic");
            _matchRunner = new MatchRunner(playerOne,playerTwo);            
        }

        [Test]
        public void can_play_game()
        {
            _matchRunner.PlayGame();
            Assert.IsTrue((playerOne.Score.SetScore>0)||(playerTwo.Score.SetScore>0));
        }

        [Test]
        public void can_play_set()
        {
            _matchRunner.PlaySet();
            Assert.IsTrue((playerOne.Score.MatchScore > 0) || (playerTwo.Score.MatchScore > 0));
        }

        [Test]
        public void can_play_match() 
        {
            _matchRunner.Begin();
            Assert.IsTrue(playerOne.WinStatus == "Wins" || playerTwo.WinStatus == "Wins");
        }
    }
}