using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemmingLab
{
    class Graph
    {
        private int vertex;
        private List<List<int>> edges = new List<List<int>>();
        public void setVertex(int countVertex)
        {
            this.vertex = countVertex;
            for (int i = 0; i < vertex; i++)
            {
                this.edges.Add(new List<int>());
            }
        }
        public int getVertex()
        {
            return this.vertex;
        }
        public void setEdges(List<int> edges, int currentVertex)
        {

            this.edges[currentVertex].AddRange(edges);
        }
        public List<List<int>> getEdges()
        {
            return this.edges;
        }
    }
}
