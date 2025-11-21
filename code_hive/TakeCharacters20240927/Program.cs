/// <summary>
/// 20240927
/// https://leetcode.cn/problems/take-k-of-each-character-from-left-and-right/
/// </summary>
public class Solution
{
    public int TakeCharacters(string s, int k)
    {
        int[] cnt = new int[3];
        int len = s.Length;
        int ans = s.Length;
        foreach (char c in s)
        {
            cnt[c - 'a']++;
        }
        if (IsInvalid(cnt[0], cnt[1], cnt[2], k))
        {
            return -1;
        }

        int l = 0;
        for (int r = 0; r < len; r++)
        {
            cnt[s[r] - 'a']--;
            while (l < r && IsInvalid(cnt[0], cnt[1], cnt[2], k))
            {
                cnt[s[l] - 'a']++;
                l++;
            }
            if (!IsInvalid(cnt[0], cnt[1], cnt[2], k))
            {
                ans = Math.Min(ans, len - (r - l + 1));
            }
        }

        return ans;
    }
    public static bool IsInvalid(int countA, int countB, int countC, int k)
    {
        return countA < k || countB < k || countC < k;
    }
}