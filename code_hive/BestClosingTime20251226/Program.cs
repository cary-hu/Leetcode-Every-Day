/// <summary>
/// 20251226
/// https://leetcode.cn/problems/minimum-penalty-for-a-shop/
/// </summary>
public class Solution
{
    public int BestClosingTime(string customers)
    {
        int n = customers.Length;
        int res = int.MaxValue;
        int currentMinSum = int.MaxValue;
        int pre = 0;
        int suf = 0;
        for (int i = 0; i <= n; i++)
        {
            if (currentMinSum > suf + pre)
            {
                currentMinSum = suf + pre;
                res = i;
            }
            if (i < n && customers[i] == 'N')
            {
                pre++;
            }
            else if (i < n)
            {
                suf--;
            }
        }
        return res;

    }
}