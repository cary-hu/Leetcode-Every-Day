﻿/// <summary>
/// 20221219
/// https://leetcode.cn/problems/find-if-path-exists-in-graph/
/// </summary>
public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        IList<int>[] adj = new IList<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int>();
        }
        foreach (int[] edge in edges)
        {
            int x = edge[0], y = edge[1];
            adj[x].Add(y);
            adj[y].Add(x);
        }
        bool[] visited = new bool[n];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(source);
        visited[source] = true;
        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            if (vertex == destination)
            {
                break;
            }
            foreach (int next in adj[vertex])
            {
                if (!visited[next])
                {
                    queue.Enqueue(next);
                    visited[next] = true;
                }
            }
        }
        return visited[destination];
    }
}
