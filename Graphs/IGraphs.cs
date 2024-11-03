namespace MaxFlow.Graphs
{
    interface IGraph
    {
        public string[] Vertexes { get; set;}

        void AddAdjacency(int from, int to, int weight);

        void RemoveAdjacency(int from, int to);

        List<int> AdjacenciesFrom(int vertex);

        bool HasAdjacency(int from, int to);

        int GetWeight(int from, int to);

        IGraph Copy();

        void Reset();
    }
};
