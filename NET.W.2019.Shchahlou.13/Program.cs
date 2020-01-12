using System;
using System.Collections.Generic;

namespace NET.W._2019.Shchahlou._13
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //System.Collections.Generic.Queue<int> intQueue = new System.Collections.Generic.Queue<int>();
            //intQueue.Enqueue(10);
            //intQueue.Enqueue(20);
            //intQueue.Enqueue(15);
            //Console.WriteLine("System...Generic");
            //Console.WriteLine(intQueue.Count);
            //Console.WriteLine(intQueue.Dequeue());
            //Console.WriteLine(intQueue.Count);
            //Console.WriteLine("foreach");
            //foreach(var element in intQueue)
            //{
            //    Console.WriteLine(element);
            //}
            //Console.WriteLine("My Queue");
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(10);
            //queue.Enqueue(20);
            //queue.Enqueue(15);
            //Console.WriteLine(queue.Count);
            //Console.WriteLine(queue.Dequeue());
            //Console.WriteLine(queue.Count);
            //Console.WriteLine("foreach");
            //foreach (var element in queue)
            //{
            //    Console.WriteLine(element);
            //}
            BinarySearchTree.BinarySearchTree<int> tree = new BinarySearchTree.BinarySearchTree<int>(10);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(2);
            tree.Insert(12);
            tree.Insert(15);
            tree.Insert(1);
            Console.WriteLine("Preorder");
            foreach(var i in tree.Preorder())
            {
                Console.WriteLine(i.Value);
            }

            Console.WriteLine("Inorder");
            foreach (var i in tree.Inorder())
            {
                Console.WriteLine(i.Value);
            }

            Console.WriteLine("Postorder");
            foreach (var i in tree.Postorder())
            {
                Console.WriteLine(i.Value);
            }
        }
    }
}
