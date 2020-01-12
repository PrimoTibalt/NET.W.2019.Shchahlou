namespace NET.W._2019.Shchahlou._13.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Handmade enumerator for queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private int position = -1;

        private T[] elements;

        private bool IsDisposed = false;

        /// <summary>
        /// Current element.
        /// </summary>
        public T Current
        {
            get
            {
                return elements[position];
            }
        }

        /// <summary>
        /// Elements for foreach.
        /// </summary>
        /// <param name="elements"></param>
        public QueueEnumerator(T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Nothing to enumerate!");
            }
            else
            {
                this.elements = elements;
            }
        }

        object IEnumerator.Current 
        { 
            get
            {
                if (position == -1 || position >= elements.Length)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return elements[position];
                }
            }
        }

        /// <summary>
        /// GC method.
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;
        }

        /// <summary>
        /// Tryies to move to the next element of queue.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets pointer to -1.
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
    }
}
