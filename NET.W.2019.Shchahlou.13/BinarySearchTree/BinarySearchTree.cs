using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13.BinarySearchTree
{
    /// <summary>
    /// Implementation of BinaryTree data structure
    /// Can go through tree 3 ways:
    /// 1-preorder 2-inorder 3-postorder
    /// </summary>
    public sealed class BinarySearchTree<T>
    {
        /// <summary>
        /// Contains nodes of the Tree.
        /// </summary>
        private List<Node<T>> elements;

        /// <summary>
        /// Initialize new Tree without nodes.
        /// </summary>
        public BinarySearchTree()
        {
            elements = new List<Node<T>>();
        }

        /// <summary>
        /// Initialize new Tree with one node.
        /// </summary>
        /// <param name="element"></param>
        public BinarySearchTree(T element) : base()
        {
            this.Insert(element);
        }

        /// <summary>
        /// Initialize new Tree with nodes from array.
        /// </summary>
        /// <param name="arrayOfElements"></param>
        public BinarySearchTree(T[] arrayOfElements) : base()
        {
            if (arrayOfElements == null)
            {
                throw new ArgumentNullException("Passed null as argument(array) in constructor.");
            }

            foreach (T element in arrayOfElements)
            {
                this.Insert(element);
            }
        }

        /// <summary>
        /// Inserts one element(node) in Tree.
        /// </summary>
        /// <param name="element"></param>
        public void Insert(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Passed null as argument in constructor.");
            }

            if (elements.Count > 0)
            {
                // TO DO : call of function to Tree traversal.
            }
            else
            {
                elements.Add(new Node<T> { value = element });
            }
        }

        /// <summary>
        /// Implementation of inorder Tree traversal.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Node<T>> Inorder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation of preorder Tree traversal.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Node<T>> Preorder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation of postorder Tree traversal.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Node<T>> Postorder()
        {
            throw new NotImplementedException();
        }
    }
}
