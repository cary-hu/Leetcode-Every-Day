/// <summary>
/// 20221018
/// https://leetcode.cn/problems/numbers-at-most-n-given-digit-set/
/// </summary>
public class Solution
{
    private int res = 0;
    public int AtMostNGivenDigitSet(string[] digits, int n)
    {
        string s = n.ToString();
        int m = digits.Length, k = s.Length;
        int[][] dp = new int[k + 1][];
        for (int i = 0; i <= k; i++)
        {
            dp[i] = new int[2];
        }
        dp[0][1] = 1;
        for (int i = 1; i <= k; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (digits[j][0] == s[i - 1])
                {
                    dp[i][1] = dp[i - 1][1];
                }
                else if (digits[j][0] < s[i - 1])
                {
                    dp[i][0] += dp[i - 1][1];
                }
                else
                {
                    break;
                }
            }
            if (i > 1)
            {
                dp[i][0] += m + dp[i - 1][0] * m;
            }
        }
        return dp[k][0] + dp[k][1];
    }
    private void PermuteDFS(int n, string nums, string[] digits, int currentLength, List<string> path)
    {
        if (currentLength > nums.Length)
        {
            if (GetIntFromList(path) <= n)
            {
                res++;
            }
            return;
        }
        for (int i = 0; i < digits.Length; i++)
        {
            path.Add(digits[i]);
            PermuteDFS(n, nums, digits, currentLength + 1, path);
            path.RemoveAt(path.Count - 1);
        }
    }
    private int GetIntFromList(List<string> path)
    {
        var res = 0;
        for (int i = 0; i < path.Count; i++)
        {
            res = res * 10 + Convert.ToInt32(path[i]);
        }
        return res;
    }
}