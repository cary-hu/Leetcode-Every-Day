/// <summary>
/// 20251017
/// https://leetcode.cn/problems/can-make-palindrome-from-substring/description/
/// </summary>
public class Solution
{
    public IList<bool> CanMakePaliQueries(string s, int[][] queries)
    {
        int n = s.Length;
        int[,] count = new int[n + 1, 26];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                count[i + 1, j] = count[i, j];
            }
            count[i + 1, s[i] - 'a']++;
        }

        var result = new List<bool>();
        foreach (var query in queries)
        {
            int left = query[0], right = query[1], k = query[2];
            int oddCount = 0;
            for (int i = 0; i < 26; i++)
            {
                int charCount = count[right + 1, i] - count[left, i];
                if (charCount % 2 == 1) oddCount++;
            }
            result.Add(oddCount / 2 <= k);
        }
        return result;
    }
}