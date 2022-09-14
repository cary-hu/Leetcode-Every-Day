/// <summary>
/// 20220914
/// https://leetcode.cn/problems/permutations-ii/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var res = new List<IList<int>>();
        var st = new bool[nums.Length];
        Array.Fill(st, false);
        var path = new int[nums.Length];
        DFS(nums, 0, 0, st, path, res);
        return res;
    }
    private void DFS(int[] nums, int u, int start, bool[] st, int[] path, List<IList<int>> res)
    {
        if (u == nums.Length)
        {
            res.Add(new List<int>(path));
            return;
        }
        for (int i = start; i < nums.Length; i++)
        {
            if (!st[i])
            {
                st[i] = true;
                path[i] = nums[u];
                if (u + 1 < nums.Length && nums[u + 1] != nums[u])
                    DFS(nums, u + 1, 0, st, path, res);
                else
                    DFS(nums, u + 1, i + 1, st, path, res);
                st[i] = false;
            }
        }
    }
}