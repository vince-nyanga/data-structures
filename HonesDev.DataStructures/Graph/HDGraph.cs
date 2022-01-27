using System;
using System.Collections.Generic;
using System.Text;

namespace HonesDev.DataStructures.Graph
{
    public class HDGraph<T> where T: IComparable
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
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    stringBuilder.Append($"{current} ");
                    foreach(var neigbor in _adjacentList[current])
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
                var current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    stringBuilder.Append($"{current} ");
                    foreach (var neigbor in _adjacentList[current])
                    {
                        queue.Enqueue(neigbor);
                    }
                }
            }

            return stringBuilder.ToString().Trim();
        }

        public bool HasPath(T source, T destination)
        {
            if (!_adjacentList.ContainsKey(source) || !_adjacentList.ContainsKey(destination))
            {
                return false;
            }
            Queue<T> queue = new();
            HashSet<T> visited = new();
            queue.Enqueue(source);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.CompareTo(destination)==0)
                {
                    return true;
                }

                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    foreach (var neigbor in _adjacentList[current])
                    {
                        queue.Enqueue(neigbor);
                    }
                }
            }
            return false;
        }

        public int GetShortestPath(T source, T destination)
        {
            if (!_adjacentList.ContainsKey(source) || !_adjacentList.ContainsKey(destination))
            {
                return -1;
            }
            Queue<(T Vertex, int Distance)> queue = new();
            HashSet<T> visited = new();
            queue.Enqueue((source, 0));

            while (queue.Count > 0)
            {
                var (vertex, distance) = queue.Dequeue();
                if (vertex.CompareTo(destination) == 0)
                {
                    return distance;
                }

                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    foreach (var neigbor in _adjacentList[vertex])
                    {
                        queue.Enqueue((neigbor, distance + 1));
                    }
                }
            }
            return -1;
        }

        public int GetTotalConnectedComponents()
        {
            int count = 0;
            HashSet<T> visited = new();
            foreach(var vertex in _adjacentList.Keys)
            {
                if (Traverse(vertex, ref visited))
                {
                    count++;
                }
            }
            return count;
        }

        private bool Traverse(T vertex, ref HashSet<T> visited)
        {
            if (visited.Contains(vertex))
            {
                return false;
            }

            visited.Add(vertex);

            foreach (var neighbor in _adjacentList[vertex])
            {
                Traverse(neighbor, ref visited);
            }

            return true;
        }

        public int GetLargestComponentSize()
        {
            HashSet<T> visited = new();
            if (_adjacentList.Count == 0)
            {
                return 0;
            }
            var largestSize = 0;
            foreach(var vertex in _adjacentList.Keys)
            {
                var size = GetComponentSize(vertex, ref visited);
                if (size > largestSize)
                {
                    largestSize = size;
                }
            }

            return largestSize;
        }

        private int GetComponentSize(T vertex, ref HashSet<T> visited)
        {
            if (visited.Contains(vertex))
            {
                return int.MinValue;
            }

            var componentSize = 1;
            visited.Add(vertex);

            foreach(var neighbor in _adjacentList[vertex])
            {
                componentSize += GetComponentSize(neighbor, ref visited);
            }

            return componentSize;
        }
    }
}
