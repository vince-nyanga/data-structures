using System;
using HonesDev.DataStructures.Graph;
using Xunit;

namespace HonesDev.DataStructures.UnitTests
{
    public class HDGraphTests
    {
        [Fact]
        public void AddVertex_ShouldAddVertex()
        {
            HDGraph<int> sut = new();

            sut.AddVertex(1);

            Assert.Equal(1, sut.Count);
        }

        [Fact]
        public void AddVertex_ShouldNotDuplicateVertex()
        {
            HDGraph<int> sut = new();

            sut.AddVertex(1);
            sut.AddVertex(1);

            Assert.Equal(1, sut.Count);
        }

        [Fact]
        public void GetTotalConnections_IfNotExist_ShouldThrowException()
        {
            HDGraph<int> sut = new();

            Assert.Throws<ArgumentException>(() => sut.GetTotalConnections(1));
        }

        [Fact]
        public void GetTotalConnections_ShouldReturnTotalConnections()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);

            var result = sut.GetTotalConnections(1);

            Assert.Equal(0, result);
        }

        [Fact]
        public void AddEdge_ShouldAddUndirectedEdge()
        {
            HDGraph<int> sut = new();

            sut.AddEdge(1, 2);

            Assert.Equal(1, sut.GetTotalConnections(1));
            Assert.Equal(1, sut.GetTotalConnections(2));
        }

        [Fact]
        public void HasEdge_WithNotExist_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();

            var result = sut.HasEdge(1, 2);

            Assert.False(result);
        }

        [Fact]
        public void HasEdge_WhenNoEdge_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);

            var result = sut.HasEdge(1, 2);

            Assert.False(result);
        }

        [Fact]
        public void HasEdge_WhenEdgeExists_ShouldReturnTrue()
        {
            HDGraph<int> sut = new();
            sut.AddEdge(1, 2);

            var result = sut.HasEdge(1, 2);

            Assert.True(result);
        }

        [Fact]
        public void RemoveVertex_ShouldRemoveVertex()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);

            var result = sut.RemoveVertex(1);

            Assert.Equal(0, sut.Count);
            Assert.True(result);
        }

        [Fact]
        public void RemoveVertex_IfNotExist_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();

            var result = sut.RemoveVertex(1);

            Assert.False(result);
        }

        [Fact]
        public void RemoveVertex_IfContainsEdges_ShouldRemoveConnectionsInOtherVertices()
        {
            HDGraph<int> sut = new();
            sut.AddEdge(1, 2);

            var result = sut.RemoveVertex(1);

            Assert.Equal(0, sut.GetTotalConnections(2));
            Assert.True(result);
        }

        [Fact]
        public void RemoveEdge_InVertexNotExist_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();

            var result = sut.RemoveEdge(1, 2);

            Assert.False(result);
        }

        [Fact]
        public void RemoveEdge_InEdgeNotExist_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);
            sut.AddVertex(2);

            var result = sut.RemoveEdge(1, 2);

            Assert.False(result);
        }

        [Fact]
        public void RemoveEdge_ShouldRemoveEdge()
        {
            HDGraph<int> sut = new();
            sut.AddEdge(1, 2);

            var result = sut.RemoveEdge(1, 2);

            Assert.True(result);
            Assert.Equal(0, sut.GetTotalConnections(1));
            Assert.Equal(0, sut.GetTotalConnections(2));
        }

        [Fact]
        public void RunDepthFirstTraversal_IfStartNotExists_ShouldReturnNull()
        {
            HDGraph<int> sut = new();

            var result = sut.RunDepthFirstTraversal(1);

            Assert.Null(result);
        }

        [Fact]
        public void RunDepthFirstTraversal_ShouldTraverseGrap()
        {
            HDGraph<int> sut = new();
            sut.AddEdge(1, 2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 2);
            sut.AddEdge(2, 4);
            sut.AddEdge(3, 5);
            var expected = "1 3 5 2 4";

            var result = sut.RunDepthFirstTraversal(1);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void RunBreadthFirstTraversal_IfStartNotExists_ShouldReturnNull()
        {
            HDGraph<int> sut = new();

            var result = sut.RunBreadthFirstTraversal(1);

            Assert.Null(result);
        }

        [Fact]
        public void RunBreadthFirstTraversal_ShouldTraverseGrap()
        {
            HDGraph<int> sut = new();
            sut.AddEdge(1, 2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 2);
            sut.AddEdge(2, 4);
            sut.AddEdge(3, 5);
            var expected = "1 2 3 4 5";

            var result = sut.RunBreadthFirstTraversal(1);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HasPath_IfEmpty_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();

            var result = sut.HasPath(1, 2);

            Assert.False(result);
        }

        [Fact]
        public void HasPath_IfNoPath_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);
            sut.AddVertex(2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 4);

            var result = sut.HasPath(1, 2);

            Assert.False(result);
        }

        [Fact]
        public void HasPath_IfPath_ShouldReturnTrue()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);
            sut.AddVertex(2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 4);

            var result = sut.HasPath(1, 3);

            Assert.True(result);
        }

        [Fact]
        public void HasPath_IfSourceAndDestinationSame_ShouldReturnTrue()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);
            sut.AddVertex(2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 4);

            var result = sut.HasPath(1, 1);

            Assert.True(result);
        }

        [Fact]
        public void GetShortestPath_IfEmpty_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();

            var result = sut.GetShortestPath(1, 2);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void GetShortestPath_IfNoPath_ShouldReturnFalse()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);
            sut.AddVertex(2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 4);

            var result = sut.GetShortestPath(1, 2);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void GetShortestPath_IfPath_ShouldReturnDistance()
        {
            HDGraph<int> sut = new();
            sut.AddEdge(1, 2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 2);
            sut.AddEdge(2, 4);
            sut.AddEdge(3, 5);

            var result = sut.GetShortestPath(1, 3);

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetShortestPath_IfSourceAndDestinationSame_ShouldReturnZero()
        {
            HDGraph<int> sut = new();
            sut.AddVertex(1);
            sut.AddVertex(2);
            sut.AddEdge(1, 3);
            sut.AddEdge(3, 4);

            var result = sut.GetShortestPath(1, 1);

            Assert.Equal(0, result);
        }
    }
}
