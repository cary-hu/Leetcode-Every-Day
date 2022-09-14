/// <summary>
/// 20220914
/// https://leetcode.cn/problems/subsets-ii/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        BackTrack(nums, res, new List<int>(), 0);
        return res;
    }
    private void BackTrack(int[] nums, List<IList<int>> res, List<int> path, int start)
    {
        res.Add(new List<int>(path));
        for (int i = start; i < nums.Length; i++)
        {
            if (i > start && nums[i] == nums[i - 1])
            {
                continue;
            }
            path.Add(nums[i]);
            BackTrack(nums, res, path, i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }
}
