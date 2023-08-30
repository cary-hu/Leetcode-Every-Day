/// <summary>
/// 20230830
/// https://leetcode.cn/problems/sort-items-by-groups-respecting-dependencies
/// </summary>
public class Solution
{
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
    {
        for (int i = 0; i < group.Length; i++)
        {
            if (group[i] == -1)
            {
                group[i] = m++;
            }
        }

        List<List<int>> groupAdj = new();
        for (int i = 0; i < m; i++)
        {
            groupAdj.Add(new List<int>());
        }
        List<List<int>> itemAdj = new();
        for (int i = 0; i < n; i++)
        {
            itemAdj.Add(new List<int>());
        }

        int[] groupsIndegree = new int[m];
        int[] itemsIndegree = new int[n];

        for (int i = 0; i < n; i++)
        {
            int currentGroup = group[i];
            foreach (var beforeItem in beforeItems[i])
            {
                itemAdj[beforeItem].Add(i);
                itemsIndegree[i]++;
                int beforeGroup = group[beforeItem];
                if (beforeGroup != currentGroup)
                {
                    groupAdj[beforeGroup].Add(currentGroup);
                    groupsIndegree[currentGroup]++;
                }

            }
        }
        var groupsList = TopologicalSort(groupAdj, groupsIndegree, m);
        var itemsList = TopologicalSort(itemAdj, itemsIndegree, n);
        if (groupsList.Count == 0 || itemsList.Count == 0)
        {
            return Array.Empty<int>();
        }

        Dictionary<int, List<int>> groupMapItems = new();
        foreach (int item in itemsList)
        {
            var groupId = group[item];
            if (!groupMapItems.ContainsKey(groupId))
            {
                groupMapItems.Add(groupId, new List<int>());
            }
            groupMapItems[groupId].Add(item);
        }

        List<int> res = new();
        foreach (int groupId in groupsList)
        {
            List<int> items = groupMapItems.GetValueOrDefault(groupId, new List<int>());
            res.AddRange(items);
        }
        return res.ToArray();
    }
    private static IList<int> TopologicalSort(IList<List<int>> adj, IList<int> indegree, int n)
    {
        var res = new List<int>();
        var queue = new Queue<int>();

        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        while (queue.Any())
        {
            var front = queue.Dequeue();
            res.Add(front);
            foreach (var item in adj[front])
            {
                indegree[item]--;
                if (indegree[item] == 0)
                {
                    queue.Enqueue(item);
                }
            }
        }
        if (res.Count == n)
        {
            return res;
        }
        return new List<int>();
    }
}