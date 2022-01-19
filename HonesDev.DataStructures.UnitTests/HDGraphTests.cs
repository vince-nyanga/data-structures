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
    }
}
