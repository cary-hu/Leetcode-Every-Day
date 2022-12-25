/// <summary>
/// 20221225
/// https://leetcode.cn/problems/building-boxes/
/// </summary>
public class Solution
{
    public int MinimumBoxes(int n)
    {
        int cur = 1, i = 1, j = 1;
        while (n > cur)
        {
            n -= cur;
            i++;
            cur += i;
        }
        cur = 1;
        while (n > cur)
        {
            n -= cur;
            j++;
            cur++;
        }
        return (i - 1) * i / 2 + j;
    }
}