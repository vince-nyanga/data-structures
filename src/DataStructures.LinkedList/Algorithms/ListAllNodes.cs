using System;
using DataStructures.LinkedList.Models;

namespace Datastructures.LinkedList.Algorithms
{
    public class ListAllNodes : IAlgorithm
    {
        public void Run()
        {
            var linkedList = new LinkedList<int>();
            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            var node = linkedList.First;

            while(node is not null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}