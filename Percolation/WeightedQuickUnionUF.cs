using System;

namespace Percolation
{
    public class WeightedQuickUnionUF
    {
        private long[] Nodes;
        private long[] Size;
        private long[] Max;

        public WeightedQuickUnionUF(long noOfNodes)
        {
            Nodes = new long[noOfNodes];
            Size = new long[noOfNodes];
            Max = new long[noOfNodes];

            for (int i = 0; i < noOfNodes; i++)
            {
                Nodes[i] = i;
                Size[i] = 1;
                Max[i] = i;
            }
        }

        public void PrintStatus()
        {
           //Console.WriteLine($"[ {string.Join(',', Nodes)} ]");
        }

        private long Root(long id)
        {
            while (id != Nodes[id])
            {
                Nodes[id] = Nodes[Nodes[id]];
                id = Nodes[id];
            }
            return id;
        }

        public bool Connected(long id1, long id2)
        {
            return Find(id1) == Find(id2);
        }

        public void Union(long id1, long id2)
        {
            long root1 = Root(id1);
            long root2 = Root(id2);

            if (root1 == root2) return;

            if (Size[root1] < Size[root2])
            {
                Nodes[root1] = root2;
                Size[root2] += Size[root1];
            }
            else
            {
                Nodes[root2] = root1;
                Size[root1] += Size[root2];
            }

            if (Max[root1] < Max[root2])
            {
                Max[root1] = Max[root2];
            }
            else
            {
                Max[root2] = Max[root1];
            }

            //Console.WriteLine($"[ {string.Join(',', Nodes)} ]");

        }

        public long Find(long id)
        {
            return Max[Root(id)];
        }
    }
}