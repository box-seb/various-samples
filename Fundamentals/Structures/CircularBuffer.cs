using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class CircularBuffer
    {
        int capacity;
        int[] buffer;
        int head = 0;
        int tail = 0;
        bool full;

        public CircularBuffer(int capacity)
        {
            this.capacity = capacity;
            buffer = new int[capacity];
        }

        public int[] Add(int value)
        {
            if (tail == head)
            {
                full = true;
            }

            buffer[tail] = value;
            tail = (tail + 1) % capacity;
            head = tail;

            return buffer;
        }

        public int Get()
        {
            if (full)
            {
                var value = buffer[head];
                buffer[head] = 0;
                full = false;
                head = (head + 1) % capacity;
                return value;
            }
            else 
            {
                if (tail == head)
                {
                    throw new Exception("Buffer empty");
                }

                var value = buffer[head];
                buffer[head] = 0;
                head = (head + 1) % capacity;

                return value;
            }
        }

        public bool IsFull => full;
        public bool IsEmpty => !full && tail == head;
    }
}
