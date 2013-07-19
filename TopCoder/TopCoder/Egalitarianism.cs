using System;
using System.Collections.Generic;
using System.Text;

public class Egalitarianism
{
    public int maxDifference(String[] isFriend, int d)
    {
        int n = isFriend.Length;
        UF uf = new UF(n);
        Graph g = new Graph(n);
        for (int i = 0; i < isFriend.Length; i++)
        {
            for (int j = 0; j < isFriend[i].Length; j++)
            {
                if (isFriend[i][j] == 'Y')
                {
                    uf.Union(i, j);
                    if (i < j)
                    {
                        g.AddEdge(i,j);
                    }
                }
            }
        }

        if (uf.Count() > 1)
        {
            return -1;
        }
        
        int count = 0;
        for (int i = 0; i < g.V; i++)
        {
            BreadthFirstSearch bfs = new BreadthFirstSearch(g, i);
            for (int j = 0; j < g.V; j++)
            {
                count = Math.Max(bfs.DistTo(j), count);
            }
            
        }
        return count*d;
    }
    public class Graph
    {

        private int v;
        private int e;
        private List<int>[] adj;
        public Graph(int v)
        {
            this.v = v;
            e = 0;
            adj = new List<int>[v];
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new List<int>();
            }
        }
        public int V { get { return v; } }
        public int E { get { return e; } }

        public List<int> Adj(int v)
        {
            return adj[v];
        }
        public void AddEdge(int v, int w)
        {
            e++;
            adj[v].Add(w);
            adj[w].Add(v);
        }
    }

    public class BreadthFirstSearch
    {
        public const int INFINITY = int.MaxValue;
        private bool[] marked;
        private int[] edgeTo;
        private int[] distTo;

        public BreadthFirstSearch(Graph g, int s)
        {
            marked = new bool[g.V];
            distTo = new int[g.V];
            edgeTo = new int[g.V];
            bfs(g, s);
        }
        private void bfs(Graph g, int s)
        {
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < g.V; i++)
            {
                distTo[i] = INFINITY;
            }

            //we can reach s
            distTo[s] = 0;
            marked[s] = true;
            q.Enqueue(s);

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                foreach (int w in g.Adj(v))
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        distTo[w] = distTo[v] + 1;
                        marked[w] = true;
                        q.Enqueue(w);
                    }
                }
            }
        }
        public int DistTo(int v)
        {
            return distTo[v];
        }

    }

    public class UF
    {
        private int[] id;
        private int[] sz;
        private int count;
        public UF(int n)
        {
            if (n < 0)
                throw new ArgumentException("n cann't be negative");
            count = n;
            id = new int[n];
            sz = new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }
        public int Find(int p)
        {
            while (p != id[p])
            {
                p = id[p];
            }

            return p;
        }
        public int Count()
        {
            return count;
        }
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }
        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j)
                return;
            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            count--;
        }
    }
}

