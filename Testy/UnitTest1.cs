using QuikGraph;
using QuikGraph.Serialization;
using System.Xml;

namespace Testy
{
    public class Tests
    {
        #region Grafowe
        Edge<int>[] edges;
        AdjacencyGraph<int, Edge<int>>? graph, graph2;
        [SetUp]
        public void Setup()
        {
            edges = new[] { new Edge<int>(1, 2), new Edge<int>(0, 1) };
            graph = edges.ToAdjacencyGraph<int, Edge<int>>();
            graph2 = null;
            Console.WriteLine("Wykonuję testy");
        }

        [Test]
        public void PiszGraf()
        {
            foreach (var vertex in graph.Vertices)
            {
                Console.WriteLine(vertex);
            }
            foreach (var edge in graph.Edges)
            {
                Console.WriteLine(edge);
            }
            Assert.Pass("Udało się wypisać");
        }
        [Test]
        public void SprawdźWymiaryGrafu()
        {
            Assert.That(edges, Has.Length.EqualTo(2));//można dać wincyj Assertów
        }
        [Test(ExpectedResult = 3)]
        public int LiczbaWierzchołków()
        {
            return graph.VertexCount;
        }
        [Test]
        public void Zapisz()
        {
            using (var xmlWriter = XmlWriter.Create("graf.xml"))
            {
                graph.SerializeToGraphML<int,Edge<int>, AdjacencyGraph<int, Edge<int>>>(xmlWriter);
            }
        }
        [Test]
        public void Wczytaj()
        {
            using (var xmlReader = XmlReader.Create("graf.xml"))
            {
                graph2.DeserializeFromGraphML(
                    xmlReader,
                    id => int.Parse(id),
                    (source, target, id) => new Edge<int>(source, target));//uchu nie wczytuje
            }
            Assert.That(graph2, Is.EqualTo(graph));
        }
        #endregion
    }
}
