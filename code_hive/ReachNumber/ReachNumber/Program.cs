/// <summary>
/// 20221104
/// https://leetcode.cn/problems/reach-a-number/
/// </summary>
public class Solution
{
    public int ReachNumber(int target)
    {
        target = Math.Abs(target);
        int k = 0;
        while (target > 0)
        {
            k++;
            target -= k;
        }
        return target % 2 == 0 ? k : k + 1 + k % 2;
    }
}