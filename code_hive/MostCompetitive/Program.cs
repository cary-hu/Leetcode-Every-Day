/// <summary>
/// 20240524
/// https://leetcode.cn/problems/find-the-most-competitive-subsequence/
/// </summary>
public class Solution
{
    public int[] MostCompetitive(int[] nums, int k)
    {
        var stack = new Stack<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var n = nums[i];
            if (stack.Count == 0 || stack.Peek() <= n)
            {
                stack.Push(n);
            }
            else
            {
                while (!(stack.Count == 0) && stack.Peek() > n && stack.Count - 1 + nums.Length - i >= k)
                {
                    stack.Pop();
                }
                stack.Push(n);
            }
        }
        return stack.Reverse().Take(k).ToArray();
    }
}