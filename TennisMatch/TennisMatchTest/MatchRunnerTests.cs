using NUnit.Framework;
using TennisMatch;

namespace TennisMatchTest
{
    public class MatchRunnerTests
    {
        private MatchRunner _matchRunner;
        [SetUp]
        public void Setup()
        {
            //Setup the Players playing a game of tennis
            Player playerOne = new Player("Nadal");
            Player playerTwo = new Player("Djokovic");
            _matchRunner = new MatchRunner(playerOne,playerTwo);            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}