/// <summary>
/// 20250314
/// https://leetcode.cn/problems/check-balanced-string/
/// </summary>
public class Solution
{
    public bool IsBalanced(string num)
    {
        var chars = num.ToCharArray();
        var left = 0;
        var right = 0;
        var index = 0;
        foreach (var item in chars)
        {
            int x = item - '0';
            if (index++ % 2 == 0)
            {
                left += x;
            }
            else
            {
                right += x;
            }
        }
        return left == right;
    }
}