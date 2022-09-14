var a = new Solution();
a.Subsets(new int[] { 1, 2, 3 });
/// <summary>
/// 20220914
/// https://leetcode.cn/problems/subsets/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var res = new List<IList<int>>();
        BackTrack(nums, res, new List<int>(), 0);
        return res;
    }
    private void BackTrack(int[] nums, List<IList<int>> res, List<int> path, int start)
    {
        res.Add(new List<int>(path));
        for (int i = start; i < nums.Length; i++)
        {
            path.Add(nums[i]);
            BackTrack(nums, res, path, i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }
}