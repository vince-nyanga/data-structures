using System;
using System.Collections.Generic;

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

        public int Count => _adjacentList.Keys.Count;

    }
}
