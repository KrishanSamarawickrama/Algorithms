using System;

namespace Dynamic_Connectivity
{
    public class QuickUnionImproved : IDynamicCon
    {
        private int[] Nodes;
        private int[] Size;

        public QuickUnionImproved(int numberOfNodes)
        {
            Initilize(numberOfNodes);
            Console.WriteLine($"Node State INIT : [{string.Join(',', Nodes)}]");
        }

        private void Initilize(int num)
        {
            Nodes = new int[num];
            Size = new int[num];
            for (int i = 0; i < num; i++)
            {
                Nodes[i] = i;
                Size[i] = 1;
            }
        }

        private int Root(int node)
        {
            while (node != Nodes[node])
            {
                //Make every other node in path point to its grandparent(thereby halving path length)
                Nodes[node] = Nodes[Nodes[node]];
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
            int node1_root = Root(node1);
            int node2_root = Root(node2);

            if (node1_root == node2_root) return;

            //Make the small size tree child as the large size tree
            if (Size[node1_root] < Size[node2_root])
            {
                Nodes[node1_root] = node2_root;
                Size[node2_root] += Size[node1_root];
            }
            else
            {
                Nodes[node2_root] = node1_root;
                Size[node1_root] += Size[node2_root];
            }

            Console.WriteLine($"Node State : [{string.Join(',', Nodes)}]");
        }
                
    }
}