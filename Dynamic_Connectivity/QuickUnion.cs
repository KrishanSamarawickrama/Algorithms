using System;

namespace Dynamic_Connectivity
{
    public class QuickUnion : IDynamicCon
    {
        private int[] Nodes;

        public QuickUnion(int numberOfNodes)
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

        private int Root(int node)
        {
            while (node != Nodes[node])
            {
                node = Nodes[node];
            }
            return node;
        }

        public bool Connected(int node1, int node2)
        {
            return Root(node1) == Root(node2);
        }

        public void Union(int node1, int node2)
        {
            int root_node1 = Root(node1);
            int root_node2 = Root(node2);

            //Make root of node 1 as a child of root of node2
            Nodes[root_node1] = root_node2;

            Console.WriteLine($"Node State : [{string.Join(',', Nodes)}]");
        }
    }
}