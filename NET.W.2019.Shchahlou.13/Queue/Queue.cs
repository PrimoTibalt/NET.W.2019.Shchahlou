using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13
{
    /// <summary>
    /// Implementation of data structure QUEUE, with FIFO
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// Set Queue of elements in parameters
        /// </summary>
        /// <param name="parameters"></param>
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

        /// <summary>
        /// Add value in Queue
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// Delete first element
        /// </summary>
        /// <returns>First element of the queue</returns>
        public T Dequeue()
        {
            T value = list[0];
            list.Remove(list[0]);
            return value;
        }

        /// <summary>
        /// Dont deletes first element
        /// </summary>
        /// <returns>First elements of the queue</returns>
        public T Peek()
        {
            return list[0];
        }

        /// <summary>
        /// Deletes elements from queue
        /// </summary>
        public void Clear()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Checkes, does value contains in queue
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return list.Contains(value);
        }

        /// <summary>
        /// Dont have implementation
        /// Should copy elements from queue to input array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To foreach through the queue
        /// </summary>
        /// <returns>QueueEnumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Queue.QueueEnumerator<T>(list.ToArray());
        }

        /// <summary>
        /// Use standart list's enumerator to foreach queue
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
