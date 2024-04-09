using System;
namespace Haffman
{
    public class PriorityQueue<T>
    {
        private List<T> data;
        private Comparison<T> comparison;

        public int Count { get { return data.Count; } }

        public PriorityQueue(Comparison<T> comparison)
        {
            this.data = new List<T>();
            this.comparison = comparison;
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int i = Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (comparison(data[parent], data[i]) <= 0)
                    break;
                T temp = data[i];
                data[i] = data[parent];
                data[parent] = temp;
                i = parent;
            }
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");
            T frontItem = data[0];
            data[0] = data[Count - 1];
            data.RemoveAt(Count - 1);

            int lastIndex = Count - 1;
            int index = 0;
            while (true)
            {
                int childIndex = index * 2 + 1;
                if (childIndex > lastIndex)
                    break;
                int rightChild = childIndex + 1;
                if (rightChild <= lastIndex && comparison(data[childIndex], data[rightChild]) > 0)
                    childIndex = rightChild;
                if (comparison(data[index], data[childIndex]) <= 0)
                    break;
                T tmp = data[index];
                data[index] = data[childIndex];
                data[childIndex] = tmp;
                index = childIndex;
            }

            return frontItem;
        }
    }
}

