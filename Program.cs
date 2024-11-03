using MaxFlow.Algorithms;
using MaxFlow.Graphs;
using MaxFlow.Graphs.Algorithms;

namespace MaxFlow
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Inicializa o grafo com 50 vértices (de 0 a 49)
            var graph = new MatrixAdjacencies(50);

            // Adiciona as arestas com os pesos fornecidos
            graph.AddAdjacency(0, 1, 16);
            graph.AddAdjacency(0, 2, 22);
            graph.AddAdjacency(1, 2, 21);
            graph.AddAdjacency(1, 3, 17);
            graph.AddAdjacency(2, 3, 29);
            graph.AddAdjacency(2, 4, 15);
            graph.AddAdjacency(3, 4, 21);
            graph.AddAdjacency(3, 5, 21);
            graph.AddAdjacency(4, 5, 17);
            graph.AddAdjacency(4, 6, 19);
            graph.AddAdjacency(5, 6, 27);
            graph.AddAdjacency(5, 7, 14);
            graph.AddAdjacency(6, 7, 18);
            graph.AddAdjacency(6, 8, 11);
            graph.AddAdjacency(7, 8, 30);
            graph.AddAdjacency(7, 9, 23);
            graph.AddAdjacency(8, 9, 29);
            graph.AddAdjacency(8, 10, 25);
            graph.AddAdjacency(9, 10, 25);
            graph.AddAdjacency(9, 11, 23);
            graph.AddAdjacency(10, 11, 13);
            graph.AddAdjacency(10, 12, 21);
            graph.AddAdjacency(11, 12, 22);
            graph.AddAdjacency(11, 13, 28);
            graph.AddAdjacency(12, 13, 12);
            graph.AddAdjacency(12, 14, 20);
            graph.AddAdjacency(13, 14, 20);
            graph.AddAdjacency(13, 15, 13);
            graph.AddAdjacency(14, 15, 19);
            graph.AddAdjacency(14, 16, 19);
            graph.AddAdjacency(15, 16, 20);
            graph.AddAdjacency(15, 17, 15);
            graph.AddAdjacency(16, 17, 18);
            graph.AddAdjacency(16, 18, 12);
            graph.AddAdjacency(17, 18, 21);
            graph.AddAdjacency(17, 19, 30);
            graph.AddAdjacency(18, 19, 23);
            graph.AddAdjacency(18, 20, 18);
            graph.AddAdjacency(19, 20, 15);
            graph.AddAdjacency(19, 21, 14);
            graph.AddAdjacency(20, 21, 16);
            graph.AddAdjacency(20, 22, 27);
            graph.AddAdjacency(21, 22, 16);
            graph.AddAdjacency(21, 23, 10);
            graph.AddAdjacency(22, 23, 24);
            graph.AddAdjacency(22, 24, 12);
            graph.AddAdjacency(23, 24, 18);
            graph.AddAdjacency(23, 25, 11);
            graph.AddAdjacency(24, 25, 17);
            graph.AddAdjacency(24, 26, 15);
            graph.AddAdjacency(25, 26, 20);
            graph.AddAdjacency(25, 27, 27);
            graph.AddAdjacency(26, 27, 16);
            graph.AddAdjacency(26, 28, 14);
            graph.AddAdjacency(27, 28, 11);
            graph.AddAdjacency(27, 29, 19);
            graph.AddAdjacency(28, 29, 21);
            graph.AddAdjacency(28, 30, 29);
            graph.AddAdjacency(29, 30, 21);
            graph.AddAdjacency(29, 31, 21);
            graph.AddAdjacency(30, 31, 30);
            graph.AddAdjacency(30, 32, 11);
            graph.AddAdjacency(31, 32, 11);
            graph.AddAdjacency(31, 33, 18);
            graph.AddAdjacency(32, 33, 10);
            graph.AddAdjacency(32, 34, 25);
            graph.AddAdjacency(33, 34, 27);
            graph.AddAdjacency(33, 35, 28);
            graph.AddAdjacency(34, 35, 20);
            graph.AddAdjacency(34, 36, 24);
            graph.AddAdjacency(35, 36, 14);
            graph.AddAdjacency(35, 37, 10);
            graph.AddAdjacency(36, 37, 27);
            graph.AddAdjacency(36, 38, 10);
            graph.AddAdjacency(37, 38, 19);
            graph.AddAdjacency(37, 39, 26);
            graph.AddAdjacency(38, 39, 17);
            graph.AddAdjacency(38, 40, 24);
            graph.AddAdjacency(39, 40, 17);
            graph.AddAdjacency(39, 41, 22);
            graph.AddAdjacency(40, 41, 17);
            graph.AddAdjacency(40, 42, 29);
            graph.AddAdjacency(41, 42, 11);
            graph.AddAdjacency(41, 43, 25);
            graph.AddAdjacency(42, 43, 22);
            graph.AddAdjacency(42, 44, 13);
            graph.AddAdjacency(43, 44, 11);
            graph.AddAdjacency(43, 45, 17);
            graph.AddAdjacency(44, 45, 29);
            graph.AddAdjacency(44, 46, 25);
            graph.AddAdjacency(45, 46, 30);
            graph.AddAdjacency(45, 47, 24);
            graph.AddAdjacency(46, 47, 30);
            graph.AddAdjacency(46, 48, 23);
            graph.AddAdjacency(47, 48, 12);
            graph.AddAdjacency(47, 49, 16);
            graph.AddAdjacency(48, 49, 11);

            // Executa o algoritmo de fluxo máximo
            var maxFlow = new MaxFlowAlgorithm(graph);
            maxFlow.Run(0, 49);

            // Exibe o resultado do fluxo máximo
            Console.WriteLine(maxFlow);
        }
    }
};
