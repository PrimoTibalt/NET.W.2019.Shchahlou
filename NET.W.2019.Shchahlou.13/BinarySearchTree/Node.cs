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
        public T value;

        /// <summary>
        /// Node with lower value
        /// </summary>
        public Node<T> left;

        /// <summary>
        /// Node with higer value
        /// </summary>
        public Node<T> right;
    }
}
