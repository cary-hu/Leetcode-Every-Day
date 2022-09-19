/// <summary>
/// 20220919
/// https://leetcode.cn/problems/word-break/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var wordDictSet = new HashSet<string>(wordDict);
        var dp = new bool[s.Length + 1];
        dp[0] = true;
        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && wordDictSet.Contains(s[j..i]))
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[s.Length];
    }
}