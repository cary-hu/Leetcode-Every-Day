/// <summary>
/// 20220912
/// https://leetcode.cn/problems/all-paths-from-source-to-target/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    private List<IList<int>> res = new List<IList<int>>();
    private Stack<int> stack = new Stack<int>();
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        stack.Push(0);
        DFS(graph, 0, graph.Length - 1);
        return res;

    }
    private void DFS(int[][] graph, int x, int n)
    {
        if (x == n)
        {
            var currnet = stack.ToList();
            currnet.Reverse();
            res.Add(currnet);
            return;
        }
        foreach (var item in graph[x])
        {
            stack.Push(item);
            DFS(graph, item, n);
            stack.Pop();
        }
    }
}