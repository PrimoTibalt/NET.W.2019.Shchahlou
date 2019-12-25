using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13.Queue
{
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private int position = -1;

        private T[] elements;

        private bool IsDisposed = false;

        public T Current { get; set; }

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

        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
        }

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

        public void Reset()
        {
            position = -1;
        }
    }
}
