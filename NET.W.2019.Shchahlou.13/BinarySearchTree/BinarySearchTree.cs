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
        /// To compare nodes.
        /// </summary>
        private IComparer<T> comparer;

        /// <summary>
        /// Contains nodes of the Tree.
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// Root of the tree.
        /// </summary>
        public Node<T> Root
        {
            get
            {
                return root;
            }
        }

        /// <summary>
        /// Initialize new Tree without nodes.
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
            this.comparer = new Comparers.DefaultComparer<T>();
        }

        /// <summary>
        /// Initialize new Tree with one node.
        /// </summary>
        /// <param name="element"></param>
        public BinarySearchTree(T element) : this()
        {
            this.Insert(element, null);
        }

        /// <summary>
        /// Initialize new Tree with nodes from array.
        /// </summary>
        /// <param name="arrayOfElements"></param>
        public BinarySearchTree(T[] arrayOfElements) : this(arrayOfElements[0])
        {
            if (arrayOfElements == null)
            {
                throw new ArgumentNullException("Passed null as argument(array) in constructor.");
            }

            for (int i = 1; i < arrayOfElements.Length; i++)
            {
                // i = 1 because we already have arrayOfElements[0] in List.
                this.Insert(arrayOfElements[i], this.Root);
            }
        }

        /// <summary>
        /// Sets comparer to insert element in the tree.
        /// </summary>
        /// <param name="newComparer"></param>
        public void SetComparer(IComparer<T> newComparer)
        {
            if (newComparer == null)
            {
                throw new ArgumentNullException("Throw null as comparer.");
            }

            this.comparer = newComparer;
        }

        /// <summary>
        /// It was easyiest way to don't give chance to user change root.
        /// </summary>
        /// <param name="element"></param>
        public void Insert(T element) => this.Insert(element, this.root);

        /// <summary>
        /// Inserts one element(node) in Tree.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="node"></param>
        private void Insert(T element, Node<T> node)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Passed null as argument in constructor.");
            }

            if (node == null)
            {
                this.root = new Node<T>(element);
            }
            else
            {
                switch (comparer.Compare(element, node.Value))
                {
                    case 1:
                        if (node.Right == null)
                        {
                            node.Right = new Node<T>(element);
                        }
                        else
                        {
                            this.Insert(element, node.Right);
                        }

                        break;
                    case 0:
                        throw new ArgumentException("Already have this element in the Tree.");
                    case -1:
                        if (node.Left == null)
                        {
                            node.Left = new Node<T>(element);
                        }
                        else
                        {
                            this.Insert(element, node.Left);
                        }

                        break;
                    default:
                        throw new SystemException("Comparer throw strange result.(not 1 or 0 or -1.");
                }
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
