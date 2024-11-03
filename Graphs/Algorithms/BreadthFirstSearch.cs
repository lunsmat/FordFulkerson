using MaxFlow.Graphs.Utils;

namespace MaxFlow.Graphs.Algorithms
{
    class BreadthFirstSearch
    {
        readonly Queue<int> VertexQueue = new();

        private readonly EColors[] Colors;

        private readonly IGraph SearchedGraph;

        private readonly int[] Predecessors;

        private readonly int[] DiscoveryTime;

        private readonly List<int> QueueOrder;

        public bool HasVertexNotVisited => Colors.Where(color => color == EColors.White).Any();

        public BreadthFirstSearch(IGraph graph)
        {
            SearchedGraph = graph;
            Colors = new EColors[SearchedGraph.Vertexes.Length];
            Predecessors = new int[SearchedGraph.Vertexes.Length];
            DiscoveryTime = new int[SearchedGraph.Vertexes.Length];
            QueueOrder = [];
        }

        public bool Run(int sink, int terminal)
        {
            Initialize(sink);

            while (!IsQueueEmpty())
            {
                int vertex = Dequeue();

                foreach (var adj in SearchedGraph.AdjacenciesFrom(vertex))
                {
                    if (!IsVertexVisited(adj) && SearchedGraph.GetWeight(vertex, adj) > 0)
                    {
                        VisitVertex(adj, vertex);

                        if (adj == terminal) return  true;
                    }
                }
            }

            return false;
        }


        public void Run(int first = 0)
        {
            Initialize(first);

            while (!IsQueueEmpty())
            {
                int vertex = Dequeue();

                foreach (var adj in SearchedGraph.AdjacenciesFrom(vertex))
                {
                    if (!IsVertexVisited(vertex))
                    {
                        VisitVertex(adj, vertex);
                    }
                }

                FinishVertex(vertex);
            }
        }

        public int GetPredecessor(int vertex)
        {
            return Predecessors[vertex];
        }

        private void Initialize(int first)
        {
            for (int i = 0; i < SearchedGraph.Vertexes.Length; i++)
            {
                Colors[i] = EColors.White;
                Predecessors[i] = -1;
            }

            Colors[first] = EColors.Gray;
            DiscoveryTime[first] = 0;
            VertexQueue.Enqueue(first);
        }

        private int Dequeue()
        {
            int vertex = VertexQueue.Dequeue();
            QueueOrder.Add(vertex);

            return vertex;
        }

        private bool IsVertexVisited(int vertex)
        {
            return Colors[vertex] != EColors.White;
        }

        private void VisitVertex(int vertex, int predecessor)
        {
            Colors[vertex] = EColors.Gray;
            DiscoveryTime[vertex] = DiscoveryTime[predecessor] + 1;
            Predecessors[vertex] = predecessor;
            VertexQueue.Enqueue(vertex);
        }

        private bool IsQueueEmpty()
        {
            return VertexQueue.Count == 0;
        }

        private void FinishVertex(int vertex)
        {
            Colors[vertex] = EColors.Black;
        }
    }
};
