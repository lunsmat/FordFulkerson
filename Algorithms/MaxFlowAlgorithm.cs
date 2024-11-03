using MaxFlow.Graphs;
using MaxFlow.Graphs.Algorithms;

namespace MaxFlow.Algorithms
{
    class MaxFlowAlgorithm(IGraph graph)
    {
        private readonly IGraph Graph = graph;

        private readonly IGraph ResidualGraph = graph.Copy();

        private readonly IGraph ResultGraph = graph.Copy();

        private int MaxFlow = 0;

        public void Run(int sink, int terminal)
        {
            ResultGraph.Reset();
            int i, j;
            var bfs = new BreadthFirstSearch(ResidualGraph);

            while (bfs.Run(sink, terminal))
            {
                int pathFlow = int.MaxValue;

                for (j = terminal; j != sink; j = bfs.GetPredecessor(j))
                {
                    i = bfs.GetPredecessor(j);
                    pathFlow =  int.Min(pathFlow, ResidualGraph.GetWeight(i, j));
                }

                for (j = terminal; j != sink; j = bfs.GetPredecessor(j))
                {
                    i = bfs.GetPredecessor(j);
                    ResidualGraph.AddAdjacency(i, j, ResidualGraph.GetWeight(i, j) - pathFlow);
                    ResidualGraph.AddAdjacency(j, i, ResidualGraph.GetWeight(j, i) + pathFlow);

                    // Add Result o ResultGraph
                    ResultGraph.AddAdjacency(i, j, ResultGraph.GetWeight(i, j) + pathFlow);
                    ResultGraph.AddAdjacency(j, i, ResultGraph.GetWeight(j, i) - pathFlow);

                }

                MaxFlow += pathFlow;
                bfs = new BreadthFirstSearch(ResidualGraph);
            }

            CleanNegativeAdjacenciesInResult();
        }

        public int GetMaxFlow()
        {
            return MaxFlow;
        }

        public override string ToString()
        {
            var result = String.Empty;

            result += "O Fluxo Máximo possível para o grafo é de: ";
            result += MaxFlow;

            result += "\n\nGrafo Original: \n";
            result += Graph.ToString() + '\n';

            result += "\n\nGrafo de Fluxo Máximo: \n";
            result += ResultGraph.ToString() + '\n';

            return result;
        }

        private void CleanNegativeAdjacenciesInResult()
        {
            for (int i = 0; i < ResultGraph.Vertexes.Length; i++)
            {
                for (int j = 0; j < ResultGraph.Vertexes.Length; j++)
                {
                    if (ResultGraph.GetWeight(i, j) <= 0)
                    {
                        ResultGraph.RemoveAdjacency(i, j);
                    }
                }
            }
        }
    }
}
