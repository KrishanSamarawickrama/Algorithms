using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Connectivity
{
    public class QuickFind : IDynamicCon
    {
        private int[] Nodes;

        public QuickFind(int numberOfNodes)
        {
            Initilize(numberOfNodes);
            Console.WriteLine($"Node State INIT : [{string.Join(',', Nodes)}]");
        }

        private void Initilize(int num)
        {
            Nodes = new int[num];
            for (int i = 0; i < num; i++)
            {
                Nodes[i] = i;
            }
        }

        public bool Connected(int node1, int node2)
        {
            return Nodes[node1] == Nodes[node2];
        }

        public void Union(int node1, int node2)
        {
            if (Connected(node1, node2)) return;

            int node1_id = Nodes[node1];
            int node2_id = Nodes[node2];

            for (int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i] == node1_id)
                {
                    Nodes[i] = node2_id;
                }
            }

            Console.WriteLine($"Node State : [{string.Join(',', Nodes)}]");
        }
    }
}
