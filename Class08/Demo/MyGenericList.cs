using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    public class MyGenericList<T> : IEnumerable<T>
    {
        // Fields
        T[] items;
        int count;

        // Constructors
        public MyGenericList(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException();

            items = new T[capacity];
        }

        public MyGenericList() : this(5)
        {
        }

        // Properties
        public int Count => count;

        public T this[int index] => items[index];

        public void Add(T value)
        {
            // Ran out of space!
            if (items.Length == count)
            {
                // Double the size of the array
                Array.Resize(ref items, count * 2);
            }

            items[count] = value;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        // Non-generic, just do this because we have to
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
