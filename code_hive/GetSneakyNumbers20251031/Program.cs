/// <summary>
/// 20251031
/// https://leetcode.cn/problems/the-two-sneaky-numbers-of-digitville/description/
/// </summary>
public class Solution
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        Span<bool> seen = stackalloc bool[nums.Length];
        Span<int> result = stackalloc int[2];
        int count = 0;
        
        foreach (int num in nums)
        {
            if (seen[num])
            {
                result[count++] = num;
                if (count == 2) break;
            }
            else
            {
                seen[num] = true;
            }
        }
        
        return result.ToArray();
    }
}