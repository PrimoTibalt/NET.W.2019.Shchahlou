using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13.BinarySearchTree
{
    /// <summary>
    /// Type to represent node of the BinarySearchTree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The value of Node, to compare him with others.
        /// </summary>
        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Try to set null as value of the node.");
                }
                else
                {
                    this.value = value;
                }
            }
        }

        /// <summary>
        /// Node with lower value
        /// </summary>
        public Node<T> Left
        {
            get
            {
                return this.left;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Try to set null as value of the left node.");
                }
                else
                {
                    this.left = value;
                }
            }
        }

        /// <summary>
        /// Node with higer value
        /// </summary>
        public Node<T> Right
        {
            get
            {
                return this.right;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Try to set null as value of the right node.");
                }
                else
                {
                    this.right = value;
                }
            }
        }

        private T value;

        private Node<T> left;

        private Node<T> right;

        /// <summary>
        /// Sets the value for Node.
        /// </summary>
        /// <param name="val"></param>
        public Node(T val)
        {
            if (val == null)
            {
                throw new ArgumentNullException("Throw null as value for node.");
            }
            else
            {
                this.Value = val;
            }
        }
    }
}
