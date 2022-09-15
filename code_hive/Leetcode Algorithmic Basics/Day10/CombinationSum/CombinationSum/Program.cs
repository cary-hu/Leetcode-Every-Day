/// <summary>
/// 20220915
/// https://leetcode.cn/problems/combination-sum/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
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
        DFS(candidates, sum, n + 1, target, res, path);
        path.Add(candidates[n]);
        DFS(candidates, sum + candidates[n], n, target, res, path);
        path.RemoveAt(path.Count - 1);
    }
}