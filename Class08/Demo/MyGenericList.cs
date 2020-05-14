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

        public bool Remove(T value)
        {
            int indexToRemove = -1;

            // Find the item
            for (int i = 0; i < count; i++)
            {
                // Compile error: if (items[i] == value)

                // Possible NullRef if items[i] is null
                // if (items[i].Equals(value))

                // Boxing equality check that is null-safe
                // if (object.Equals(items[i], value))

                // Most correct and performant - no boxing
                if (EqualityComparer<T>.Default.Equals(items[i], value))
                {
                    indexToRemove = i;
                    break;
                }
            }

            return RemoveAt(indexToRemove);
        }

        public bool RemoveAt(int indexToRemove)
        {
            if (indexToRemove < 0)
            {
                return false;
            }

            // Shift everything
            for (int i = indexToRemove; i < count; i++)
            {
                items[i] = items[i + 1];
            }

            items[count--] = default;
            return true;
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
