/// <summary>
/// 20250530
/// https://leetcode.cn/problems/find-closest-node-to-given-two-nodes/
/// </summary>
public class Solution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;
        int[] d1 = GetDistance(edges, node1);
        int[] d2 = GetDistance(edges, node2);

        int res = -1;
        for (int i = 0; i < n; i++)
        {
            if (d1[i] != -1 && d2[i] != -1)
            {
                if (res == -1 || Math.Max(d1[res], d2[res]) > Math.Max(d1[i], d2[i]))
                {
                    res = i;
                }
            }
        }
        return res;
    }

    private int[] GetDistance(int[] edges, int node)
    {
        int n = edges.Length;
        int[] dist = new int[n];
        Array.Fill(dist, -1);
        int distance = 0;
        while (node != -1 && dist[node] == -1)
        {
            dist[node] = distance++;
            node = edges[node];
        }
        return dist;
    }
}