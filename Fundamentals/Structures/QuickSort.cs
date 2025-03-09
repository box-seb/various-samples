using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class QuickSort
    {
        public static void Sort(int[] array, int low, int high)
        {
            if(low >= high) return;

            var partition = Partition(array, low, high);

            Sort(array, low, partition - 1);
            Sort(array, partition + 1, high);
        }

        public static int Partition(int[] array, int low, int high)
        {
            var partition = array[high];
            var lowerValuePosition = low;

            for (int i = low; i < high; i++)
            {
                if (array[i] < partition)
                {
                    Swap(array, i, lowerValuePosition);
                    lowerValuePosition++;
                }
            }

            if(lowerValuePosition < high)
            {
                Swap(array, lowerValuePosition, high);
            }

            return lowerValuePosition;
        }

        private static void Swap(int[] array, int x, int y)
        {
            var tmp = array[x];
            array[x] = array[y];
            array[y] = tmp;
        }
    }
}
