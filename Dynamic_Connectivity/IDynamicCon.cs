namespace Dynamic_Connectivity
{
    public interface IDynamicCon
    {
        bool Connected(int node1, int node2);
        void Union(int node1, int node2);
    }
}