namespace MaxFlow.Graphs
{
    class MatrixAdjacencies: IGraph
    {
        private readonly int[,] AdjacenciesWeight;
        private readonly bool[,] Adjacencies;

        public string[] Vertexes { get; set; }

        public MatrixAdjacencies(int vertexCount)
        {
            Adjacencies = new bool[vertexCount, vertexCount];
            AdjacenciesWeight = new int [vertexCount, vertexCount];
            Vertexes = new string[vertexCount];

            for (int i = 0;  i < Vertexes.Length; i++)
            {
                Vertexes[i] = i.ToString();

                for (int j = 0; j < Vertexes.Length; j++)
                {
                    Adjacencies[i, j] = false;
                    AdjacenciesWeight[i, j] = 0;
                }
            }
        }

        private MatrixAdjacencies(MatrixAdjacencies graph)
        {
            int size = graph.Vertexes.Length;

            Adjacencies = new bool [size, size];
            AdjacenciesWeight = new int[size, size];
            Vertexes = new string[size];

            for (int i = 0; i < size; i++)
            {
                Vertexes[i] = graph.Vertexes[i].ToString();

                for (int j = 0; j < size; j++)
                {
                    Adjacencies[i, j] = graph.HasAdjacency(i, j);
                    AdjacenciesWeight[i, j] = graph.GetWeight(i, j);
                }
            }
        }

        public void AddAdjacency(int from, int to, int weight)
        {
            if (from < 0 || to < 0) return;
            if (from > Vertexes.Length || to > Vertexes.Length) return;

            Adjacencies[from, to] = true;
            AdjacenciesWeight[from, to] = weight;
        }

        public List<int> AdjacenciesFrom(int vertex)
        {
            if (vertex < 0 || vertex > Vertexes.Length) return [];

            List<int> Adjacencies = [];

            for (int i = 0; i < Vertexes.Length; i++)
            {
                if (this.Adjacencies[vertex, i] == true) Adjacencies.Add(i);
            }

            return Adjacencies;
        }

        public bool HasAdjacency(int from, int to)
        {
            return Adjacencies[from, to];
        }

        public int GetWeight(int from, int to)
        {
            return AdjacenciesWeight[from, to];
        }

        public IGraph Copy()
        {
            return new MatrixAdjacencies(this);
        }

        public void Reset()
        {
            for (int i = 0; i < Vertexes.Length; i++)
            {
                for (int j = 0; j < Vertexes.Length; j++)
                {
                    Adjacencies[i, j] = false;
                    AdjacenciesWeight[i, j] = 0;
                }
            }
        }

        public void RemoveAdjacency(int from, int to)
        {
            if (from < 0 || to < 0) return;
            if (from > Vertexes.Length || to > Vertexes.Length) return;

            Adjacencies[from, to] = false;
            AdjacenciesWeight[from, to] = 0;
        }

        public override String ToString()
        {
            string output = "";
            for (int i = 0; i < Vertexes.Length; i++) {
                output += i.ToString() + ": ";

                for (int j = 0; j < Vertexes.Length; j++) {
                    output += AdjacenciesWeight[i, j].ToString() + " ";
                }
                output += '\n';
            }

            return output;
        }
    }
}
