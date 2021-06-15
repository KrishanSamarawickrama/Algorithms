using System;
using System.IO;
using System.Linq;
using Dynamic_Connectivity;

//QuickFind qfa = null;
//QuickUnion qfa = null;
//QuickUnionImproved qfa = null;
UnionFindWithFind qfa = null;

var inputs = File.ReadLines("Inputs.txt")?.ToArray();

for (int i = 0; i < inputs.Length; i++)
{
    if (i == 0)
    {
        qfa = new (int.Parse(inputs[0]));
        continue;
    }

    var Nodes = inputs[i].Split(' ');
    int node1 = int.Parse(Nodes[0]);
    int node2 = int.Parse(Nodes[1]);

    if (!qfa.Connected(node1, node2))
    {
        Console.WriteLine($"{node1} U {node2}");
        qfa.Union(node1, node2);
    }
    else
    {
        Console.WriteLine($"{node1} Connected to {node2}");
    }
}

Console.WriteLine($"{qfa.Find(2)}");

