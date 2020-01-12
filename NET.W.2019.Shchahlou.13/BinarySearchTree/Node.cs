namespace NET.W._2019.Shchahlou._13.BinarySearchTree
{
    using System;

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

        /// <summary>
        /// If value is null - node is main.
        /// </summary>
        public Node<T> Root
        {
            get
            {
                return root;
            }

            set
            {
                this.root = value;
            }
        }

        private T value;

        private Node<T> left;

        private Node<T> right;

        private Node<T> root;

        /// <summary>
        /// Sets the value for Node.
        /// </summary>
        /// <param name="val"></param>
        public Node(T val)
        {
            this.Value = val;
        }

        /// <summary>
        /// Sets Root and value for node.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="myRoot"></param>
        public Node(T val, Node<T> myRoot) : this(val)
        {
            this.root = myRoot;
        }
    }
}
