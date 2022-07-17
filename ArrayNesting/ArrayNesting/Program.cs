/// <summary>
/// 20220717
/// https://leetcode.cn/problems/array-nesting/
/// </summary>
public class Solution
{
    public int ArrayNesting(int[] nums)
    {
        var max = 1;
        var visited = new bool[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (max > nums.Length / 2)
            {
                return max;
            }
            if (visited[i])
            {
                continue;
            }
            visited[nums[i]] = true;
            var curMax = 1;
            int cur = nums[nums[i]];
            while (nums[i] != cur)
            {
                visited[cur] = true;
                curMax++;
                cur = nums[cur];
            }
            max = curMax > max ? curMax : max;
        }
        return max;
    }
}