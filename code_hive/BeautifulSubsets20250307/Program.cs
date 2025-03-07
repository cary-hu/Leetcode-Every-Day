/// <summary>
/// 20250307
/// https://leetcode.cn/problems/the-number-of-beautiful-subsets/
/// </summary>
public class Solution
{
    private int Res = 0;
    public int BeautifulSubsets(int[] nums, int k)
    {
        dfs(nums, 0, k, []);
        return Res;
    }
    private void dfs(int[] nums, int idx, int k, List<int> currents)
    {
        if (idx == nums.Length)
        {
            if (currents.Count != 0)
            {
                Res++;
            }
            return;
        }
        int num = nums[idx];
        if (!currents.Contains(num + k) && !currents.Contains(num - k))
        {
            currents.Add(num);
            dfs(nums, idx + 1, k, currents);
            currents.RemoveAt(currents.Count - 1);
        }
        dfs(nums, idx + 1, k, currents);
    }
}