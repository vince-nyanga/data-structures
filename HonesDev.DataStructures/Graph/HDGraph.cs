using System;
using System.Collections.Generic;
using System.Text;

namespace HonesDev.DataStructures.Graph
{
    public class HDGraph<T>
    {
        private readonly Dictionary<T, HashSet<T>> _adjacentList;

        public HDGraph()
        {
            _adjacentList = new Dictionary<T, HashSet<T>>();
        }


        public void AddVertex(T vertex)
        {
            if (!_adjacentList.ContainsKey(vertex))
            {
                _adjacentList[vertex] = new HashSet<T>();
            }
        }

        public int GetTotalConnections(T vertex)
        {
            if (!_adjacentList.ContainsKey(vertex))
            {
                throw new ArgumentException($"vertext {vertex} does not exist");
            }

            return _adjacentList[vertex].Count;
        }

        public void AddEdge(T source, T destination)
        {
            AddVertex(source);
            AddVertex(destination);

            _adjacentList[source].Add(destination);
            _adjacentList[destination].Add(source);
        }

        public bool HasEdge(T source, T destination)
        {
            if (!_adjacentList.ContainsKey(source))
            {
                return false;
            }

            return _adjacentList[source].Contains(destination);
        }

        public int Count => _adjacentList.Keys.Count;

        public bool RemoveVertex(T vertex)
        {
            if (!_adjacentList.ContainsKey(vertex))
            {
                return false;
            }

            foreach(var connection in _adjacentList[vertex])
            {
                _adjacentList[connection].Remove(vertex);
            }

            _adjacentList.Remove(vertex);
            return true;
        }

        public bool RemoveEdge(T source, T destination)
        {
            if (!_adjacentList.ContainsKey(source) || !_adjacentList[source].Contains(destination))
            {
                return false;
            }

            _adjacentList[source].Remove(destination);
            _adjacentList[destination].Remove(source);

            return true;
        }

        public string RunDepthFirstTraversal(T start)
        {
            if (!_adjacentList.ContainsKey(start))
            {
                return null;
            }

            StringBuilder stringBuilder = new();
            Stack<T> stack = new();
            HashSet<T> visited = new();
            stack.Push(start);

            while(stack.Count > 0)
            {
                var item = stack.Pop();
                if (!visited.Contains(item))
                {
                    visited.Add(item);
                    stringBuilder.Append($"{item} ");
                    foreach(var neigbor in _adjacentList[item])
                    {
                        stack.Push(neigbor);
                    }
                }
            }

            return stringBuilder.ToString().Trim();
        }

        public string RunBreadthFirstTraversal(T start)
        {
            if (!_adjacentList.ContainsKey(start))
            {
                return null;
            }

            StringBuilder stringBuilder = new();
            Queue<T> queue = new();
            HashSet<T> visited = new();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (!visited.Contains(item))
                {
                    visited.Add(item);
                    stringBuilder.Append($"{item} ");
                    foreach (var neigbor in _adjacentList[item])
                    {
                        queue.Enqueue(neigbor);
                    }
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
