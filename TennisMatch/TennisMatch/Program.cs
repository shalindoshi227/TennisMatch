using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup the Players playing a game of tennis
            Player playerOne = new Player("Nadal");
            Player playerTwo = new Player("Djokovic");
            ScoreKeeper scoreKeeper = new ScoreKeeper(playerOne, playerTwo);
            MatchRunner matchRunner = new MatchRunner(playerOne, playerTwo, scoreKeeper);
            matchRunner.Begin();
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();

        }
    }
}
