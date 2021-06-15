using System;

namespace Dynamic_Connectivity
{
    public class UnionFindWithFind : IDynamicCon
    {
        private int[] Nodes;
        private (int Size, int Max)[] Meta;

        public UnionFindWithFind(int noOfNodes)
        {
            Nodes = new int[noOfNodes];
            Meta = new (int Size, int Max)[noOfNodes];

            for (int i = 0; i < noOfNodes; i++)
            {
                Nodes[i] = i;
                Meta[i].Size = 1;
                Meta[i].Max = i;
            }
            Console.WriteLine($"Node State : [{string.Join(',', Nodes)}]");
        }

        private int Root(int id)
        {
            while (id != Nodes[id])
            {
                Nodes[id] = Nodes[Nodes[id]];
                id = Nodes[id];
            }
            return id;
        }

        public bool Connected(int node1, int node2)
        {
            return Root(node1) == Root(node2);
        }

        public void Union(int node1, int node2)
        {
            int root1 = Root(node1);
            int root2 = Root(node2);

            if (root1 == root2) return;

            if (Meta[root1].Size < Meta[root2].Size)
            {
                Nodes[root1] = root2;
                Meta[root2].Size += Meta[root1].Size;
            }
            else
            {
                Nodes[root2] = root1;
                Meta[root1].Size += Meta[root2].Size;
            }

            if (Meta[root1].Max < Meta[root2].Max)
            {
                Meta[root1].Max = Meta[root2].Max;
            }
            else
            {
                Meta[root2].Max = Meta[root1].Max;
            }

            Console.WriteLine($"Node State : [{string.Join(',', Nodes)}]");
        }

        public int Find(int id)
        {
            return Meta[Root(id)].Max;
        }
    }
}