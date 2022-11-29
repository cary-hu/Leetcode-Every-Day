/// <summary>
/// 20221129
/// https://leetcode.cn/problems/minimum-changes-to-make-alternating-binary-string/
/// </summary>
public class Solution
{
    public int MinOperations(string s)
    {
        var x = 0;
        int cnt0 = 0, cnt1 = 0;
        foreach (char c in s)
        {
            if (c-'0' != x)
            {
                cnt0++;
            }
            else
            {
                cnt1++;
            }
            x ^= 1;
        }
        return Math.Min(cnt0, cnt1);
    }
}