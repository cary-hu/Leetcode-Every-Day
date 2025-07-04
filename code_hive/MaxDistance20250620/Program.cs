/// <summary>
/// 20250620
/// https://leetcode.cn/problems/maximum-manhattan-distance-after-k-changes/
/// </summary>
public class Solution
{
    public int MaxDistance(string s, int k)
    {
        int n = 0;
        int e = 0; 
        int ans = 0;
        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case 'N': n++; break;
                case 'S': n--; break;
                case 'E': e++; break;
                case 'W': e--; break;
            }
            int cur = Math.Abs(n) + Math.Abs(e) + 2 * k;
            int maxPossible = Math.Min(cur, i + 1);
            ans = Math.Max(ans, maxPossible);
        }
        return ans;

    }
}