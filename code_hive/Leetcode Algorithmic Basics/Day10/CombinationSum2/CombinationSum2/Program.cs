using System.Drawing;
/// <summary>
/// 20220915
/// https://leetcode.cn/problems/combination-sum-ii/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        var res = new List<IList<int>>();
        DFS(candidates, 0, 0, target, res, new List<int>());
        return res;

    }
    private void DFS(int[] candidates, int sum, int n, int target, List<IList<int>> res, List<int> path)
    {
        if (sum == target)
        {
            res.Add(new List<int>(path));
            return;
        }
        if (sum > target || n == candidates.Length)
        {
            return;
        }
        for (int i = n + 1; i < candidates.Length; i++)
        {

            if (candidates[i] != candidates[n])
            {
                DFS(candidates, sum, i, target, res, path);
                break;
            }
        }
        path.Add(candidates[n]);
        DFS(candidates, sum + candidates[n], n + 1, target, res, path);
        path.RemoveAt(path.Count - 1);
    }
}