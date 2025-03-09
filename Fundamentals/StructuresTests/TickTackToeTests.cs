using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace StructuresTests
{
    public class TickTackToeTests
    {
        [Test]
        public void Game()
        {
            var p1 = new Queue<Tuple<int, int>>();
            p1.Enqueue(new Tuple<int, int>(0, 0));
            p1.Enqueue(new Tuple<int, int>(0, 1));
            p1.Enqueue(new Tuple<int, int>(0, 2));

            var p2 = new Queue<Tuple<int, int>>();
            p2.Enqueue(new Tuple<int, int>(1, 0));
            p2.Enqueue(new Tuple<int, int>(1, 1));
            p2.Enqueue(new Tuple<int, int>(1, 2));


            var winner = 0;
            var game = new TickTackToe();

            while (winner == 0 && p1.Any() && p2.Any())
            {
                winner = game.PlayerOneMove(p1.Dequeue());

                if(winner == 0)
                {
                    winner = game.PlayerTwoMove(p2.Dequeue());
                }
            }

            Assert.IsTrue(winner == 1);
        }
    }
}
