using NUnit.Framework;
using System;
using TennisMatch;

namespace TennisMatchTest
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void can_initialise_player()
        {
            Player player = new Player("Nadal");
            Assert.IsNotNull(player.DisplayName);
        }

        [Test]
        public void throws_error_on_empty_name() {
            Assert.Throws<ArgumentNullException>(()=> { 
                Player player = new Player("");
            });
        }
    }
}