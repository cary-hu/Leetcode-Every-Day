/// <summary>
/// 20260731
/// https://leetcode.cn/problems/minimum-number-of-pushes-to-type-word-ii/
/// </summary>
new Solution().MinimumPushes("abcde");
public class Solution
{
    public int MinimumPushes(string word)
    {
        var cnt = new int[26];
        foreach (char b in word)
        {
            cnt[b - 'a']++;
        }
        Array.Sort(cnt, (a, b) => b.CompareTo(a));

        int ans = 0;
        for (int i = 0; i < 26; i++)
        {
            ans += cnt[i] * (i / 8 + 1);
        }
        return ans;

    }
}
