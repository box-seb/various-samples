using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class MaxSubarray
    {
        public static int[] GetMax2(int[] array, int sum)
        {
            var maxArrayStart = 0;
            var maxArrayEnd = 0;
            var maxSum = 0;

            var currentStart = 0;
            var currentEnd = 0;
            var currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                currentEnd = i;

                currentSum = SumSubArray(currentStart, currentEnd, array);

                if (currentSum > sum)
                {
                    while(currentSum > sum)
                    {
                        currentStart++;
                        currentSum = SumSubArray(currentStart, currentEnd, array);
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxArrayStart = currentStart;
                    maxArrayEnd = currentEnd;
                }

                Console.WriteLine(currentSum);
            }

            return [];
        }

        public static int[] GetMax(int[] array, int sum)
        {
            var maxSubArray = new List<int>();
            var maxSum = 0;

            var indexQueue = new Queue<int>();
            var currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                indexQueue.Enqueue(i);

                currentSum = SumSubArray(indexQueue, array);

                if (currentSum > sum)
                {
                    while (currentSum > sum)
                    {
                        indexQueue.Dequeue();
                        currentSum = SumSubArray(indexQueue, array);
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSubArray = indexQueue.ToList();
                }

                Console.WriteLine(currentSum);
            }

            return maxSubArray.ToArray();
        }

        static int SumSubArray(Queue<int> indexes, int[] array)
        {
            var sum = 0;

            foreach (var item in indexes)
            {
                sum += array[item];
            }

            return sum;
        }

        static int SumSubArray(int start, int end, int[] array)
        {
            var sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
