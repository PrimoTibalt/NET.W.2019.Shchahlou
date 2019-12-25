using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13
{
    public class Queue<T> : IEnumerable<T>
    {
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        private List<T> list;

        /// <summary>
        /// Initialize new instance of the class Queue<T>, which is empty
        /// </summary>
        public Queue()
        {
            list = new List<T>();
        }

        public Queue(IEnumerable<T> parameters) : base()
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("Value of parameter Queue cannot be null");
            }
            else
            {
                list = (List<T>)parameters; 
            }
            
        }

        public void Enqueue(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value of parameter for Queue cannot be null");
            }
            else
            {
                list.Add(value);
            }
        }

        public T Dequeue()
        {
            T value = list[0];
            list.Remove(list[0]);
            return value;
        }

        public T Peek()
        {
            return list[0];
        }

        public void Clear()
        {
            list = new List<T>();
        }

        public bool Contains(T value)
        {
            return list.Contains(value);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Queue.QueueEnumerator<T>(list.ToArray());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
