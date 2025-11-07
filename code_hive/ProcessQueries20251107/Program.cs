/// <summary>
/// 20251107
/// https://leetcode.cn/problems/power-grid-maintenance/
/// </summary>
public class Solution
{
    private int[] MachineStatus { get; set; }
    private Dictionary<int, List<int>> Graph { get; set; }
    private Dictionary<int, SortedSet<int>> ComponentActiveMachines { get; set; } // 每个连通分量的活跃机器
    private int[] Parent { get; set; }

    public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
    {
        var res = new List<int>();
        MachineStatus = new int[c + 1];
        Array.Fill(MachineStatus, 1);

        // 初始化并查集
        Parent = new int[c + 1];
        for (int i = 0; i <= c; i++)
        {
            Parent[i] = i;
        }

        // 预处理：构建邻接表
        Graph = new Dictionary<int, List<int>>();
        foreach (var connection in connections)
        {
            if (!Graph.ContainsKey(connection[0]))
                Graph[connection[0]] = new List<int>();
            if (!Graph.ContainsKey(connection[1]))
                Graph[connection[1]] = new List<int>();

            Graph[connection[0]].Add(connection[1]);
            Graph[connection[1]].Add(connection[0]);

            // 合并连通分量
            Union(connection[0], connection[1]);
        }

        // 初始化每个连通分量的活跃机器集合
        ComponentActiveMachines = new Dictionary<int, SortedSet<int>>();
        for (int i = 1; i <= c; i++)
        {
            int root = Find(i);
            if (!ComponentActiveMachines.ContainsKey(root))
            {
                ComponentActiveMachines[root] = new SortedSet<int>();
            }
            ComponentActiveMachines[root].Add(i);
        }

        foreach (var query in queries)
        {
            if (query[0] == 2)
            {
                MachineStatus[query[1]] = 0;
                // 从连通分量中移除这台机器
                int root = Find(query[1]);
                if (ComponentActiveMachines.ContainsKey(root))
                {
                    ComponentActiveMachines[root].Remove(query[1]);
                }
            }
            else
            {
                res.Add(ProcessQuery(query[1]));
            }
        }
        return [.. res];
    }

    private int Find(int x)
    {
        if (Parent[x] != x)
        {
            Parent[x] = Find(Parent[x]); // 路径压缩
        }
        return Parent[x];
    }

    private void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
        {
            Parent[rootX] = rootY;
        }
    }

    private int ProcessQuery(int query)
    {
        int root = Find(query);

        if (MachineStatus[query] == 1)
        {
            return query;
        }

        // 查询连通分量中最小的活跃机器
        if (ComponentActiveMachines.ContainsKey(root) && ComponentActiveMachines[root].Count > 0)
        {
            return ComponentActiveMachines[root].Min;
        }

        return -1;
    }
}