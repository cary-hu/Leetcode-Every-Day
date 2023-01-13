/// <summary>
/// 20220113
/// https://leetcode.cn/problems/rearrange-characters-to-make-target-string/
/// </summary>
/// 
new Solution().RearrangeCharacters("ilovecodingonleetcode", "code");
public class Solution
{
    public int RearrangeCharacters(string s, string target)
    {
        IDictionary<char, int> sCounts = new Dictionary<char, int>();
        IDictionary<char, int> targetCounts = new Dictionary<char, int>();
        foreach (char c in target)
        {
            targetCounts.TryAdd(c, 0);
            targetCounts[c]++;
        }
        foreach (char c in s)
        {
            if (targetCounts.ContainsKey(c))
            {
                sCounts.TryAdd(c, 0);
                sCounts[c]++;
            }
        }
        int ans = int.MaxValue;
        foreach (KeyValuePair<char, int> pair in targetCounts)
        {
            char c = pair.Key;
            int count = pair.Value;
            int totalCount = sCounts.ContainsKey(c) ? sCounts[c] : 0;
            ans = Math.Min(ans, totalCount / count);
            if (ans == 0)
            {
                return 0;
            }
        }
        return ans;
    }
}