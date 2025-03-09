using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class WordCloud
    {
        HashSet<(int, int)> occupied = new HashSet<(int, int)>();

        public void PlaceWord(int x, int y, int width, int height)
        {
            for(int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    occupied.Add((i, j));   
                }
            }
        }

        public bool IsConflict(int x, int y, int width, int height)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if (occupied.Contains((i, j))) return true;
                }
            }

            return false;
        }
    }
}
