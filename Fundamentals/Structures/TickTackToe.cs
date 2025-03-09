using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class TickTackToe
    {
        int[,] game = new int[3,3];
        const int P1 = 1;
        const int P2 = 2;

        public int PlayerOneMove(Tuple<int, int> tuple)
        {
            game[tuple.Item1, tuple.Item2] = P1;
            return IsWinner(P1);

        }

        public int PlayerTwoMove(Tuple<int, int> tuple)
        {
            game[tuple.Item1, tuple.Item2] = P2;
            return IsWinner(P2);
        }

        int IsWinner(int player)
        {
            for (int x = 0; x < 3; x++)
            {
                int counter = 0;
                for (int y = 0; y < 3; y++)
                {
                    if(game[x,y] == player) counter++;
                }

                if (counter == 3) return player;
            }

            for (int y = 0; y < 3; y++)
            {
                int counter = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (game[x, y] == player) counter++;
                }

                if (counter == 3) return player;
            }

            return 0;
        }
    }
}
