using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] data;
        private int count = 0;

        public int Count { get { return count; } }

        public MyList()
        {
            this.data = new T[1];
        }

        public void Add(T item)
        {
            if (count+1 > data.Length) {

                T[] dataNew = new T[count * 2];
                for(int i = 0; i < count; i++)  {
                    dataNew[i] = data[i];
                }
                this.data = dataNew;
            }
            this.data[count] = item;
            count++;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T i in data)
            {
                if (i == null) continue;
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T i in data)
            {
                if (i == null) continue;
                yield return i;
            }
        }
    }
}
