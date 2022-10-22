/// <summary>
/// 20221017
/// https://leetcode.cn/problems/fruit-into-baskets/
/// </summary>
public class Solution
{
    public int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        var kinds = new Dictionary<int, int>();
        int left = 0, ans = 0;
        for (int right = 0; right < n; ++right)
        {
            kinds.TryAdd(fruits[right], 0);
            ++kinds[fruits[right]];
            while (kinds.Count > 2)
            {
                --kinds[fruits[left]];
                if (kinds[fruits[left]] == 0)
                {
                    kinds.Remove(fruits[left]);
                }
                ++left;
            }
            ans = Math.Max(ans, right - left + 1);
        }
        return ans;
    }
}