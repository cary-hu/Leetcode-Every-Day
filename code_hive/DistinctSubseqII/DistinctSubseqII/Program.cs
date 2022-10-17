/// <summary>
/// 20221014
/// https://leetcode.cn/problems/distinct-subsequences-ii/
/// </summary>
public class Solution
{
    int mod = (int)1e9 + 7;
    public int DistinctSubseqII(string s)
    {
        var count = new long[26];
        var ans = 0l;
        foreach (var charItem in s)
        {
            int a = charItem - 'a';
            ans += mod - count[a];
            count[a] = (count[a] + ans + 1) % mod;
            ans = (ans + count[a]) % mod;
        }
        return (int)ans;
    }
}