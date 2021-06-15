namespace Percolation
{
    public class Percolation
    {
        private long[,] Grid;
        private bool[,] GridStatus;

        private WeightedQuickUnionUF uf;

        // creates n-by-n grid, with all sites initially blocked
        public Percolation(long n)
        {
            uf = new WeightedQuickUnionUF((n * n) + 2);
            Grid = new long[n, n];
            GridStatus = new bool[n, n];

            uf.PrintStatus();

            long count = 1;
            for (long r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (r == 0)
                        uf.Union(0, c + 1);
                    if (r == n - 1)
                        uf.Union(Grid.Length + 1, Grid.Length - c);

                    Grid[r, c] = count;
                    count++;
                }
            }

            uf.PrintStatus();
        }

        // opens the site (row, col) if it is not open already
        public void Open(long row, long col)
        {
            if (IsFull(row, col))
            {
                GridStatus[row, col] = true;

                if (IsOpen(row, col + 1))
                {
                    uf.Union(Grid[row, col], Grid[row, col + 1]);
                }

                if (IsOpen(row, col - 1))
                {
                    uf.Union(Grid[row, col], Grid[row, col - 1]);
                }

                if (IsOpen(row - 1, col))
                {
                    uf.Union(Grid[row, col], Grid[row - 1, col]);
                }

                if (IsOpen(row + 1, col))
                {
                    uf.Union(Grid[row, col], Grid[row + 1, col]);
                }
            }
            uf.PrintStatus();
        }

        // is the site (row, col) open?
        public bool IsOpen(long row, long col)
        {
            try
            {
                return GridStatus[row, col];
            }
            catch
            {
                return false;
            }
        }

        // is the site (row, col) full?
        public bool IsFull(long row, long col)
        {
            try
            {
                return !GridStatus[row, col];
            }
            catch
            {
                return false;
            }
        }

        // returns the number of open sites
        public long NumberOfOpenSites()
        {
            long count = 0;
            foreach (var site in GridStatus)
            {
                if (site) count++;
            }
            return count;
        }

        // does the system percolate?
        public bool Percolates()
        {
            return uf.Connected(0, Grid.Length);
        }
    }
}